using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using PagedList;
using System;
using System.Linq;
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
        public async Task<ActionResult> Index(int? page, string sortOrder)
        {
            if (Session["iduserAdmin"] == null)
            {
                return RedirectToAction("Login", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                //sap xep
                ViewBag.OrderFollowTimeContact = String.IsNullOrEmpty(sortOrder) ? "time_asc" : "";
                ViewBag.OrderFollowEmailContact = sortOrder == "email_asc" ? "email_desc" : "email_asc";
                ViewBag.OrderFollowNameContact = sortOrder == "name_asc" ? "name_desc" : "name_asc";

                var contacts = await _contact.GetAllAsync();
                switch (sortOrder)
                {
                    case "time_asc":
                        contacts = contacts.OrderBy(x => x.Date);
                        break;
                    case "email_desc":
                        contacts = contacts.OrderByDescending(x => x.Email);
                        break;
                    case "email_asc":
                        contacts = contacts.OrderBy(x => x.Email);
                        break;
                    case "name_desc":
                        contacts = contacts.OrderByDescending(x => x.Name);
                        break;
                    case "name_asc":
                        contacts = contacts.OrderBy(x => x.Name);
                        break;
                    default:
                        contacts = contacts.OrderByDescending(x => x.Date);
                        break;
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(contacts.ToPagedList(pageNumber, pageSize));
            }
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
