using BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Areas.Admin.Controllers
{
    public class LoanController : BaseAdminController
    {
        // GET: Admin/Loan
        public ActionResult CreateLoanType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoanType(tblLoanType tblloantype)
        {
            if (ModelState.IsValid)
            {
                objBs.LoanTypeBs.Insert(tblloantype);
                TempData["LoantypeInsertMsg"] = "Loan Type Created Successfully";
                return RedirectToAction("CreateLoanType");
            }
            return View(tblloantype);
        }

        public ActionResult ViewLoanType()
        {
            var loantype = objBs.LoanTypeBs.GetAll();
            return Json(loantype, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IssueLoan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IssueLoan(tblLoan tblloan)
        {
            if (ModelState.IsValid)
            {
                objBs.LoanBs.Insert(tblloan);
                TempData["LoantypeInsertMsg"] = "Loan Issued Successfully";
                return RedirectToAction("IssueLoan");
            }
            return View(tblloan);
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

        public ActionResult loadLoanType()
        {
            var loadLoanType = objBs.LoanTypeBs.GetAll();
            return Json(loadLoanType, JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadInterestRateByLoanType(int Id)
        {
            var loadInterestRateByLoanType = objBs.LoanTypeBs.GetByID(Id);
            return Json(loadInterestRateByLoanType, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoanDetails()
        {
            return View();
        }
        
    }
}