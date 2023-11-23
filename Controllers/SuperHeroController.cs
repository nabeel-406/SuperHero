using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIVSC.Models;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPIVSC.Data;


namespace SuperHeroAPIVSC.Controllers
{
    [Route("[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero =await _context.superHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Create(SuperHero hero)
        {
        _context.superHeroes.Add(hero);
        await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
           var dbhero =await _context.superHeroes.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Hero not found");

            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;
            
            await _context.SaveChangesAsync();


            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
             var dbhero =await _context.superHeroes.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Hero not found");

            _context.superHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
    }
}