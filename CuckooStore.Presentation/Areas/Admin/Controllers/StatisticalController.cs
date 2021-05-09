using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    //Thống kê
    public class StatisticalController : Controller
    {
        private readonly IOrderServices _order;
        private readonly IOrderDetailServices _orderDetail;
        private readonly IProductServices _product;
        public StatisticalController(IOrderServices order, IOrderDetailServices orderDetail, IProductServices product)
        {
            _order = order;
            _orderDetail = orderDetail;
            _product = product;
        }
        // GET: Admin/Statistical
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                if (Session["begin"] != null && Session["end"] != null)
                {
                    DateTime start = DateTime.Parse(Session["s"].ToString());
                    DateTime end = DateTime.Parse(Session["e"].ToString());
                    var orders = _order.FindAll(filter: x => DbFunctions.TruncateTime(x.OrderDate) >= DbFunctions.TruncateTime(start)
                                    && DbFunctions.TruncateTime(x.OrderDate) <= DbFunctions.TruncateTime(end) && x.Status == Status.DaNhan);
                    decimal money = 0;
                    foreach (var item in orders)
                    {
                        money += (decimal)item.Total_Money();
                    }
                    Session["Statistical"] = money;
                    return View(orders);
                }
                else
                {

                    var or = _order.FindAll(filter: x => x.Status == Status.DaNhan);
                    decimal money = 0;
                    foreach (var item in or)
                    {
                        money += (decimal)item.Total_Money();
                    }
                    Session["Statistical"] = money;
                    return View(or);
                }
            }
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string begindate = fc["begindate"];
            string enddate = fc["enddate"];
            if (begindate == "" || enddate == "")
            {
                Session["Statistical"] = 0;
                Session["begin"] = null;
                Session["end"] = null;
                return RedirectToAction("Index", "Statistical");
            }
            else
            {
                DateTime start = DateTime.Parse(begindate);
                DateTime end = DateTime.Parse(enddate);
                Session["s"] = start.Date;
                Session["e"] = end.Date;
                var orders = _order.FindAll(filter: x => DbFunctions.TruncateTime(x.OrderDate) >= DbFunctions.TruncateTime(start)
                && DbFunctions.TruncateTime(x.OrderDate) <= DbFunctions.TruncateTime(end) && x.Status == Status.DaNhan);

                decimal money = 0;
                foreach (var item in orders)
                {
                    money += (decimal)item.Total_Money();
                }
                Session["Statistical"] = money;
                Session["begin"] = start.ToString("dd/MM/yyyy");
                Session["end"] = end.ToString("dd/MM/yyyy");

                return RedirectToAction("Index");
            }
        }
        public ActionResult StatiscalFollowOrder()
        {
            var list = _orderDetail.FindAll(filter: x => x.Order.Status == Status.DaNhan);
            var Listpro = list.GroupBy(l => l.Product)
                          .Select(lg =>
                            new ListPro
                            {
                                Product = lg.Key,
                                Name = lg.First().Product.ProductName,
                                Image = lg.First().Product.Image,
                                TotalQty = lg.Sum(w => w.Quantity),
                                TotalMoney = lg.Sum(c => c.Quantity * c.Product.UnitPrice).Value,
                            });
            ViewBag.IMAGE = Listpro.Select(x => x.Image);
            ViewBag.QTY = Listpro.Select(x => x.TotalQty);
            return View(Listpro);
        }
        public class ListPro
        {
            public Product Product { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public int TotalQty { get; set; }
            public decimal TotalMoney { get; set; }
        }
    }
}