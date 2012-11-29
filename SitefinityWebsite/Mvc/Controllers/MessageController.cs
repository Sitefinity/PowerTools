using System;
using System.Linq;
using System.Web.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Message", SectionName = "MVC tools", Title = "Message")]
    public class MessageController : Controller
    {
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public ActionResult Index()
        {
            return View(new MessageModel() { Message = this.Message });
        }

        private string message = "Hello world!";
    }
}