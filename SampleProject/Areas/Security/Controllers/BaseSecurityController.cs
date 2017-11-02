using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class BaseSecurityController : Controller
    {
        // GET: Security/BaseSecurity
        protected SecurityBs objBs;
        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}