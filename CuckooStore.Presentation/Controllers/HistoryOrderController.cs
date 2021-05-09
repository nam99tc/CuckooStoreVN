using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Controllers
{
    public class HistoryOrderController : Controller
    {
        private readonly IOrderServices _order;
        private readonly IUserServices _user;
        private readonly IProductServices _product;
        public HistoryOrderController(IOrderServices order, IUserServices user, IProductServices product)
        {
            _order = order;
            _user = user;
            _product = product;
        }
        // GET: OrderHistory
        public async Task<ActionResult> Index()
        {
            if (Session["iduser"] != null)
            {
                var user = await _user.GetByIdAsync(Session["iduser"]);
                var orders = user.Orders.ToList();
                return View(orders);
            }
            else
            {
                Cart cart = Session["Cart"] as Cart;
                return PartialView(cart.Items);
            }
        }

        public async Task<ActionResult> HuyDonHang(int id)
        {
            Order orders = await _order.GetByIdAsync(id);
            orders.Status = Status.DaHuy;
            await _order.UpdateAsync(orders);

            Cart cart = Session["Cart"] as Cart;

            foreach (var item in orders.OrderDetails)
            {
                Product pro = await _product.GetByIdAsync(item.Product.ProductID);
                pro.Quantity += item.Quantity;

                //if (pro != null)
                //{
                //    cart.Add(pro, item.Quantity);
                //}
                await _product.UpdateAsync(pro);
            }
            return PartialView("HistoryDetail");
        }

        public async Task<PartialViewResult> HistoryDetail(int id)
        {
            Order orders = await _order.GetByIdAsync(id);
            return PartialView(orders);
        }

        //Lịch sử đặt hàng
        public PartialViewResult _ChoXacNhan()
        {
            Cart cart = Session["Cart"] as Cart;
            if (Session["iduser"] == null)
            {
                return PartialView(cart.Items);
            }
            else
            {
                var user = _user.GetById(Session["iduser"]);
                var orders = user.Orders.Where(h => h.Status.ToString().Equals("ChoXacNhan")).ToList();
                return PartialView(orders);
            }
        }
        public PartialViewResult _DangGiao()
        {
            var user = _user.GetById(Session["iduser"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("DangGiao")).ToList();
            return PartialView(orders);
        }
        public PartialViewResult _DaNhan()
        {
            var user = _user.GetById(Session["iduser"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("DaNhan")).ToList();
            return PartialView(orders);
        }
        public PartialViewResult _DaHuy()
        {
            var user = _user.GetById(Session["iduser"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("DaHuy")).ToList();
            return PartialView(orders);
        }
    }
}