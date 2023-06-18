using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
        [RoutePrefix("bill")]
        public class BillController : Controller
        {
            // GET: Bill
            [Route("new", Name = "B-Create")]
            public ActionResult Create()
            {
                return View();
            }
        }
}