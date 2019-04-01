using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.SEO.Interfaces
{
    public interface ISeoRepository
    {
        ISiteRoot GetSEO();
    }
}
