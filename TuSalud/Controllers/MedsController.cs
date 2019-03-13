using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuSalud.Controllers
{
    public class MedsController : Controller
    {
        [HttpGet]
        public ActionResult ShowInventory() {

            return View();
        }

        [HttpGet]
        public ActionResult PlaceOrder() {

            return View();
        }
        
    }
}