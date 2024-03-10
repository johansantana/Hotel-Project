using Hotel.Api.Models;
using Hotel.Api.Dtos;
using Hotel.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoHabitacionController : ControllerBase
{
    private readonly IEstadoHabitacionRepository estadoHabitacionRepository;
    public EstadoHabitacionController(IEstadoHabitacionRepository estadoHabitacionRepository)
    {
        this.estadoHabitacionRepository = estadoHabitacionRepository;
    }
    // GET: api/<EstadoHabitacionController>
    [HttpGet("GetEstadoHabitacion")]
    public IActionResult Get()
    {
        var estadoHabitacion = estadoHabitacionRepository.GetEntities().Select(cd => new EstadoHabitacionGetModel()
        {
            IdEstadoHabitacion = cd.IdEstadoHabitacion,
            Descripcion = cd.Descripcion,
            Estado = cd.Estado,
            FechaCreacion = cd.FechaCreacion,
        });
        return Ok(estadoHabitacion);
    }

    // GET api/<EstadoHabitacionController>/5
    [HttpGet("GetEstadoHabitacionById")]
    public IActionResult Get(int id)
    {
        var estadoHabitacion = estadoHabitacionRepository.GetEntity(id) ?? throw new EstadoHabitacionException("Estado de Habitación no encontrado");

        EstadoHabitacionGetModel estadoHabitacionGetModel = new EstadoHabitacionGetModel()
        {
            IdEstadoHabitacion = estadoHabitacion.IdEstadoHabitacion,
            Descripcion = estadoHabitacion.Descripcion,
            Estado = estadoHabitacion.Estado,
            FechaCreacion = estadoHabitacion.FechaCreacion,
        };
        return Ok(estadoHabitacionGetModel);
    }

    // POST api/<EstadoHabitacionController>
    [HttpPost("AddEstadoHabitacion")]
    public IActionResult Post([FromBody] EstadoHabitacionAddDto estadoHabitacionModel)
    {
        estadoHabitacionRepository.Add(new EstadoHabitacion()
        {
            Descripcion = estadoHabitacionModel.Descripcion,
            Estado = estadoHabitacionModel.Estado
        });

        return Ok("Estado de Habitación agregado");
    }

    // PUT api/<EstadoHabitacionController>/5
    [HttpPut("UpdateEstadoHabitacion")]
    public IActionResult Put(int id, [FromBody] EstadoHabitacionAddDto estadoHabitacionModel)
    {
        var estadoHabitacionToUpdate = estadoHabitacionRepository.GetEntity(id) ?? throw new EstadoHabitacionException("Estado de Habitación no encontrado");
        estadoHabitacionToUpdate.Descripcion = estadoHabitacionModel.Descripcion;
        estadoHabitacionToUpdate.Estado = estadoHabitacionModel.Estado;
        estadoHabitacionRepository.Update(estadoHabitacionToUpdate);

        return Ok("Estado de Habitación actualizado");
    }

    // DELETE api/<EstadoHabitacionController>/5
    [HttpDelete("DeleteEstadoHabitacion")]
    public IActionResult Delete(int id)
    {
        var estadoHabitacionDeleted = estadoHabitacionRepository.GetEntity(id) ?? throw new EstadoHabitacionException("Estado de Habitación no encontrado");
        estadoHabitacionRepository.Remove(estadoHabitacionDeleted);

        return Ok("Estado de Habitación eliminado");
    }
}
