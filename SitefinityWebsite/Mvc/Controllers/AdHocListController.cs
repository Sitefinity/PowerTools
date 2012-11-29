using System;
using System.Linq;
using System.Web.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "AdHocList", SectionName = "MVC tools", Title = "AdHoc List")]
    public class AdHocListController : Controller
    {
        public string ListTitle
        {
            get
            {
                return this.listTitle;
            }
            set
            {
                this.listTitle = value;
            }
        }

        public ActionResult Index()
        {
            return View(new AdHocListModel() { ListTitle = this.ListTitle });
        }

        private string listTitle = "My list";
    }
}