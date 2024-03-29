using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;
using Hotel.Application.Contracts;
using Hotel.Application.Dtos;

namespace Hotel.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }
    // GET: api/<UsuarioController>
    [HttpGet("GetUsuarios")]
    public IActionResult Get()
    {
        var result = usuarioService.Get();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // GET api/<UsuarioController>/5
    [HttpGet("GetUsuarioById")]
    public IActionResult Get(int id)
    {
        var result = usuarioService.GetById(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddUsuario")]
    public IActionResult Post([FromBody] UsuarioAddDto usuarioAddDto)
    {
        var result = usuarioService.Save(usuarioAddDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // PUT api/<UsuarioController>/5
    [HttpPut("UpdateUsuario")]
    public IActionResult Put(int id, [FromBody] UsuarioUpdateDto usuarioUpdateDto)
    {
        var result = usuarioService.Update(id, usuarioUpdateDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("DeleteUsuario")]
    public IActionResult Delete(int id)
    {
        var result = usuarioService.Delete(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}

