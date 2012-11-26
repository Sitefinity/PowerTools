using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Pages.Model;

namespace Sitefinity.PowerTools.Test.RootTemplates.Mocks
{
    public class PageTemplateMock : IPageTemplate
    {
        public string Key
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public IPageTemplate ParentTemplate
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public IEnumerable<ControlData> Controls
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public Guid Id
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public int LastControlId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ExternalPage
        {
            get;
            set;
        }

        public bool IncludeScriptManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPersonalized
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string MasterPage
        {
            get;
            set;
        }

        public Guid PersonalizationMasterId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Guid PersonalizationSegmentId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Theme
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

        public IEnumerable<PresentationData> Presentation
        {
            get 
            {
                if (this.presentation == null)
                    this.presentation = new List<PresentationData>();
                return this.presentation;
            }
        }

        private List<PresentationData> presentation;

    }
}
