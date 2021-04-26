using CuckooStore.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}