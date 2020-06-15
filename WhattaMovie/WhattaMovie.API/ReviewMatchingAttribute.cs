using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhattaMovie.Application;
using WhattaMovie.Domain;

namespace WhattaMovie.API
{
    public class ReviewMatchingAttribute:Attribute,IAsyncActionFilter
    {            
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetService<Logger>();
            var handler = context.HttpContext.RequestServices.GetService<IEntityCrudHandler<Review>>();
            var routeData = context.RouteData.Values.Keys.Select(
                key => $"{key}:{context.RouteData.Values[key]}"
            );

            var req = context.HttpContext.Request;
            var path = req.Path.ToString();

            var pattern = @"/([=\w_-]+)/([=\w_-]+)/([=\w_-]+)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match match = regex.Match(path);

            int reviewId = int.Parse(match.Groups[3].Value);

            var userID = (int)context.RouteData.Values["UserID"];            
            var model = context.ActionArguments;

            var review = await handler.ObterUm(reviewId, userID);

            if (review!=null)
            {
                await next.Invoke();
            }
            else
            {
                context.HttpContext.Response.StatusCode = 403;
                await context.HttpContext.Response.WriteAsync("Seu usuário não tem permissão para fazer essa alteração");
                logger.Warning("Acesso Negado ao usuário {userID} para o recurso {@routeData} | Model : {@model}",
                    userID, routeData, model);
            }
        }
    }
}
