using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.DependencyInjection;

namespace EMAAR.ECM.Feature.Navigation
{
    [Service(typeof(IDemo))]
    public class DemoClass:IDemo
    {
        public void Get()
        {

        }
    }
}