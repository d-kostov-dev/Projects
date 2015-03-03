namespace MVCAppTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using MVCAppTemplate.Services.Contracts;
    using MVCAppTemplate.Web.Controllers.Base;

    public class HomeController : BaseController
    {
        private IHomeServices homeService;

        public HomeController(IHomeServices homeService)
            : base(homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}