﻿using JsonWebToken;
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
    public class MoviesController : ControllerBase
    {
        private readonly IEntityCrudHandler<Movie> handler;

        public MoviesController(IEntityCrudHandler<Movie> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var movies = await handler.Listar(userID);
            return new JsonResult(movies.Select(m => new { m.ID, m.Tittle, m.Year, m.AverageRating }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var movie = await handler.ObterUm(id,userID);
            return new JsonResult(new 
            { 
                movie.ID,
                movie.Tittle,
                movie.Genre,
                movie.Year,                
                movie.Description,
                movie.AverageRating,
                RatingNumber = movie.Ratings.Count(),
                ReviewsNumber = movie.Reviews.Count(),
                movie.OwnerID,
                AddedOn = movie.CreatedOn.ToShortDateString(),
                LastModON = movie.LastModifiedOn.ToShortDateString()
            });
        }

        [HttpGet("{id}/Ratings")]
        public async Task<IActionResult> GetRatings(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var movie = await handler.ObterUm(id, userID);
            return new JsonResult(movie.Ratings.Select(r => new { r.ID,r.OwnerID,r.MovieRating}));
        }

        [HttpGet("{id}/Reviews")]
        public async Task<IActionResult> GetReviews(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            var movie = await handler.ObterUm(id, userID);
            return new JsonResult(movie.Reviews.Select(r => new { r.ID, r.OwnerID,r.Title,r.Comment}));
        }

        [HttpPost]
        [AdminOnly]
        public async Task<IActionResult> Post(Movie movie)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            movie.OwnerID = userID;
            await handler.Inserir(movie);
            this.HttpContext.Response.StatusCode = 201;
            return new JsonResult(new { movie.ID });
        }

        [HttpPut("{id}")]
        [AdminOnly]
        public async Task<IActionResult> Put(int id, Movie movie)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Alterar(id, movie, userID);
            this.HttpContext.Response.StatusCode = 200;
            var alteredMovie = await handler.ObterUm(id,userID);
            return new JsonResult(new { alteredMovie.ID, alteredMovie.Tittle });
        }

        [HttpDelete("{id}")]
        [AdminOnly]
        public async Task<IActionResult> Delete(int id)
        {
            var userID = (int)this.RouteData.Values["UserID"];
            await handler.Remover(id, userID);
            this.HttpContext.Response.StatusCode = 200;
            var movies = await handler.Listar(userID);
            return new JsonResult(movies.Select(m => new { m.ID, m.Tittle, m.Year, m.AverageRating }));
        }
    }
}
