using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    public class AdHocListDesignerController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Styles = new List<IHtmlString>();
            this.ViewBag.Scripts = new List<IHtmlString>();

            return View();
        }
    }
}