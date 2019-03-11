using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMAAR.ECM.Feature.Navigation;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Feature;
using Glass.Mapper.Sc.Web.Mvc;

namespace EMAAR.ECM.Feature.Navigation.Controllers
{
    public class DemoController : Controller
    {
        private readonly IMvcContext _sitecoreContext;
        private readonly IDemo _demo;

        public DemoController(IMvcContext mvcContext, IDemo demo)
        {

            _sitecoreContext = mvcContext;
            _demo = demo;
        }

        public ActionResult Index()
        {

            _demo.Get();
            var model = _sitecoreContext.GetContextItem<TestGlass>();
            return View(model);
        }
    }
}