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
    public class ProductsController : Controller
    {
        private readonly IProductServices _product;
        private readonly ICategoryServices _category;
        public ProductsController(IProductServices product, ICategoryServices category)
        {
            _product = product;
            _category = category;
        }

        // GET: Admin/Products
        public async Task<ActionResult> Index(int? page, string sortOrder)
        {
            //sap xep
            ViewBag.OrderFollowCategory = String.IsNullOrEmpty(sortOrder) ? "cat_desc" : "";
            ViewBag.OrderFollowNamePro = sortOrder == "pro_asc" ? "pro_desc" : "pro_asc";
            ViewBag.OrderFollowColor = sortOrder == "color_asc" ? "color_desc" : "color_asc";
            ViewBag.OrderFollowPrice = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.OrderFollowQty = sortOrder == "qty_asc" ? "qty_desc" : "qty_asc";

            var products = await _product.GetAllAsync();
            switch (sortOrder)
            {
                case "cat_desc":
                    products = products.OrderByDescending(x => x.Category.CategoryName);
                    break;
                case "pro_desc":
                    products = products.OrderByDescending(x => x.ProductName);
                    break;
                case "pro_asc":
                    products = products.OrderBy(x => x.ProductName);
                    break;
                case "color_desc":
                    products = products.OrderByDescending(x => x.MauSac);
                    break;
                case "color_asc":
                    products = products.OrderBy(x => x.MauSac);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(x => x.Price);
                    break;
                case "price_asc":
                    products = products.OrderBy(x => x.Price);
                    break;
                case "qty_desc":
                    products = products.OrderByDescending(x => x.Quantity);
                    break;
                case "qty_asc":
                    products = products.OrderBy(x => x.Quantity);
                    break;
                default:
                    products = products.OrderBy(x => x.Category.CategoryName);
                    break;
            }

            //phan trang
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Image,BaoHanh,MauSac,Price,UnitPrice,Description,Quantity,CategoryID")] Product product)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/Image/" + FileName);
                    f.SaveAs(UploadPath);
                    product.Image = FileName;
                }
                _product.Create(product);
                //}
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName");
                return View(product);
            }
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _product.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName");
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Image,BaoHanh,MauSac,Price,UnitPrice,Description,Quantity,CategoryID")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Image/" + FileName);
                        f.SaveAs(UploadPath);
                        product.Image = FileName;
                    }
                    _product.Update(product);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi sửa dữ liệu" + ex.Message;
                ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName");
                return View(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _product.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
