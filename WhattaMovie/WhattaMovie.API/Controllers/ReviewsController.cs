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
    public class ReviewsController : ControllerBase
    {
        private readonly IEntityCrudHandler<Review> handler;
        public ReviewsController(IEntityCrudHandler<Review> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var reviews = await handler.Listar(userID);
            return new JsonResult(reviews.Select(r => new { r.ID, r.MovieID,r.OwnerID,r.Title }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var review = await handler.ObterUm(id, userID);
            return new JsonResult(new
            {
                review.ID,
                review.MovieID,
                CreatedBy = review.OwnerID,
                review.Title,
                review.Comment,
                AddedOn=review.CreatedOn.ToShortDateString(),
                LastModON=review.LastModifiedOn.ToShortDateString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            review.OwnerID = userID;
            await handler.Inserir(review);
            this.HttpContext.Response.StatusCode = 201;
            return new JsonResult(new { review.ID });
        }

        [HttpPut("{id}")]
        [ReviewMatching]
        public async Task<IActionResult> Put(int id, Review review)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Alterar(id, review, userID);
            this.HttpContext.Response.StatusCode = 200;
            var alteredReview = await handler.ObterUm(id, userID);
            return new JsonResult(new { alteredReview.ID, alteredReview.MovieID });
        }

        [HttpDelete("{id}")]
        [ReviewMatching]
        public async Task<IActionResult> Delete(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Remover(id, userID);
            this.HttpContext.Response.StatusCode = 200;
            var reviews = await handler.Listar(userID);
            return new JsonResult(reviews.Select(r => new { r.ID, r.MovieID, r.OwnerID, r.Title }));
        }
    }
}
