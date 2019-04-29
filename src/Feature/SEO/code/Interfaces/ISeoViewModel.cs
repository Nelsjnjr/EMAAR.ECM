using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Foundation.ECM.Base;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.SEO.Interfaces
{
    public interface ISeoViewModel
    {
         I_PageBase Pagebase { get; set; }
         ISiteRoot SiteRoot { get; set; }
    }
}
