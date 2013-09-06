using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Panzar.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                ViewData["Message"] = "ищем пустоту?";
                return View();
            }

            ViewData["Title"] = string.Format("{0} - Поиск", query);
            return View("Search");
        }
    }
}
