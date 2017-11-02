using BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Areas.Employee.Controllers
{
    public class BankAccountController : BaseEmployeeController
    {
        BMS2Entities _db = new BMS2Entities();
        public ActionResult Index()
        {
            ViewBag.Acttype = new SelectList(objemp.ActtypeBs.GetAll(), "acttype", "acttype");
            loadaccNo();
            BOL.tblOpenAct model = new BOL.tblOpenAct();
            model.acctNo = ViewBag.ActNum;
            //model.IdPrimarykey = "10";
            return this.View(model);
        
        }

        private void loadaccNo()
        {
            DataTable dt1 = objemp.OpenActBs.showaccno();
            if (dt1.Rows.Count > 0)
            {
                string a = "101-";
                int b = Convert.ToInt32(dt1.Rows[0][0].ToString());
                int c = 1;
                int d = b + c;
                ViewBag.ActNum = a + d.ToString();
            }

            else
            {
                ViewBag.ActNum = "101-" + "1";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblOpenAct op)
        {
            if (ModelState.IsValid)
            {
               objemp.OpenActBs.Insert(op);
                TempData["msg"] = "Customer Account Created Successfully";
                return RedirectToAction("Index");


        }                
                     return View(op);

    }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        public ActionResult Deposit()
        {
            return View();
        }

        public ActionResult getById(string id)
        {
            //DataTable dt = objemp.DepositBs.showcurrbalanceByaccno(id);
            //if (dt.Rows.Count>0)
            //{
            var emp = objemp.DepositBs.GetByID(id);
            return Json(emp, JsonRequestBehavior.AllowGet);
            //}

            //else
            //{
            //    return RedirectToAction("Deposit");
            //}
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(tblDeposit tbldepo)
        {
            if (ModelState.IsValid)
            {
                objemp.DepositBs.Insert(tbldepo);
                TempData["msg"] = "Transaction Saved Successfully";
                return RedirectToAction("Deposit");
            }
            return View(tbldepo);
        }

        public ActionResult Withdrawal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdrawal(tblWithdrawal tblwith)
        {

            if (ModelState.IsValid)
            {
                objemp.WithdrawalBs.Insert(tblwith);
                TempData["msg"] = "Transaction Saved Successfully";
                return RedirectToAction("Withdrawal");
            }
            return View(tblwith);
        }

        public ActionResult getchqStatus(decimal chqno)
        {
            //DataTable dt = objemp.WithdrawalBs.GetChqStatus(chqno);
            //if (dt.Rows.Count>0)
            //{
            //    TempData["chqstatus"] = "Entered Cheque Number Is Cancelled";
            //}
            //return RedirectToAction("Withdrawal");

            var chqstatus = objemp.WithdrawalBs.GetChqStatus(chqno);
            return Json(chqstatus, JsonRequestBehavior.AllowGet);
        }

    }
}