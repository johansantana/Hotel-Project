using Hotel.Api.Dtos.Categoria;
using Hotel.Api.Models;
using Hotel.Domain;


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
            var categoria = this.categoriaRepository.GetEntities().Select( cd => new CategoriaGetModel()
            {
                IdCategoria = cd.IdCategoria,
                Descripcion = cd.Descripcion,
                Estado = cd.Estado,
                FechaCreacion = cd.FechaCreacion,
            });
            return Ok(categoria);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoriaById")]
        public IActionResult Get(int id)
        {
            var categoria = this.categoriaRepository.GetEntity(id);
            CategoriaGetModel categoriaGetModel = new CategoriaGetModel()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
                Estado = categoria.Estado,
                FechaCreacion = categoria.FechaCreacion,
            };
            return Ok(categoriaGetModel);
        }

        // POST api/<CategoriaController>
        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAddDto)
        {
            this.categoriaRepository.Add(new Categoria()
            {
                Estado = categoriaAddDto.Estado,
                Descripcion = categoriaAddDto.Descripcion,
                FechaCreacion = categoriaAddDto.FechaCreacion
            });
            return Ok("Categoria guardada con exito");
        }

        // PUT api/<CategoriaController>/5
        [HttpPost("UpdateCategoria")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdateDto)
        {
            this.categoriaRepository.Update(new Categoria()
            {
                IdCategoria = categoriaUpdateDto.IdCategoria,
                Descripcion = categoriaUpdateDto.Descripcion,
                Estado = categoriaUpdateDto.Estado,

            });
            return Ok("Categoria actualizada con exito");
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("DeleteCategoria")]
        public IActionResult Delete(int id)
        {

            var categoriaDeleted = categoriaRepository.GetEntity(id);
            this.categoriaRepository.Remove(categoriaDeleted);

            return Ok("Categoria eliminada con exito");
        }
    }
}
