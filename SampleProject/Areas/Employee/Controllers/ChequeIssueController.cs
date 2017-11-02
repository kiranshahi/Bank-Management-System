using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SampleProject.Areas.Employee.Controllers
{
    public class ChequeIssueController : BaseEmployeeController
    {
        // GET: Employee/ChequeIssue
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult getchqStartNum(tblChqIssue tblci)
        {
            DataTable dt = objemp.ChqIssueBs.showChqStartNo();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal a = Convert.ToDecimal(dt.Rows[i][5].ToString());
                    decimal b = a + 1;
                    tblci.chqStartNo = b;
                }
            }
            else
            {
                tblci.chqStartNo = 1;
            }
            return Json(tblci, JsonRequestBehavior.AllowGet);
        }
        BMS2Entities _db = new BMS2Entities();
        public ActionResult getBychqIdForCheque(string custname)
        {
            //var chq = _db.tblchqNoes.Where(x => x.custName == custname).Select(k => new { k.chqNo, k.custName, k.status }).ToList();
            var chq = objemp.ChqIssueBs.GetChqDetailsByCustName(custname);
            return Json(chq, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblChqIssue tblchqissue)
        {
            if (ModelState.IsValid)
            {
                objemp.ChqIssueBs.Insert(tblchqissue);
                TempData["Create"] = "Cheque Issued Successfully";
                return RedirectToAction("Index");
            }
            return View(tblchqissue);
        }

    }
}