using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        public string ListType
        {
            get
            {
                return this.listType;
            }
            set
            {
                this.listType = value;
            }
        }

        public string ListItems
        {
            get
            {
                return this.listItems;
            }
            set
            {
                this.listItems = value;
            }
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var model = new AdHocListModel()
            {
                ListTitle = this.ListTitle,
                ListType = this.ListType
            };
            if (!string.IsNullOrEmpty(this.ListItems))
                model.ListItems = serializer.Deserialize<string[]>(this.ListItems);

            return View(model);
        }

        private string listTitle;
        private string listType;
        private string listItems;
    }

}