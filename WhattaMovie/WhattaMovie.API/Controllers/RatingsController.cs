using JsonWebToken;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WhattaMovie.Application;
using WhattaMovie.Domain;
using WhattaMovie.Infrastructure;

namespace WhattaMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JWTAuthorize]
    [LoggingFilter]
    public class RatingsController : ControllerBase
    {
        private readonly IEntityCrudHandler<Rating> handler;
        public RatingsController(IEntityCrudHandler<Rating> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var ratings = await handler.Listar(userID);
            return new JsonResult(ratings.Select(r =>new { r.ID, r.MovieID,r.OwnerID,r.MovieRating }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var rating = await handler.ObterUm(id,userID);
            return new JsonResult(new 
            {
                rating.ID,
                rating.MovieID,
                CreatedBy = rating.OwnerID,
                rating.MovieRating,
                AddedOn=rating.CreatedOn.ToShortDateString(),
                LastModOn=rating.LastModifiedOn.ToShortDateString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rating rating)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            rating.OwnerID = userID;
            await handler.Inserir(rating);
            this.HttpContext.Response.StatusCode = 201;
            return new JsonResult(new { rating.ID });
        }

        [HttpPut("{id}")]
        [RatingMatching]
        public async Task<IActionResult> Put(int id, Rating rating)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Alterar(id, rating, userID);
            this.HttpContext.Response.StatusCode = 200;
            var alteredRating = await handler.ObterUm(id, userID);
            return new JsonResult(new { alteredRating.ID, alteredRating.MovieID });
        }

        [HttpDelete("{id}")]
        [RatingMatching]
        public async Task<IActionResult> Delete(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Remover(id, userID);
            this.HttpContext.Response.StatusCode = 200;
            var ratings = await handler.Listar(userID);
            return new JsonResult(ratings.Select(r => new { r.ID, r.MovieID, r.OwnerID, r.MovieRating }));
        }
    }
}
