using CuckooStore.DataAccessLayer;
using CuckooStore.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Controllers
{
    public class CartController : Controller
    {
        CuckooDBcontext db = new CuckooDBcontext();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        [HttpPost]
        public ActionResult AddToCart(FormCollection fc)
        {
            // insert single CartItem in Cart.
            int id = Convert.ToInt32(fc["id"]);
            int quantity = Convert.ToInt32(fc["quantity"]);

            var pro = db.Products.FirstOrDefault(x => x.ProductID == id);
            //check order-detail
            if (pro != null)
            {
                GetCart().Add(pro, quantity);
            }
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                Session["value"] = 0;

            }
            else
            {
                Session["value"] = cart.Items.Count();

            }
            return RedirectToAction("ShowToCart", "Cart");
        }
        //Trang gio hang
        public ActionResult ShowToCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart.Items.Count() <= 0)
            {
                return PartialView("EmtyCart");
            }
            return View(cart);
        }
        
        //View Icon Cart
        public PartialViewResult ViewCart()
        {
            Cart cart = Session["Cart"] as Cart;
            return PartialView(cart);
        }

        //Updatequantity
        public ActionResult UpdateQuantityCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            if (Request.Form["update"] != null)
            {
                string[] quantities = form.GetValues("quantity");
                int dem = 0;
                foreach (var item in cart.Items)
                {
                    item._quatity = Convert.ToInt32(quantities[dem]);
                    dem++;
                }
            }
            if (cart == null)
            {
                return PartialView("EmtyCart");
            }
            return RedirectToAction("ShowToCart", "Cart");
        }

        //Remove cart item
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_Cart(id);
            Session["value"] = (int)Session["value"] - 1;
            if (cart == null)
            {
                return PartialView("EmtyCart");
            }
            return RedirectToAction("ShowToCart", "Cart");
        }
    }
}