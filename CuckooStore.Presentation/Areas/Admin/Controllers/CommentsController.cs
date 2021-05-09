using CuckooStore.BusinessLogicLayer;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentServices _comment;
        public CommentsController(ICommentServices comment)
        {
            _comment = comment;
        }
        // GET: Admin/Comments
        public async Task<ActionResult> Index(int? page, string sortOrder)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                //sap xep
                ViewBag.OrderFollowTime = String.IsNullOrEmpty(sortOrder) ? "time_asc" : "";
                ViewBag.OrderFollowUser = sortOrder == "user_asc" ? "user_desc" : "user_asc";
                ViewBag.OrderFollowProduct = sortOrder == "pro_asc" ? "pro_desc" : "pro_asc";

                var comments = await _comment.GetAllAsync();
                switch (sortOrder)
                {
                    case "time_asc":
                        comments = comments.OrderBy(x => x.CommentDate);
                        break;
                    case "user_desc":
                        comments = comments.OrderByDescending(x => x.User.FullName);
                        break;
                    case "user_asc":
                        comments = comments.OrderBy(x => x.User.FullName);
                        break;
                    case "pro_desc":
                        comments = comments.OrderByDescending(x => x.Product.ProductName);
                        break;
                    case "pro_asc":
                        comments = comments.OrderBy(x => x.Product.ProductName);
                        break;
                    default:
                        comments = comments.OrderByDescending(x => x.CommentDate);
                        break;
                }

                //phan trang
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(comments.ToPagedList(pageNumber, pageSize));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _comment.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
