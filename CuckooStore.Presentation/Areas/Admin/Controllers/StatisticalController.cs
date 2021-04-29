using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ActionResult Index(IEnumerable<Order> order)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                if (order == null)
                {
                    var or = _order.GetAll();
                    decimal money = 0;
                    foreach (var item in or)
                    {
                        money += (decimal)item.Total_Money();
                    }
                    Session["Statistical"] = money;
                    return View(or);
                }
                return View(order);
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
                return RedirectToAction("Index", "Statistical");
            }
            else
            {
                DateTime start = DateTime.Parse(begindate);
                DateTime end = DateTime.Parse(enddate);
                var orders = _order.FindAll(filter: x => x.OrderDate >= start && x.OrderDate <= end);

                decimal money = 0;
                foreach (var item in orders)
                {
                    money += (decimal)item.Total_Money();
                }
                Session["Statistical"] = money;

                return RedirectToAction("Index", "Statistical",new { order = orders});
            }
        }
        public ActionResult StatiscalFollowOrder()
        {
            var list = _orderDetail.GetAll();
            var Listpro = list.GroupBy(l => l.Product)
                          .Select(lg =>
                            new ListPro {
                                Product = lg.Key,
                                Name = lg.First().Product.ProductName,
                                Image = lg.First().Product.Image,
                                TotalQty = lg.Sum(w => w.Quantity),
                                TotalMoney = lg.Sum(c=>c.Quantity * c.Product.UnitPrice).Value,
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