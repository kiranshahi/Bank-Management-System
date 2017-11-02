using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace SampleProject.Areas.Admin.Controllers
{
    public class ChequeCancellationController : BaseAdminController
    {
        // GET: Admin/ChequeCancellation
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblChqCancellation tblchqcan)
        {
            if (ModelState.IsValid)
            {
                objBs.ChqCancellationBs.Insert(tblchqcan);
                TempData["ChqCanMsg"] = "Cheque Cancelled Successfully";
                return RedirectToAction("Index");
            }
            return View(tblchqcan);
        }

    }
}