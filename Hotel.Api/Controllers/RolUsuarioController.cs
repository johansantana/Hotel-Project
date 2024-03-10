using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
using Hotel.Api.Dtos;
using Hotel.Api.Models;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolUsuarioController : ControllerBase
{
    private readonly IRolUsuarioRepository rolUsuarioRepository;
    public RolUsuarioController(IRolUsuarioRepository rolUsuarioRepository)
    {
        this.rolUsuarioRepository = rolUsuarioRepository;
    }
    // GET: api/<RolUsuarioController>
    [HttpGet("GetRolUsuario")]
    public IActionResult Get()
    {
        var rolUsuario = rolUsuarioRepository.GetEntities().Select(cd => new RolUsuarioGetModel()
        {
            IdRolUsuario = cd.IdRolUsuario,
            Descripcion = cd.Descripcion,
            Estado = cd.Estado
        });
        return Ok(rolUsuario);
    }

    // GET api/<RolUsuarioController>/5
    [HttpGet("GetRolUsuarioById")]
    public IActionResult Get(int id)
    {
        var rolUsuario = rolUsuarioRepository.GetEntity(id) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
        RolUsuarioGetModel rolUsuarioGetModel = new RolUsuarioGetModel()
        {
            IdRolUsuario = rolUsuario.IdRolUsuario,
            Descripcion = rolUsuario.Descripcion,
            Estado = rolUsuario.Estado
        };
        return Ok(rolUsuarioGetModel);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddRolUsuario")]
    public IActionResult Post([FromBody] RolUsuarioAddDto rolUsuarioModel)
    {
        rolUsuarioRepository.Add(new RolUsuario()
        {
            Descripcion = rolUsuarioModel.Descripcion,
            Estado = rolUsuarioModel.Estado
        });

        return Ok("Rol de Usuario agregado");
    }

    // PUT api/<RolUsuarioController>/5
    [HttpPut("UpdateRolUsuario")]
    public IActionResult Put(int id, [FromBody] RolUsuarioUpdateDto rolUsuarioModel)
    {
        var rolUsuarioToUpdate = rolUsuarioRepository.GetEntity(id) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
        rolUsuarioToUpdate.Descripcion = rolUsuarioModel.Descripcion;
        rolUsuarioToUpdate.Estado = rolUsuarioModel.Estado;
        rolUsuarioRepository.Update(rolUsuarioToUpdate);

        return Ok("Rol de Usuario actualizado");
    }

    // DELETE api/<RolUsuarioController>/5
    [HttpDelete("DeleteRolUsuario")]
    public IActionResult Delete(int id)
    {
        var rolUsuarioDeleted = rolUsuarioRepository.GetEntity(id) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
        rolUsuarioRepository.Remove(rolUsuarioDeleted);

        return Ok("Rol de Usuario eliminado");
    }
}
