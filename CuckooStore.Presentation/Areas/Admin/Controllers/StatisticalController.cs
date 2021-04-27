using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    //Thống kê
    public class StatisticalController : Controller
    {
        private readonly IOrderServices _order;
        private readonly IOrderDetailServices _orderDetail;
        public StatisticalController(IOrderServices order, IOrderDetailServices orderDetail)
        {
            _order = order;
            _orderDetail = orderDetail;
        }
        // GET: Admin/Statistical
        [HttpGet]
        public ActionResult Index(IEnumerable<Order> order)
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
            return View();
        }
    }
}