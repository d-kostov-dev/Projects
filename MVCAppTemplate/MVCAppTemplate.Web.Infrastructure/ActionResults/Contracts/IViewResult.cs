﻿namespace MVCAppTemplate.Web.Infrastructure.ActionResults.Contracts
{
    using System.Web.Mvc;

    public interface IViewResult
    {
        ViewResult View { get; }
    }
}
