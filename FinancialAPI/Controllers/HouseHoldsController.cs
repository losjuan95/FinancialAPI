using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAPI.Controllers
{
    public class HouseHoldsController : Controller
    {
        // GET: HouseHolds
        public ActionResult Index()
        {
            return View();
        }
    }
}