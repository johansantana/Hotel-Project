using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;
using Hotel.Application.Contracts;
using Hotel.Application.Dtos;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HabitacionController : ControllerBase
{
    private readonly IHabitacionService habitacionService;
    public HabitacionController(IHabitacionService habitacionService)
    {
        this.habitacionService = habitacionService;
    }
    // GET: api/<HabitacionController>
    [HttpGet("GetHabitaciones")]
    public IActionResult Get()
    {
        var result = habitacionService.Get();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // GET api/<HabitacionController>/5
    [HttpGet("GetHabitacionById")]
    public IActionResult Get(int id)
    {
        var result = habitacionService.GetById(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // POST api/<HabitacionController>
    [HttpPost("AddHabitacion")]
    public IActionResult Post([FromBody] HabitacionAddDto habitacionModel)
    {
        var result = habitacionService.Save(habitacionModel);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // PUT api/<HabitacionController>/5
    [HttpPut("UpdateHabitacion")]
    public IActionResult Put(int id, [FromBody] HabitacionUpdateDto habitacionModel)
    {
        var result = habitacionService.Update(id, habitacionModel);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // DELETE api/<HabitacionController>/5
    [HttpDelete("DeleteHabitacion")]
    public IActionResult Delete(int id)
    {
        var result = habitacionService.Delete(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
