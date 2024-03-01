using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HabitacionController : ControllerBase
{
    private readonly IHabitacionRepository habitacionRepository;
    public HabitacionController(IHabitacionRepository habitacionRepository)
    {
        this.habitacionRepository = habitacionRepository;
    }
    // GET: api/<HabitacionController>
    [HttpGet("GetHabitaciones")]
    public IActionResult Get()
    {
        var habitacion = habitacionRepository.GetEntities();
        return Ok(habitacion);
    }

    // GET api/<HabitacionController>/5
    [HttpGet("GetHabitacionById")]
    public IActionResult Get(int id)
    {
        var habitacion = habitacionRepository.GetEntity(id);
        return Ok(habitacion);
    }

    // POST api/<HabitacionController>
    [HttpPost("AddHabitacion")]
    public void Post([FromBody] HabitacionAddModel habitacionModel)
    {
        habitacionRepository.Add(new Habitacion()
        {
            Numero = habitacionModel.Numero,
            Detalle = habitacionModel.Detalle,
            Precio = habitacionModel.Precio,
            IdEstadoHabitacion = habitacionModel.IdEstadoHabitacion,
            IdPiso = habitacionModel.IdPiso,
            IdCategoria = habitacionModel.IdCategoria,
            Estado = habitacionModel.Estado
        });
    }

    // PUT api/<HabitacionController>/5
    [HttpPut("UpdateHabitacion")]
    public void Put(int id, [FromBody] HabitacionAddModel habitacionModel)
    {
        var habitacionToUpdate = habitacionRepository.GetEntity(id) ?? throw new HabitacionException("Habitación no encontrada");
        habitacionToUpdate.Numero = habitacionModel.Numero;
        habitacionToUpdate.Detalle = habitacionModel.Detalle;
        habitacionToUpdate.Precio = habitacionModel.Precio;
        habitacionToUpdate.IdEstadoHabitacion = habitacionModel.IdEstadoHabitacion;
        habitacionToUpdate.IdPiso = habitacionModel.IdPiso;
        habitacionToUpdate.IdCategoria = habitacionModel.IdCategoria;
        habitacionToUpdate.Estado = habitacionModel.Estado;
        this.habitacionRepository.Update(habitacionToUpdate);
    }

    // DELETE api/<HabitacionController>/5
    [HttpDelete("DeleteHabitacion")]
    public void Delete(int id)
    {
        var habitacionDeleted = habitacionRepository.GetEntity(id) ?? throw new HabitacionException("Habitación no encontrada");
        this.habitacionRepository.Remove(habitacionDeleted);
    }
}
