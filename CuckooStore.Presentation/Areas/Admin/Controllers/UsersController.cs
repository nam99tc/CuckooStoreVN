using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CuckooStore.BusinessLogicLayer;
using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using PagedList;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices _user;
        public UsersController(IUserServices user)
        {
            _user = user;
        }
        // GET: Admin/Users
        public async Task<ActionResult> Index(int? page, string sortOrder)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                //sap xep
                ViewBag.OrderFollowEmail = String.IsNullOrEmpty(sortOrder) ? "em_desc" : "";
                ViewBag.OrderFollowAddUser = sortOrder == "add_asc" ? "add_desc" : "add_asc";
                ViewBag.OrderFollowRoleUser = sortOrder == "role_asc" ? "role_desc" : "role_asc";
                ViewBag.OrderFollowActiveUser = sortOrder == "ac_asc" ? "ac_desc" : "ac_asc";


                var users = await _user.GetAllAsync();
                switch (sortOrder)
                {
                    case "em_desc":
                        users = users.OrderByDescending(x => x.Email);
                        break;
                    case "add_desc":
                        users = users.OrderByDescending(x => x.Address);
                        break;
                    case "add_asc":
                        users = users.OrderBy(x => x.Address);
                        break;
                    case "role_desc":
                        users = users.OrderByDescending(x => x.Role);
                        break;
                    case "role_asc":
                        users = users.OrderBy(x => x.Role);
                        break;
                    case "ac_desc":
                        users = users.OrderByDescending(x => x.StatusUser);
                        break;
                    case "ac_asc":
                        users = users.OrderBy(x => x.StatusUser);
                        break;
                    default:
                        users = users.OrderBy(x => x.Email);
                        break;

                }

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(users.ToPagedList(pageNumber, pageSize));
            }
        }
        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,Email,PassWord,Address,Phone,Role,StatusUser,Image")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Image = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/ImageUser/" + FileName);
                        f.SaveAs(UploadPath);
                        user.Image = FileName;
                    }
                    _user.Create(user);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                return View(user);
            }
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _user.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FullName,Email,PassWord,Address,Phone,Role,StatusUser,Image")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/ImageUser/" + FileName);
                        f.SaveAs(UploadPath);
                        user.Image = FileName;
                    }
                    _user.Update(user);

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
        public async Task<ActionResult> Delete(int id)
        {
            await _user.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
