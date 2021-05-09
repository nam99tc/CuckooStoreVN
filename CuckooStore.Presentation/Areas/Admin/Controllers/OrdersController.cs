using CuckooStore.BusinessLogicLayer;
using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderServices _order;
        private readonly IOrderDetailServices _orderDetail;
        private readonly ICouponServices _coupon;
        private readonly IUserServices _user;
        public OrdersController(IOrderServices order, IOrderDetailServices orderDetail, IUserServices user, ICouponServices coupon)
        {
            _order = order;
            _orderDetail = orderDetail;
            _user = user;
            _coupon = coupon;
        }
        // GET: Admin/Orders
        public async Task<ActionResult> Index(int? page, string sortOrder)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                //sap xep
                ViewBag.OrderFolloworderdate = String.IsNullOrEmpty(sortOrder) ? "dt_asc" : "";
                ViewBag.OrderFollowToadd = sortOrder == "add_asc" ? "add_desc" : "add_asc";
                ViewBag.OrderFollowToname = sortOrder == "name_asc" ? "name_desc" : "name_asc";
                ViewBag.OrderFollowstatusor = sortOrder == "stt_asc" ? "stt_desc" : "stt_asc";


                var orders = await _order.GetAllAsync();
                switch (sortOrder)
                {
                    case "dt_asc":
                        orders = orders.OrderBy(x => x.OrderDate);
                        break;
                    case "add_desc":
                        orders = orders.OrderByDescending(x => x.ToAddr);
                        break;
                    case "add_asc":
                        orders = orders.OrderBy(x => x.ToAddr);
                        break;
                    case "name_desc":
                        orders = orders.OrderByDescending(x => x.ToName);
                        break;
                    case "name_asc":
                        orders = orders.OrderBy(x => x.ToName);
                        break;
                    case "stt_desc":
                        orders = orders.OrderByDescending(x => x.Status);
                        break;
                    case "stt_asc":
                        orders = orders.OrderBy(x => x.Status);
                        break;
                    default:
                        orders = orders.OrderByDescending(x => x.OrderDate);
                        break;
                }
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(orders.ToPagedList(pageNumber, pageSize));
            }
        }

        public async Task<ActionResult> IndexDetails(int id)
        {
            var order = await _order.GetByIdAsync(id);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _order.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code = new SelectList(_coupon.GetAll(), "Code", "Description", order.Code);
            ViewBag.UserID = new SelectList(_user.GetAll(), "UserID", "FullName", order.UserID);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,Status,ToName,ToAddr,ToPhone,UserID,Code")] Order order)
        {
            if (ModelState.IsValid)
            {
                _order.Update(order);
                return RedirectToAction("Index");
            }
            ViewBag.Code = new SelectList(_coupon.GetAll(), "Code", "Description", order.Code);
            ViewBag.UserID = new SelectList(_user.GetAll(), "UserID", "FullName", order.UserID);
            return View(order);
        }
    }
}
