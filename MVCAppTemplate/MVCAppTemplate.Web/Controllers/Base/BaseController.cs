namespace MVCAppTemplate.Web.Controllers.Base
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using MVCAppTemplate.Services.Base;
    using MVCAppTemplate.Web.Infrastructure.ActionResults;

    public class BaseController : Controller
    {
        private IBaseServices baseService;

        public BaseController(IBaseServices baseService)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            this.baseService = baseService;
        }

        protected override IAsyncResult BeginExecute(
            RequestContext requestContext, 
            AsyncCallback callback, 
            object state)
        {
            this.ViewBag.Settings = this.baseService.GetSettings();
            return base.BeginExecute(requestContext, callback, state);
        }

        protected AutoMapObjectActionResult<TSource, TResult> AutoMapObject<TSource, TResult>(ViewResult view)
            where TSource : class
        {
            return new AutoMapObjectActionResult<TSource, TResult>(view);
        }

        protected AutoMapQueryActionResult<TSource, TResult> AutoMapQuery<TSource, TResult>(ViewResult view)
        {
            return new AutoMapQueryActionResult<TSource, TResult>(view);
        }
    }
}