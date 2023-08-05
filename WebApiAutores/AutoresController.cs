using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entities;

namespace WebApiAutores
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        [HttpGet] public ActionResult<List<Autor>> Index()
        {
            return new List<Autor>(){ 
                new Autor() { Id = 1, Name = "Nahue" },
                new Autor() { Id = 2, Name = "Franco" },
            };
        }
    }
}
