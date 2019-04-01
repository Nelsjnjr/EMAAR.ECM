using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using code.Interfaces;

namespace code.Controllers
{
    public class SeoController : Controller
    {
        private readonly ISeoRepository _seoRepository;

     
        public SeoController(ISeoRepository seoRepository )
        {
            _seoRepository = seoRepository;
        }
        // GET: Seo
        //public ActionResult Index()
        //{
        //    return View(_seoRepository);
        //}
    }
}