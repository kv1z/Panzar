using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Panzar.Services;
using Panzar.Wrappers;

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

            ViewData["Id"] = SearchService.Instance.Search(query);
            ViewData["Title"] = string.Format("{0} - Поиск", query);
            return View("Search");
        }

        [HttpGet]
        public ActionResult IsComplete(Guid id)
        {
            var result = SearchService.Instance.GetUsersResult(id);

            return Json(result.IsComplete ? 1 : 0, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Result(Guid id)
        {
            var result = SearchService.Instance.GetUsersResult(id);

            return PartialView("_SearchResultPartial", result.Result.ToList());
        }
    }
}
