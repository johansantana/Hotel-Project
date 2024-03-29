using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;
using Hotel.Application.Contracts;
using Hotel.Application.Dtos;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolUsuarioController : ControllerBase
{
    private readonly IRolUsuarioService rolUsuarioService;
    public RolUsuarioController(IRolUsuarioService rolUsuarioService)
    {
        this.rolUsuarioService = rolUsuarioService;
    }
    // GET: api/<RolUsuarioController>
    [HttpGet("GetRolUsuarios")]
    public IActionResult Get()
    {
        var result = rolUsuarioService.Get();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // GET api/<RolUsuarioController>/5
    [HttpGet("GetRolUsuarioById")]
    public IActionResult Get(int id)
    {
        var result = rolUsuarioService.GetById(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddRolUsuario")]
    public IActionResult Post([FromBody] RolUsuarioAddDto rolUsuarioDto)
    {
        var result = rolUsuarioService.Save(rolUsuarioDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // PUT api/<RolUsuarioController>/5
    [HttpPut("UpdateRolUsuario")]
    public IActionResult Put(int id, [FromBody] RolUsuarioUpdateDto rolUsuarioDto)
    {
        var result = rolUsuarioService.Update(id, rolUsuarioDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // DELETE api/<RolUsuarioController>/5
    [HttpDelete("DeleteRolUsuario")]
    public IActionResult Delete(int id)
    {
        var result = rolUsuarioService.Delete(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
