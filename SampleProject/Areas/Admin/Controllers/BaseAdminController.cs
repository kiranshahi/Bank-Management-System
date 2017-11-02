using System;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BaseAdminController : Controller
    {
        // GET: Admin/BaseAdmin
        protected AdminBs objBs;
        public BaseAdminController()
        {
            objBs = new AdminBs();
        }
    }
}