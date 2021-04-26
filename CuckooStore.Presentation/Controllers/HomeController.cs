using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;



namespace CuckooStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IUserServices _userServices;
        private readonly ICommentServices _commentServices;
        private readonly IContactServices _contact;
        public HomeController(
            IProductServices productServices, 
            ICategoryServices categoryServices, 
            IUserServices userServices, 
            ICommentServices commentServices, 
            IContactServices contact)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _userServices = userServices;
            _commentServices = commentServices;
            _contact = contact;
        }
        //private CuckooDBcontext db = new CuckooDBcontext();
        public ActionResult Index(string id, FormCollection sch, int? page)
        {
            string searchString = sch["search"];
            IEnumerable<Product> products;

            if (id == null)
            {
                //lấy toàn bộ mặt hàng
                products = _productServices.GetAll();
                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(p => p.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
            }
            else
            {
                //lấy hàng theo mã nhà cung cấp được chọn
                products = _productServices.FindAll(filter: h => h.CategoryID.ToString().Equals(id));
                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(p => p.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
            }

            //phan trang
            products = products.OrderBy(x => x.ProductID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult TopProduct()
        {
            var top = _productServices.GetTop(orderBy: x => x.OrderByDescending(y => y.Price));
            return PartialView(top);
        }

        public PartialViewResult Menu()
        {
            var danhmuc = _categoryServices.GetAll();
            return PartialView(danhmuc);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            //lọc comment theo pro
            var comment = _commentServices.FindAll(filter: x => x.ProductID == id);
            //đếm số comment
            Session["TotalComment"] = comment.Count();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product hang = _productServices.GetById(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }
        public PartialViewResult Footer()
        {
            var danhmuc = _categoryServices.GetAll();
            return PartialView(danhmuc);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc)
        {

            string name = fc["FullName"];
            string email = fc["Email"];
            string pass = fc["PassWord"];
            string address = fc["Address"];
            string phone = fc["Phone"];
            User user = new User()
            {
                FullName = name,
                Email = email,
                PassWord = pass,
                Phone = phone,
                Address = address,
                Image = null,
                Role = Role.User,
                StatusUser = StatusUser.HoatDong
            };
            var checkemail = _userServices.Find(filter: x => x.Email == email);
            try
            {
                if (checkemail != null)
                {
                    ViewBag.ErrorEmail = "Email đã tồn tại";
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _userServices.Create(user);
                        return RedirectToAction("Login");
                    }
                }
            }
            catch
            {
                ViewBag.Error = "Đăng ký không thành công!";
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            string email = formCollection["email"];
            string pass = formCollection["pass"];
            if (ModelState.IsValid)
            {
                User user = _userServices.Find(filter: x => x.Email.Equals(email) && x.PassWord.Equals(pass) && x.StatusUser == StatusUser.HoatDong && x.Role == Role.User);
                if (user != null)
                {
                    //add session
                    Session["HoTen"] = user.FullName;
                    Session["Email"] = user.Email;
                    Session["iduser"] = user.UserID;
                    Session["ImageUser"] = user.Image;
                    Session["address"] = user.Address;
                    Session["phone"] = user.Phone;
                    return RedirectToAction("Index");
                    #region Admin
                    //Session["HoTenAdmin"] = user.FullName;
                    //Session["EmailAdmin"] = user.Email;
                    //Session["iduserAdmin"] = user.UserID;
                    //Session["roleIDAdmin"] = user.Role;
                    //return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                    #endregion
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        // GET: TAIKHOANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServices.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: TAIKHOANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FullName,Email,PassWord,Address,Phone,Status")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Session["HoTen"] = user.FullName;
                    Session["iduser"] = user.UserID;
                    _userServices.Update(user);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi sửa dữ liệu" + ex.Message;
                return View(user);
            }
        }
        [HttpPost]
        public ActionResult AddComment(FormCollection fc)
        {
            string content = fc["review"];
            int idpro = Int32.Parse(fc["idpro"]);
            var cm = new Comment()
            {
                Content = content,
                UserID = (int)Session["iduser"],
                ProductID = idpro,
                CommentDate = DateTime.Now
            };
            _commentServices.Create(cm);
            return RedirectToAction("Details", new { id = idpro });
        }

        [HttpPost]
        public ActionResult Contact(FormCollection fc)
        {
            string name = fc["name"];
            string email = fc["email"];
            string msg = fc["msg"];
            var contact = new Contact()
            {
                Name = name,
                Email = email,
                Content = msg,
                Date = DateTime.Now
            };
            _contact.Create(contact);
            return RedirectToAction("Index");
        }
    }
}