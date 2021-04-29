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
                ViewBag.OrderFollowProduct = String.IsNullOrEmpty(sortOrder) ? "pro_desc" : "";
                ViewBag.OrderFollowUser = sortOrder == "user_asc" ? "user_desc" : "user_asc";
                ViewBag.OrderFollowTime = sortOrder == "time_asc" ? "time_desc" : "time_asc";

                var comments = await _comment.GetAllAsync();
                switch (sortOrder)
                {
                    case "pro_desc":
                        comments = comments.OrderByDescending(x => x.Product.ProductName);
                        break;
                    case "user_desc":
                        comments = comments.OrderByDescending(x => x.User.FullName);
                        break;
                    case "user_asc":
                        comments = comments.OrderBy(x => x.User.FullName);
                        break;
                    case "time_desc":
                        comments = comments.OrderByDescending(x => x.CommentDate);
                        break;
                    case "time_asc":
                        comments = comments.OrderBy(x => x.CommentDate);
                        break;
                    default:
                        comments = comments.OrderBy(x => x.Product.ProductName);
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
