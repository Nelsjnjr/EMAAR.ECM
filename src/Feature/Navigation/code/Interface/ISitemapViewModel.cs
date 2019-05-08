using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAAR.ECM.Foundation.ORM.Models;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Fields;

namespace EMAAR.ECM.Feature.Navigation.Interface
{
    public interface ISitemapViewModel
    {
        List<KeyValuePair<INavigable, List<INavigable>>> SitemapItems { get; set; }

    }
}
