#region namespace
using System;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Hero;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Homepage_carousel;
using Glass.Mapper.Sc.Web.Mvc;
#endregion
namespace EMAAR.ECM.Feature.Banner.Repositories
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    [Service(typeof(IImageBannerRepository))]
    public class ImageBannerRepository : IImageBannerRepository
    {
        #region property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IImageText _imageText;
        private readonly IParallax _parallax;
        private readonly IHomepage_Carousels _homepage_Carousels ;
        private readonly IHero  _hero;

        #endregion
        #region construtor
        public ImageBannerRepository(Func<IMvcContext> mvcContext, IParallax parallax, IImageText imageText, IHomepage_Carousels homepage_Carousels , IHero hero)
        {
            _imageText = imageText;
            _parallax = parallax;
            _mvcContext = mvcContext;
            _homepage_Carousels = homepage_Carousels;
            _hero = hero;

        }
        #endregion
        #region public method

        /// <summary>
        /// Getting 2 variants of ImageText components(Left,Right )
        /// </summary>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>

        public IImageText GetImageText()
        {
            IMvcContext mvcContext = _mvcContext();
            IImageText imageText = mvcContext.GetDataSourceItem<IImageText>();
            return imageText ?? _imageText;
        }
        /// <summary>
        /// Getting 2 variants of Parallax components(background image )
        /// </summary>
        /// <returns>Parallax</returns>
        public IParallax GetParallax()
        {
            IMvcContext mvcContext = _mvcContext();
            IParallax parallax = mvcContext.GetDataSourceItem<IParallax>();
            return parallax ?? _parallax;
        }

        /// <summary>
        /// Getting all Home Carousel component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>
        /// <returns>Home Carousel content Slides details</returns>
        public IHomepage_Carousels HomePageCarousels()
        {
            IMvcContext mvcContext = _mvcContext();
            IHomepage_Carousels homepage_Carousels  = mvcContext.GetDataSourceItem<IHomepage_Carousels>();
            return homepage_Carousels ?? _homepage_Carousels;
        }
        /// <summary>
        /// Getting all Hero component asigned in Sitecore on field (Hero Metrics)
        /// </summary>
        /// <returns>HeroBannerList</returns>
        public IHero GetHero()
        {
            IMvcContext mvcContext = _mvcContext();
            IHero hero = mvcContext.GetDataSourceItem<IHero>();
            return hero ?? _hero;
        }
        #endregion
        #region private method

        #endregion

    }
}