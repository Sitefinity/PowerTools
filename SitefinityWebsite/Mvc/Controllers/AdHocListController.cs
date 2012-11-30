using System;
using System.ComponentModel;
using System.Globalization;
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

        [TypeConverter(typeof(StringStringArrayConverter))]
        public string[] ListItems
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
            return View(new AdHocListModel() { 
                ListTitle = this.ListTitle,
                ListType = this.ListType
            });
        }

        private string listTitle = "My list";
        private string listType = AdHocListModel.NumbersListType;
        private string[] listItems = new string[] { "Item 1", "Item 2", "Item 3" };
    }

}