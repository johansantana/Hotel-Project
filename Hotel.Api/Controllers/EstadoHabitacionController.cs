using Hotel.Api.Models;
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
        var estadoHabitacion = estadoHabitacionRepository.GetEntities();
        return Ok(estadoHabitacion);
    }

    // GET api/<EstadoHabitacionController>/5
    [HttpGet("GetEstadoHabitacionById")]
    public IActionResult Get(int id)
    {
        var estadoHabitacion = this.estadoHabitacionRepository.GetEntity(id);
        return Ok(estadoHabitacion);
    }

    // POST api/<EstadoHabitacionController>
    [HttpPost("AddEstadoHabitacion")]
    public void Post([FromBody] EstadoHabitacionAddModel estadoHabitacionModel)
    {
        this.estadoHabitacionRepository.Add(new EstadoHabitacion()
        {
            Descripcion = estadoHabitacionModel.Descripcion,
            Estado = estadoHabitacionModel.Estado
        });
    }

    // PUT api/<EstadoHabitacionController>/5
    [HttpPut("UpdateEstadoHabitacion")]
    public void Put(int id, [FromBody] EstadoHabitacionAddModel estadoHabitacionModel)
    {
        var estadoHabitacionToUpdate = estadoHabitacionRepository.GetEntity(id) ?? throw new EstadoHabitacionException("Estado de Habitación no encontrado");
        estadoHabitacionToUpdate.Descripcion = estadoHabitacionModel.Descripcion;
        estadoHabitacionToUpdate.Estado = estadoHabitacionModel.Estado;
        this.estadoHabitacionRepository.Update(estadoHabitacionToUpdate);
    }

    // DELETE api/<EstadoHabitacionController>/5
    [HttpDelete("DeleteEstadoHabitacion")]
    public void Delete(int id)
    {
        var estadoHabitacionDeleted = estadoHabitacionRepository.GetEntity(id) ?? throw new EstadoHabitacionException("Estado de Habitación no encontrado");
        this.estadoHabitacionRepository.Remove(estadoHabitacionDeleted);
    }
}
