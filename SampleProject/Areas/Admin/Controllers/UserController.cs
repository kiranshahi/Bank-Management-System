using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        // GET: Admin/Default
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUserView()
        {
            var emp = objBs.UserBs.GetAll();
            return View(emp);
        }

        public ActionResult Details(string id)
        {
            var dep = objBs.UserBs.GetByID(id);
            return View(dep);
        }


        public ActionResult editView(string id)
        {
            var dep = objBs.UserBs.GetByID(id);
            TempData["Id"] = id;
            TempData.Keep();
            return View(dep);
        }

        public ActionResult edit(AspNetUser D)
        {
            string id = TempData["Id"].ToString();
            AspNetUser tbl = objBs.UserBs.GetByID(id);
            tbl.Email = D.Email;
            objBs.UserBs.Update(tbl);
            TempData["E"] = "Department Name Edited Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult deleteView(string id)
        {
            var dep = objBs.UserBs.GetByID(id);
            TempData["delId"] = id;
            return View(dep);
        }

        public ActionResult Delete(AspNetUser D)
        {
            string id = TempData["delId"].ToString();
            objBs.UserBs.Delete(id);
            TempData["D"] = "Department Record Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}