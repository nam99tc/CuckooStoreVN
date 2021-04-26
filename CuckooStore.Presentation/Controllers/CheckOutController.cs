using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly IOrderServices _orderServices;
        private readonly ICouponServices _couponServices;
        private readonly IProductServices _productServices;
        private readonly IUserServices _userServices;
        private readonly ICheckOutServices _checkOutServices;

        public CheckOutController(
            IOrderDetailServices orderDetailServices,
            IOrderServices orderServices,
            ICouponServices couponServices,
            IProductServices productServices,
            IUserServices userServices,
            ICheckOutServices checkOutServices)
        {
            _orderDetailServices = orderDetailServices;
            _orderServices = orderServices;
            _couponServices = couponServices;
            _productServices = productServices;
            _userServices = userServices;
            _checkOutServices = checkOutServices;
        }
        [HttpGet]
        public ActionResult CheckOut(string couponCode)
        {
            Cart cart = Session["Cart"] as Cart;
            if (couponCode != null)
            {
                Session["Codee"] = null;
                Session["Codee"] = couponCode;
            }
            if (Session["Codee"] != null)
            {
                var coupon = _couponServices.GetById(Session["Codee"]);
                if (coupon != null)
                {
                    decimal total = (decimal)cart.Total_Money();
                    total -= (total * coupon.Discount) / 100;

                    ViewBag.GrandTotal = total.ToString("#,###");
                    return View(cart);
                }
                else
                {
                    ViewBag.errormg = "Mã giảm giá đã hết hạn hoặc không tồn tại!";
                    decimal total = (decimal)cart.Total_Money();

                    ViewBag.GrandTotal = total.ToString("#,###");
                    return View(cart);
                }
            }
            else
            {
                decimal total = (decimal)cart.Total_Money();

                ViewBag.GrandTotal = total.ToString("#,###");
                return View(cart);
            }
        }
        //Check out
        [HttpPost]
        public ActionResult CheckOut(FormCollection fc)
        {
            Cart cart = Session["Cart"] as Cart;

            var order = new Order();
            string name = fc["name"];
            string phone = fc["phone"];
            string address = fc["address"];
            string email = fc["email"];
            var coupon = _couponServices.GetById(Session["Codee"]);

            var userId = Session["iduser"];
            User user = _userServices.GetById(userId);

            if (coupon == null)
            {
                coupon = _couponServices.GetById("khonggiamgia");
            }
            if (Session["iduser"] == null)
            {
                order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Status = Status.ChoXacNhan,
                    ToAddr = address,
                    ToName = name,
                    ToPhone = phone,
                    Coupon = coupon,
                };
            }
            else
            {
                order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Status = Status.ChoXacNhan,
                    ToAddr = address,
                    ToName = name,
                    ToPhone = phone,
                    Coupon = coupon,
                    User = user,
                };
            }
            // add orderDetail
            List<OrderDetail> ord = new List<OrderDetail>();
            foreach (var item in cart.Items)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderID = order.OrderID,
                    ProductID = item._product.ProductID,
                    Quantity = item._quatity,
                };
                ord.Add(orderDetail);
            }
            _checkOutServices.CheckOut(order,ord);
            Session["Cart"] = null;
            Session["Codee"] = null;
            Session["Value"] = null;
            return RedirectToAction("CheckOutSuccess");
        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
    }
}