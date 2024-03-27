using Hotel.Api.Dtos.Categoria;
using Hotel.Api.Models;
using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Dtos.Categoria;
using Hotel.Domain;


using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Apii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }
        // GET: api/<CategoriaController>
        [HttpGet("GetCategoria")]
        public IActionResult Get()
        {
            var result = this.categoriaService.GetEntities();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("GetCategoriaById")]
        public IActionResult Get(int id)
        {

           var result  = this.categoriaService.GetEntity(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<CategoriaController>
        [HttpPost("SaveCategoria")]
        public IActionResult Post([FromBody] Aplication.Dtos.Categoria.CategoriaAddDto categoriaAddDto)
        {
  
            var result = this.categoriaService.SaveEntity(categoriaAddDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("UpdateCategoria")]
        public IActionResult Put([FromBody] Aplication.Dtos.Categoria.CategoriaUpdateDto categoriaUpdateDto)
        {

            var result = this.categoriaService.UpdateEntity(categoriaUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
            
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("DeleteCategoria")]
        public IActionResult Delete(int id)
        {

            var result = this.categoriaService.DeleteEntity(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
