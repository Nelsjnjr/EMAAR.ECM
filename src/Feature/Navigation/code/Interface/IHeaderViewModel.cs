using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.Navigation.Interface
{
    public interface IHeaderViewModel
    {
        IHeader Header { get; set; }
        ILogo Logos { get; set; }
        string SearchIcon { get; set; }
        string CloseIcon { get; set; }
        string HomeCss { get; set; }
    }
}
