using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tumbleweed.Models;

namespace Tumbleweed.Controllers
{
    public class ReportController : Controller
    {


        [HttpGet]
        public ActionResult List(string id)
        {
            WaitingList.WaitingListDataAccess waitingList = new WaitingList.WaitingListDataAccess();
            List<WaitingListModel> models = new List<WaitingListModel>();

            switch (id.ToLower())
            {
                case "alpha":
                    models = waitingList.GetWaitingListAlphabetical();
                    break;
                case "latest":
                    models = waitingList.GetWaitingListByTime();
                    break;
            }


            return View(models);

        }
    }
}