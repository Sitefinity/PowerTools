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

        public const string NumbersListType = "numbers";
        public const string BulletsListType = "bullets";
    }
}