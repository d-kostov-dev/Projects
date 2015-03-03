namespace MVCAppTemplate.Web.Infrastructure.ActionResults
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MVCAppTemplate.Web.Infrastructure.ActionResults.Contracts;

    public class AutoMapQueryActionResult<TSource, TResult> : ActionResult, IViewResult
    {
        public AutoMapQueryActionResult(ViewResult view)
        {
            this.View = view;
        }

        public ViewResult View { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var queryable = this.View.ViewData.Model as IQueryable<TSource>;
            this.View.ViewData.Model = queryable.Project().To<TResult>();
            this.View.ExecuteResult(context);
        }
    }
}
