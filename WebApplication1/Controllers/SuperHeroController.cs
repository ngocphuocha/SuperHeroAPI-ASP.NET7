using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeros = new List<SuperHero>{
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Paker",
                    Place= "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark", 
                    Place= "Malibu"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return Ok(superHeros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);

            if(hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exits");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeros.Add(hero);

            return Ok(superHeros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeros.Find(x => x.Id == id);

            if(hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exits");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(superHeros); // return new hero with 200 status
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);

            if (hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exits");
            }

            superHeros.Remove(hero);

            return NoContent();
        }
    }
}
