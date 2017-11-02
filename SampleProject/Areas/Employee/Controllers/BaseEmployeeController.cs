using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace SampleProject.Areas.Employee.Controllers
{
    [Authorize(Roles ="Admin,Employee")]
    public class BaseEmployeeController : Controller
    {
        // GET: User/BaseUser
        protected EmployeeBs objemp;
        public BaseEmployeeController()
        {
            objemp = new EmployeeBs();
        }
    }
}