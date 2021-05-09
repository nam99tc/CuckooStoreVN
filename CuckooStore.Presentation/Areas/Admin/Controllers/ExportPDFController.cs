using CuckooStore.BusinessLogicLayer;
using Rotativa;
using System.Web.Mvc;

namespace CuckooStore.Presentation.Areas.Admin.Controllers
{
    public class ExportPDFController : Controller
    {
        private readonly IOrderDetailServices _orderDetailServices;
        private readonly IOrderServices _order;
        public ExportPDFController(IOrderDetailServices orderDetailServices, IOrderServices order)
        {
            _order = order;
            _orderDetailServices = orderDetailServices;
        }
        // GET: Admin/ExportPDF
        public ActionResult PrintPdf(int id)
        {
            return new ActionAsPdf("Print",new { id = id });
        }

        public ActionResult Print(int id)
        {
            var or = _order.GetById(id);
            return View("Print", or);
        }
    }
}