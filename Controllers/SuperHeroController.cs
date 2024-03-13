using mainWEB.data;
using mainWEB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mainWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       private readonly DataContext _Context;

        public SuperHeroController(DataContext context)
        {
            _Context=context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Superhero>>> getallHeros()
        {
            var heroes = await _Context.Superheroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Superhero>> getHeros(int id)
        {
            var heroes = await _Context.Superheroes.FindAsync(id);
            if(heroes == null)
            {
                return NotFound("hero not found.");
            }

            return Ok(heroes);
        }


        [HttpPost]

        public async Task<ActionResult<List<Superhero>>> AddHero([FromBody]Superhero hero)
        {
            _Context.Superheroes.Add(hero);
            await _Context.SaveChangesAsync();
           

            return Ok(await _Context.Superheroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero updatedHero)
        {
            var dbHero = await _Context.Superheroes.FindAsync(updatedHero.Id);
            if (dbHero == null)
            {
                return NotFound("hero not found.");
            }

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.place = updatedHero.place;


            await _Context.SaveChangesAsync();



            return Ok(await _Context.Superheroes.ToListAsync());
        }


        [HttpDelete]

        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {
            var dbHero = await _Context.Superheroes.FindAsync(id);
            if (dbHero == null)
            {
                return NotFound("hero not found.");
            }

           _Context.Superheroes.Remove(dbHero);


            await _Context.SaveChangesAsync();



            return Ok(await _Context.Superheroes.ToListAsync());
        }
    }
}
