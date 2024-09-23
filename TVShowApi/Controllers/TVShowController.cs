using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVShowApi.Data;
using TVShowApi.Entities;

namespace TVShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVShowController : ControllerBase
    {
        private readonly TVDbContext _context;

        public TVShowController(TVDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los TV Shows existentes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TVShow>>> GetAllTvShows()
        {
            var tvshow = await _context.TVShows.ToListAsync();

            return Ok(tvshow);
        }

        /// <summary>
        /// Agrega un TV Show a la base de datos.
        /// </summary>
        /// <param name="tvshow"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<TVShow>>> AddTvShow(TVShow tvshow)
        {
            _context.TVShows.Add(tvshow);
            await _context.SaveChangesAsync();

            return Ok(await GetAllTvShows());
        }

        /// <summary>
        /// Modifica un TV Show ingresando los datos.
        /// </summary>
        /// <param name="tvshow"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<TVShow>>> UpdateTvShow(TVShow tvshow)
        {
            var updTvShow = await _context.TVShows.FindAsync(tvshow.Id);

            if(updTvShow is null)
            {
                return NotFound("Hero not found");
            }

            updTvShow.Name = tvshow.Name;
            updTvShow.Favorite = tvshow.Favorite;

            await _context.SaveChangesAsync();


            return Ok(await _context.TVShows.ToListAsync());
        }

        /// <summary>
        /// Elimina un TV Show de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<List<TVShow>>> DeleteTvShow(int id)
        {
            var dTvShow = await _context.TVShows.FindAsync(id);

            if (dTvShow is null)
            {
                return NotFound("Hero not found");
            }

            _context.TVShows.Remove(dTvShow);
            await _context.SaveChangesAsync();


            return Ok(await _context.TVShows.ToListAsync());
        }
    }
}

