﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Brusnika.Api.Filters;

public class CompanyStructureActionFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await next();
        context.HttpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        context.HttpContext.Response.Headers.Add("X-Xss-Protection", "1");
        context.HttpContext.Response.Headers.Add("X-Frame-Options", "DENY");
    }
}