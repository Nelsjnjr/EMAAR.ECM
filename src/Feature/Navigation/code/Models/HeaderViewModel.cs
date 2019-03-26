using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Sitecore.Foundation.DependencyInjection;

namespace EMAAR.ECM.Feature.Navigation.Models
{
    [Service(typeof(IHeaderViewModel))]
    public class HeaderViewModel : IHeaderViewModel
    {
        public IHeader Header { get; set; }
        public ILogo Logos { get; set; }
        public string SearchIcon { get; set; }
        public string CloseIcon { get; set; }
        public string HomeCss { get; set; }
    }
}