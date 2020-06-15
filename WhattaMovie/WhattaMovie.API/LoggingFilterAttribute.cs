using Microsoft.AspNetCore.Mvc.Filters;
using Serilog.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhattaMovie.API
{
    public class LoggingFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetService<Logger>();
            try
            {
                var userID = (int)context.RouteData.Values["UserID"];
                var model = context.ActionArguments;
                context.HttpContext.Items["ActionArguments"] = model;
                var req = context.HttpContext.Request;
                var url = $"({req.Method}) {req.Scheme}://{req.Host}{req.Path}{req.QueryString}";
                var routeData = context.RouteData.Values.Keys.Select(
                        key => $"{key}:{context.RouteData.Values[key]}"
                    );

                logger.Information(
                    "User {userID} requested {url} to [@routeData] with Model : {@model}",
                    userID,url,routeData,model
                    );

                var executedCont = await next.Invoke();

                if (executedCont.Result is JsonResult)
                {
                    var jsonresult = executedCont.Result as JsonResult;
                    var result = jsonresult.Value;

                    logger.Debug(
                        "Requested {url} to {@routeData} with Model : {@model} | Result : {result}",
                        url, routeData, model, result
                        );
                }
            }
            catch (Exception ex)
            {

                logger.Warning(ex,"Unable to log executed action");
            }
        }
        public void OnException(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<Logger>();

            var userID = (int)context.RouteData.Values["UserID"];
            var model = context.HttpContext.Items["ActionArguments"];  
            var req = context.HttpContext.Request;
            var url = $"({req.Method}) {req.Scheme}://{req.Host}{req.Path}{req.QueryString}";
            var routeData = context.RouteData.Values.Keys.Select(
                    key => $"{key}:{context.RouteData.Values[key]}"
                );
            var exception = context.Exception.Message;
            var stack = context.Exception.StackTrace;
            var exceptionType = context.Exception.GetType();

            logger.Error(
                "User {userID} requested {url} to {@routeData} with Model : {@model} resulted in error: ({exceptionType}){exception}",
                userID, url, routeData, model, exceptionType, exception
            );

            logger.Debug(
                context.Exception,
                "Requested {url} to {@routeData} with Model : {@model} resulted in error: ({exceptionType}){exception}",
                url, routeData, model, exceptionType, exception
            );
        }
    }
}
