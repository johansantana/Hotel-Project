using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure;
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
        var rolUsuario = this.rolUsuarioRepository.GetEntities();
        return Ok(rolUsuario);
    }

    // GET api/<RolUsuarioController>/5
    [HttpGet("GetRolUsuarioById")]
    public IActionResult Get(int id)
    {
        var rolUsuario = this.rolUsuarioRepository.GetEntity(id);
        return Ok(rolUsuario);
    }

    // POST api/<UsuarioController>
    [HttpPost("AddRolUsuario")]
    public void Post([FromBody] RolUsuarioAddModel rolUsuarioModel)
    {
        this.rolUsuarioRepository.Add(new RolUsuario()
        {
            Descripcion = rolUsuarioModel.Descripcion,
            Estado = rolUsuarioModel.Estado
        });
    }

    // PUT api/<RolUsuarioController>/5
    [HttpPut("UpdateRolUsuario")]
    public void Put(int id, [FromBody] RolUsuarioAddModel rolUsuarioModel)
    {
        var rolUsuarioToUpdate = rolUsuarioRepository.GetEntity(id) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
        rolUsuarioToUpdate.Descripcion = rolUsuarioModel.Descripcion;
        rolUsuarioToUpdate.Estado = rolUsuarioModel.Estado;
        this.rolUsuarioRepository.Update(rolUsuarioToUpdate);
    }

    // DELETE api/<RolUsuarioController>/5
    [HttpDelete("DeleteRolUsuario")]
    public void Delete(int id)
    {
        var rolUsuarioDeleted = rolUsuarioRepository.GetEntity(id) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
        this.rolUsuarioRepository.Remove(rolUsuarioDeleted);
    }
}
