using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.Navigation.Models
{
    [Service(typeof(IFooterViewModel))]
    public class FooterViewModel:IFooterViewModel
    {
        public IFooter Footer { get; set; }
        public ISiteRoot SiteRoot { get; set; }
    }
}