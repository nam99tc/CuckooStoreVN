using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly IUserServices _user;
        public HomeAdminController(IUserServices user)
        {
            _user = user;
        }
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
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
                User user = _user.Find(filter: x => x.Email.Equals(email) && x.PassWord.Equals(pass) && x.StatusUser == StatusUser.HoatDong && x.Role == Role.Admin);
                if (user != null)
                {
                    //add session
                    Session["HoTenAdmin"] = user.FullName;
                    Session["EmailAdmin"] = user.Email;
                    Session["iduserAdmin"] = user.UserID;
                    Session["roleAdmin"] = user.Role;
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công";
                }
            }
            return RedirectToAction("Index");
        }
    }
}