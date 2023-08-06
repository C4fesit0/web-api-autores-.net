using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Index()
        {
            return await context.Autores.Include(x=> x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el Id de la url");
            }

            var exists = await context.Autores.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound("Autor no encontrado");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Autores.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound("Autor no encontrado");
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
