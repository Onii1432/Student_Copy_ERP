using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebApp.Controllers
{
    public class ItemMasterJWmvcController : Controller
    {
        // GET: ItemMasterJW
        public ActionResult ItemMasterJW()
        {
            LogInfo.LogDetailToFile("ItemMasterJWmvcController-ItemMasterJW Action(httpget)- Start");

            LogInfo.LogDetailToFile("ItemMasterJW - Item Master JW View Loaded");

            LogInfo.LogDetailToFile("ItemMasterJWmvcController-ItemMasterJW Action(httpget)- Start-End");

            return View();
        }
    }
}

