namespace MVCAppTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using MVCAppTemplate.Services.Contracts;
    using MVCAppTemplate.Web.Controllers.Base;

    public class HomeController : BaseController
    {
        private IPostServices postServices;

        public HomeController(IPostServices postServices)
            : base(postServices)
        {
            this.postServices = postServices;
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