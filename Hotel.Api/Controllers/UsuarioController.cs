using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Models;

namespace Hotel.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository usuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }
    // GET: api/<UsuarioController>
    [HttpGet("GetUsuario")]
    public IActionResult Get()
    {
        var usuario = this.usuarioRepository.GetEntities();
        return Ok(usuario);
    }

    // GET api/<UsuarioController>/5
    [HttpGet("GetUsuarioById")]
    public IActionResult Get(int id)
    {
        var usuario = this.usuarioRepository.GetEntity(id);
        return Ok(usuario);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddUsuario")]
    public void Post([FromBody] UsuarioAddModel usuarioModel)
    {
        this.usuarioRepository.Add(new Usuario()
        {
            NombreCompleto = usuarioModel.NombreCompleto,
            Correo = usuarioModel.Correo,
            Clave = usuarioModel.Clave,
            Estado = usuarioModel.Estado,
            IdRolUsuario = usuarioModel.IdRolUsuario
        });
    }

    // PUT api/<UsuarioController>/5
    [HttpPut("UpdateUsuario")]
    public void Put(int id, [FromBody] UsuarioAddModel usuarioModel)
    {
        var usuarioToUpdate = usuarioRepository.GetEntity(id) ?? throw new UsuarioException("Usuario no encontrado");
        usuarioToUpdate.Clave = usuarioModel.Clave;
        usuarioToUpdate.Correo = usuarioModel.Correo;
        usuarioToUpdate.NombreCompleto = usuarioModel.NombreCompleto;
        usuarioToUpdate.Estado = usuarioModel.Estado;
        usuarioToUpdate.IdRolUsuario = usuarioModel.IdRolUsuario;
        this.usuarioRepository.Update(usuarioToUpdate);
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("DeleteUsuario")]
    public void Delete(int id)
    {
        var usuarioDeleted = usuarioRepository.GetEntity(id) ?? throw new UsuarioException("Usuario no encontrado");
        this.usuarioRepository.Remove(usuarioDeleted);
    }
}

