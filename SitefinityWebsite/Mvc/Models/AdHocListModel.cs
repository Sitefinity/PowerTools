using System;
using System.Linq;

namespace SitefinityWebApp.Mvc.Models
{
    public class AdHocListModel
    {
        public string ListTitle
        {
            get;
            set;
        }

        public string ListType
        {
            get;
            set;
        }

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

        public const string NumbersListType = "numbers";
        public const string BulletsListType = "bullets";
        private string[] listItems = new string[0];
    }
}