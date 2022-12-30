using Microsoft.AspNetCore.Mvc;

using WebApplication1.Services.SuperHeroService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return await _superHeroService.GetAllSuperHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);

            if (result == null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero
        (
            int id,
            SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);

            if (result == null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);

            if (result == null)
            { 
                return NotFound("Sorry, but this hero doesn't exist.");
            }

            return Ok(result);
        }
    }
}
