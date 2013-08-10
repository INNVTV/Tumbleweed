using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tumbleweed.Models;

namespace Tumbleweed.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SignupModel());
        }

        [HttpPost]
        public ActionResult Index(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                // Insert email into the waiting list on Azure Table Service
                WaitingList.WaitingListDataAccess waitingList = new WaitingList.WaitingListDataAccess();
                waitingList.AddToWaitingList(model.Email);
            }
            else
            {
                return View(model);
            }


            return RedirectToAction("Success");
        }

        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
    }
}