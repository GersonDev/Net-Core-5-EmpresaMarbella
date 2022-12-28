using EMPRESAMARBELLA.dominio.modelos;
using EMPRESAMARBELLA.dominio.repositoriosServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
       
        [HttpGet]
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>>GetUsuarios()
        {
            IEnumerable<Usuario> usuarios;
            usuarios=await usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("Usuarios")]
        public async Task<ActionResult<Usuario>>PostUsuarios(Usuario usuario)
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
    }
}
