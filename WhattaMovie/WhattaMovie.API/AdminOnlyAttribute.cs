using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog.Core;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhattaMovie.Application;
using WhattaMovie.Domain;

namespace WhattaMovie.API
{
    public class AdminOnlyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetService<Logger>();
            var handler = context.HttpContext.RequestServices.GetService<IEntityCrudHandler<Movie>>();
            var routeData = context.RouteData.Values.Keys.Select(
                    key=>$"{key}:{context.RouteData.Values[key]}"
                );
            var userID = (int)context.RouteData.Values["UserID"];
            var role = context.RouteData.Values["UserRole"].ToString();
            var model = context.ActionArguments;

            if (role == "admin")
            {
                await next.Invoke();
            }
            else
            {
                context.HttpContext.Response.StatusCode = 403;
                await context.HttpContext.Response.WriteAsync("Seu usuário não tem permissão para usar esse recurso");
                logger.Warning("Acesso Negado do usuário {userID} ao recurso {@routeData} | Model : {@model}",
                    userID, routeData, model);
            }
        }
    }
}
