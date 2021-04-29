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

            if (ModelState.IsValid)
            {
                if (quantity > pro.Quantity)
                {
                    Session["ErrQuantity"] = "Số lượng trong kho không đủ!!";
                }
                else
                {
                    Session["ErrQuantity"] = null;
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
            }
            return RedirectToAction("Details", "Home",new { id = pro.ProductID });
        }
        //Trang gio hang
        public ActionResult ShowToCart()
        {
            Cart cart = Session["Cart"] as Cart;
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
                    var pro = db.Products.FirstOrDefault(x => x.ProductID == item._product.ProductID);
                    if (Convert.ToInt32(quantities[dem]) > pro.Quantity)
                    {
                        Session["err"] = pro.ProductName+" không đủ " + Convert.ToInt32(quantities[dem]) +" trong kho!!";
                        Session["proErr"] = pro.ProductID;
                        return RedirectToAction("ShowToCart", "Cart");
                    }
                    item._quatity = Convert.ToInt32(quantities[dem]);
                    dem++;
                    Session["err"] = null;
                    Session["proErr"] = null;
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