using CuckooStore.BusinessLogicLayer;
using CuckooStore.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class BallotImportsController : Controller
    {
        private readonly IProductServices _product;
        private readonly IBallotImportServices _ballotImport;
        public BallotImportsController(IProductServices product, IBallotImportServices ballotImport)
        {
            _product = product;
            _ballotImport = ballotImport;
        }

        // GET: Admin/BallotImports
        public async Task<ActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var ballots = await _ballotImport.GetAllAsync();
            return View(ballots.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/BallotImports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BallotImports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BallotImportID,NguoiNhan,FromAdd,Kho,NgayNhap")] BallotImport ballotImport)
        {
            if (ModelState.IsValid)
            {
                ballotImport.NgayNhap = DateTime.Now.Date;
                _ballotImport.Create(ballotImport);
                return RedirectToAction("Index");
            }

            return View(ballotImport);
        }

        // GET: Admin/BallotImports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotImport ballotImport = _ballotImport.GetById(id);
            if (ballotImport == null)
            {
                return HttpNotFound();
            }
            return View(ballotImport);
        }

        // POST: Admin/BallotImports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BallotImportID,NguoiNhan,FromAdd,Kho,NgayNhap")] BallotImport ballotImport)
        {
            if (ModelState.IsValid)
            {
                _ballotImport.Update(ballotImport);
                return RedirectToAction("Index");
            }
            return View(ballotImport);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _ballotImport.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
