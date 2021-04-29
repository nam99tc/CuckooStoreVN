using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactServices _contact;
        public ContactsController(IContactServices contact)
        {
            _contact = contact;
        }
        // GET: Admin/Contacts
        public async Task<ActionResult> Index(int? page)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var contacts = await _contact.GetAllAsync();
            return View(contacts.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contact.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
    }
}
