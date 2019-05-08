using System.Collections.Generic;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
namespace EMAAR.ECM.Feature.Navigation.Models
{
    [Service(typeof(ISitemapViewModel))]
    public class SitemapViewModel : ISitemapViewModel
    {

        public List<KeyValuePair<INavigable, List<INavigable>>> SitemapItems { get; set; }
    }

}