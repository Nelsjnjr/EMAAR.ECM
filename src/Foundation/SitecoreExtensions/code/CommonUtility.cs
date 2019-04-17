using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMAAR.ECM.Foundation.SitecoreExtensions
{
    public static class CommonUtility
    {
        public static string RemoveBreakTags(this string value)
        {
            return value.Replace("<br><br>", "<p></p>")
                .Replace("<br /><br />", "<p></p>")
                .Replace("<br>", "<p></p>")
                .Replace("<br />", "<p></p>")
                .Replace("{Add Here}",String.Empty);
        }
    }
}