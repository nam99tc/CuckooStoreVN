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
        public async Task<ActionResult> Index(int? page)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var users = await _user.GetAllAsync();
            return View(users.ToPagedList(pageNumber, pageSize));
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
