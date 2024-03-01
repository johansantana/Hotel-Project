using Hotel.Api.Models;
using Hotel.Domain;
using Hotel.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Apii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }
        // GET: api/<CategoriaController>
        [HttpGet("GetCategoria")]
        public IActionResult Get()
        {
            var categoria = this.categoriaRepository.GetEntities();
            return Ok(categoria);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoriaById")]
        public IActionResult Get(int id)
        {
            var categoria = this.categoriaRepository.GetEntity(id);
            return Ok(categoria);
        }

        // POST api/<CategoriaController>
        [HttpPost("SaveCategoria")]
        public void Post([FromBody] CategoriaAddModel categoriaAddModel)
        {
            this.categoriaRepository.Add(new Categoria()
            {
                Estado = categoriaAddModel.Estado,
                Descripcion = categoriaAddModel.Descripcion,
                FechaCreacion = categoriaAddModel.FechaCreacion
            });
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("UpdateCategoria")]
        public void Put(int id, [FromBody] CategoriaModel categoriaModel)
        {
            var categoriaToUpdate = this.categoriaRepository.GetEntity(id);

            categoriaToUpdate.Estado = categoriaModel.Estado;
            categoriaToUpdate.Descripcion = categoriaModel.Descripcion;
            this.categoriaRepository.Update(categoriaToUpdate);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("DeleteCategoria")]
        public void Delete(int id)
        {
            var categoriaDeleted = categoriaRepository.GetEntity(id);
            this.categoriaRepository.Remove(categoriaDeleted);
        }
    }
}
