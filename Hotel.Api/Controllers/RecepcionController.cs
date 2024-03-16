using Hotel.Api.Dtos.Recepcion;
using Hotel.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hotel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionRepository _recepcionRepository;

        public RecepcionController(IRecepcionRepository recepcionRepository)
        {
            _recepcionRepository = recepcionRepository ?? throw new ArgumentNullException(nameof(recepcionRepository));
        }

        [HttpPost]
        public IActionResult AddRecepcion([FromBody] RecepcionCreateDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Datos de entrada inválidos");
            }

            var nuevaRecepcion = new Recepcion
            {
                NombreDelHuesped = createDto.NombreDelHuesped,
                ApellidoDelHuesped = createDto.ApellidoDelHuesped,
                DocumentoIdentificacion = createDto.DocumentoIdentificacion,
                FechaDeEntrada = createDto.FechaDeEntrada,
            };

            try
            {
                _recepcionRepository.Create(nuevaRecepcion);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al guardar la recepción");
            }

            return CreatedAtAction(nameof(GetRecepcionById), new { id = nuevaRecepcion.Id }, nuevaRecepcion);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecepcionById(int id)
        {
            var recepcion = _recepcionRepository.GetRecepcion(id);
            if (recepcion == null)
            {
                return NotFound("Recepción no encontrada");
            }

            return Ok(recepcion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecepcion(int id, [FromBody] RecepcionUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest("Datos de entrada inválidos");
            }

            var recepcionToUpdate = _recepcionRepository.GetRecepcion(id);
            if (recepcionToUpdate == null)
            {
                return NotFound("Recepción no encontrada para actualizar");
            }

            recepcionToUpdate.FechaDeSalida = updateDto.FechaDeSalida;
            recepcionToUpdate.Estado = updateDto.Estado;

            try
            {
                _recepcionRepository.Update(recepcionToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al actualizar la recepción");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecepcion(int id)
        {
            var recepcionToDelete = _recepcionRepository.GetRecepcion(id);
            if (recepcionToDelete == null)
            {
                return NotFound("Recepción no encontrada para eliminar");
            }

            try
            {
                _recepcionRepository.Remove(recepcionToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al eliminar la recepción");
            }

            return NoContent();
        }
    }

    public interface IRecepcionRepository
    {
        Recepcion GetRecepcion(int id);
        void Create(Recepcion recepcion);
        void Remove(Recepcion recepcionToDelete);
        void Update(Recepcion recepcionToUpdate);
    }
}
