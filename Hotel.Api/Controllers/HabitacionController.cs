using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;
using Hotel.Api.Dtos;

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
        var habitacion = habitacionRepository.GetEntities().Select(cd => new HabitacionGetModel()
        {
            IdHabitacion = cd.IdHabitacion,
            Numero = cd.Numero,
            Detalle = cd.Detalle,
            Precio = cd.Precio,
            IdEstadoHabitacion = cd.IdEstadoHabitacion,
            IdPiso = cd.IdPiso,
            IdCategoria = cd.IdCategoria,
            Estado = cd.Estado,
            FechaCreacion = cd.FechaCreacion,
        });
        return Ok(habitacion);
    }

    // GET api/<HabitacionController>/5
    [HttpGet("GetHabitacionById")]
    public IActionResult Get(int id)
    {
        var habitacion = habitacionRepository.GetEntity(id) ?? throw new HabitacionException("Habitación no encontrada");
        HabitacionGetModel habitacionGetModel = new HabitacionGetModel()
        {
            IdHabitacion = habitacion.IdHabitacion,
            Numero = habitacion.Numero,
            Detalle = habitacion.Detalle,
            Precio = habitacion.Precio,
            IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
            IdPiso = habitacion.IdPiso,
            IdCategoria = habitacion.IdCategoria,
            Estado = habitacion.Estado,
            FechaCreacion = habitacion.FechaCreacion,
        };

        return Ok(habitacionGetModel);
    }

    // POST api/<HabitacionController>
    [HttpPost("AddHabitacion")]
    public IActionResult Post([FromBody] HabitacionAddDto habitacionModel)
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

        return Ok("Habitación agregada");
    }

    // PUT api/<HabitacionController>/5
    [HttpPut("UpdateHabitacion")]
    public IActionResult Put(int id, [FromBody] HabitacionUpdateDto habitacionModel)
    {
        var habitacionToUpdate = habitacionRepository.GetEntity(id) ?? throw new HabitacionException("Habitación no encontrada");
        habitacionToUpdate.Numero = habitacionModel.Numero;
        habitacionToUpdate.Detalle = habitacionModel.Detalle;
        habitacionToUpdate.Precio = habitacionModel.Precio;
        habitacionToUpdate.IdEstadoHabitacion = habitacionModel.IdEstadoHabitacion;
        habitacionToUpdate.IdPiso = habitacionModel.IdPiso;
        habitacionToUpdate.IdCategoria = habitacionModel.IdCategoria;
        habitacionToUpdate.Estado = habitacionModel.Estado;
        habitacionRepository.Update(habitacionToUpdate);

        return Ok("Habitación actualizada");
    }

    // DELETE api/<HabitacionController>/5
    [HttpDelete("DeleteHabitacion")]
    public IActionResult Delete(int id)
    {
        var habitacionDeleted = habitacionRepository.GetEntity(id) ?? throw new HabitacionException("Habitación no encontrada");
        habitacionRepository.Remove(habitacionDeleted);

        return Ok("Habitación eliminada");
    }
}
