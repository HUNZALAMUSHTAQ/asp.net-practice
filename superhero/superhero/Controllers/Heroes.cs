using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using superhero.Models;

namespace superhero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Heroes : ControllerBase
    {
        private static List<SuperHero> hereos = new List<SuperHero>()
            {
                new SuperHero { Id = 0, Name = "Batman", FirstName = "Bruce", LastName = "Wayne" },
                new SuperHero { Id = 1, Name = "Hulk", FirstName = "Bruce", LastName = "Banner" }
            };

        private readonly UserContext _users;
        public Heroes(UserContext user)
        {
            this._users = user;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetHero()
        {
            return _users.Users.ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            var hero = hereos.Find(h => h.Id == id);
            if(hero == null)
            {
                return NotFound("Hero Not Found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero hero)
        {
            Console.WriteLine(hero);
            hereos.Add(hero);
            return Ok(hereos);  
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero req)
        {
            var hero = hereos.Find(h => h.Id == req.Id);
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }

            hero.Name = req.Name;   
            hero.FirstName = req.FirstName; 
            hero.LastName = req.LastName;

            return Ok(hereos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero = hereos.Find(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            hereos.Remove(hero);
            return Ok(hero);
        }

    }
}
