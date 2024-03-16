using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Dtos;
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
    [HttpGet("GetUsuarios")]
    public IActionResult Get()
    {
        var usuario = usuarioRepository.GetEntities().Select(cd => new UsuarioGetModel()
        {
            IdUsuario = cd.IdUsuario,
            NombreCompleto = cd.NombreCompleto,
            Correo = cd.Correo,
            IdRolUsuario = cd.IdRolUsuario,
            Clave = cd.Clave,
            Estado = cd.Estado,
            FechaCreacion = cd.FechaCreacion,
        });
        return Ok(usuario);
    }

    // GET api/<UsuarioController>/5
    [HttpGet("GetUsuarioById")]
    public IActionResult Get(int id)
    {
        var usuario = usuarioRepository.GetEntity(id) ?? throw new UsuarioException("Usuario no encontrado");
        UsuarioGetModel usuarioGetModel = new UsuarioGetModel()
        {
            IdUsuario = usuario.IdUsuario,
            NombreCompleto = usuario.NombreCompleto,
            Correo = usuario.Correo,
            IdRolUsuario = usuario.IdRolUsuario,
            Clave = usuario.Clave,
            Estado = usuario.Estado,
            FechaCreacion = usuario.FechaCreacion,
        };
        return Ok(usuarioGetModel);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddUsuario")]
    public IActionResult Post([FromBody] UsuarioAddDto usuarioAddDto)
    {
        usuarioRepository.Add(new Usuario()
        {
            NombreCompleto = usuarioAddDto.NombreCompleto,
            Correo = usuarioAddDto.Correo,
            Clave = usuarioAddDto.Clave,
            Estado = usuarioAddDto.Estado,
            IdRolUsuario = usuarioAddDto.IdRolUsuario,
            FechaCreacion = usuarioAddDto.FechaCreacion,
        });

        return Ok("Usuario creado");
    }

    // PUT api/<UsuarioController>/5
    [HttpPut("UpdateUsuario")]
    public IActionResult Put(int id, [FromBody] UsuarioUpdateDto usuarioUpdateDto)
    {
        var usuarioToUpdate = usuarioRepository.GetEntity(id) ?? throw new UsuarioException("Usuario no encontrado");
        usuarioToUpdate.Clave = usuarioUpdateDto.Clave;
        usuarioToUpdate.Correo = usuarioUpdateDto.Correo;
        usuarioToUpdate.NombreCompleto = usuarioUpdateDto.NombreCompleto;
        usuarioToUpdate.Estado = usuarioUpdateDto.Estado;
        usuarioToUpdate.IdRolUsuario = usuarioUpdateDto.IdRolUsuario;
        usuarioRepository.Update(usuarioToUpdate);

        return Ok("Usuario actualizado");
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("DeleteUsuario")]
    public IActionResult Delete(int id)
    {
        var usuarioDeleted = usuarioRepository.GetEntity(id) ?? throw new UsuarioException("Usuario no encontrado");
        usuarioRepository.Remove(usuarioDeleted);

        return Ok("Usuario eliminado");
    }
}

