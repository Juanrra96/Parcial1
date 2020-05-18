using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Parcial1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesTVController : ControllerBase
    {

        SeriesTVRepository repositorio;
        public SeriesTVController()
        {

            repositorio = new SeriesTVRepository();
        }

        // GET: api/SeriesTV
        [HttpGet]
        public ActionResult<List<SerieTV>> Get()
        {
            var todos = repositorio.LeerTodos();
            return todos;
        }

        // GET: api/SeriesTV/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<SerieTV> Get(int id)
        {
            var serieTV = repositorio.LeerPorId(id);
            if(serieTV == null){
                return NotFound();
            }
            return serieTV;

        }

        // POST: api/SeriesTV
        [HttpPost]
        public IActionResult Post([FromBody] SerieTV model)
        {
            
            repositorio.Crear(model);

            return Ok();

        }

        // PUT: api/SeriesTV/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SerieTV model)
        {
            var serieTV = repositorio.LeerPorId(model.Id);
            if(serieTV == null){
                return NotFound();
            }
            
            repositorio.Actualizar(model);
            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var serieTV = repositorio.LeerPorId(id);
            if(serieTV == null){
                return NotFound();
            }
            repositorio.Borrar(id);
            return Ok();

        }
    }
}
