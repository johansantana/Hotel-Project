using Hotel.Api.Models;
using Hotel.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Application.Dtos;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoHabitacionController : ControllerBase
{
    private readonly IEstadoHabitacionService estadoHabitacionService;
    public EstadoHabitacionController(IEstadoHabitacionService estadoHabitacionService)
    {
        this.estadoHabitacionService = estadoHabitacionService;
    }
    // GET: api/<EstadoHabitacionController>
    [HttpGet("GetEstadoHabitaciones")]
    public IActionResult Get()
    {
        var result = estadoHabitacionService.Get();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // GET api/<EstadoHabitacionController>/5
    [HttpGet("GetEstadoHabitacionById")]
    public IActionResult Get(int id)
    {
        var result = estadoHabitacionService.GetById(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // POST api/<EstadoHabitacionController>
    [HttpPost("AddEstadoHabitacion")]
    public IActionResult Post([FromBody] EstadoHabitacionAddDto estadoHabitacionModel)
    {
        var result = estadoHabitacionService.Save(estadoHabitacionModel);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // PUT api/<EstadoHabitacionController>/5
    [HttpPut("UpdateEstadoHabitacion")]
    public IActionResult Put(int id, [FromBody] EstadoHabitacionUpdateDto estadoHabitacionModel)
    {
        var result = estadoHabitacionService.Update(id, estadoHabitacionModel);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // DELETE api/<EstadoHabitacionController>/5
    [HttpDelete("DeleteEstadoHabitacion")]
    public IActionResult Delete(int id)
    {
        var result = estadoHabitacionService.Delete(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
