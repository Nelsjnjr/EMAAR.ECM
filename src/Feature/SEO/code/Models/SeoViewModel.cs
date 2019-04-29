using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMAAR.ECM.Feature.SEO.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Foundation.ECM.Base;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.SEO.Models
{
    [Service(typeof(ISeoViewModel))]
    public class SeoViewModel:ISeoViewModel
    {
        public I_PageBase Pagebase { get; set; }
        public ISiteRoot SiteRoot { get; set; }
    }
}