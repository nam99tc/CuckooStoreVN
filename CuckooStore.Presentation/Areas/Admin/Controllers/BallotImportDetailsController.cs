using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CuckooStore.BusinessLogicLayer;
using CuckooStore.DataAccessLayer;
using CuckooStore.Models;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class BallotImportDetailsController : Controller
    {
        private readonly IProductServices _product;
        private readonly IBallotImportServices _ballotImport;
        private readonly IBallotImportDetailServices _ballotImportDetail;
        public BallotImportDetailsController(IProductServices product, IBallotImportServices ballotImport, IBallotImportDetailServices ballotImportDetail)
        {
            _product = product;
            _ballotImport = ballotImport;
            _ballotImportDetail = ballotImportDetail;
        }

        // GET: Admin/BallotImportDetails
        public ActionResult Index(int? id)
        {
            var ballotImport = _ballotImport.GetById(id);
            Session["idBallot"] = id;
            return View(ballotImport);
        }

        // GET: Admin/BallotImportDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotImportDetail ballotImportDetail = _ballotImportDetail.GetById(id);
            if (ballotImportDetail == null)
            {
                return HttpNotFound();
            }
            return View(ballotImportDetail);
        }

        // GET: Admin/BallotImportDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(_product.GetAll(), "ProductID", "ProductName");
            return View();
        }

        // POST: Admin/BallotImportDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BallotImportDetailID,ProductID,BallotImportID,Quantity")] BallotImportDetail ballotImportDetail)
        {
            if (ModelState.IsValid)
            {
                ballotImportDetail.BallotImportID = (int)Session["idBallot"];
                _ballotImportDetail.Create(ballotImportDetail);
                return RedirectToAction("Index", new { id = (int)Session["idBallot"] });
            }
            ViewBag.ProductID = new SelectList(_product.GetAll(), "ProductID", "ProductName", ballotImportDetail.ProductID);
            return RedirectToAction("Index",new { id = (int)Session["idBallot"] });
        }

        // GET: Admin/BallotImportDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BallotImportDetail ballotImportDetail = _ballotImportDetail.GetById(id);
            if (ballotImportDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(_product.GetAll(), "ProductID", "ProductName", ballotImportDetail.ProductID);
            return View(ballotImportDetail);
        }

        // POST: Admin/BallotImportDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BallotImportDetailID,ProductID,BallotImportID,Quantity")] BallotImportDetail ballotImportDetail)
        {
            if (ModelState.IsValid)
            {
                ballotImportDetail.BallotImportID = (int)Session["idBallot"];
                _ballotImportDetail.Update(ballotImportDetail);
                return RedirectToAction("Index", new { id = (int)Session["idBallot"] });
            }
            ViewBag.ProductID = new SelectList(_product.GetAll(), "ProductID", "ProductName", ballotImportDetail.ProductID);
            return RedirectToAction("Index", new { id = (int)Session["idBallot"] });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _ballotImportDetail.DeleteAsync(id);

            return RedirectToAction("Index", new { id = (int)Session["idBallot"] });
        }
    }
}
