using EMPRESAMARBELLA.Domain.Models;
using EMPRESAMARBELLA.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * This is similar to ViewModels 
 */
namespace EMPRESAMARBELLA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("{id}/{mensaje}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id, String mensaje)
        {
            var result = await usuarioService.GetUsuarioById(id);
            if (result != null) {
                return result;
            } else {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = await usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("Usuarios")]
        public async Task<ActionResult<Usuario>> PostUsuarios(Usuario usuario)
        {
            var result = await usuarioService.AddUsuario(usuario);
            if (result != null)
            {
                return result;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, Usuario usuario){

            var usuarioToUpdate = await usuarioService.GetUsuarioById(id);

            if(usuarioToUpdate == null)
            {
                return NotFound($"Usuario with ID = {id} not found");
            }

            return await usuarioService.PutUsuario(usuario);
        
        }
    }
}
