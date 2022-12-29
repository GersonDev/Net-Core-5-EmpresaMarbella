using EMPRESAMARBELLA.DataSources.Entities;
using EMPRESAMARBELLA.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 *
 */
namespace EMPRESAMARBELLA.Domain.Services
{
    public class UsuarioService
    {
        private readonly UsuariosDbContext usuariosDbContext;

        public UsuarioService(UsuariosDbContext usuariosDbContext)
        {
            this.usuariosDbContext = usuariosDbContext;
        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            var usuario = await usuariosDbContext.Usuarios.Where(x => x.Id == usuarioId).SingleOrDefaultAsync();
            return usuario;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            var usuarios = usuariosDbContext.Usuarios;
            return await usuarios.ToListAsync();
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await usuariosDbContext.Usuarios.AddAsync(usuario);
            await usuariosDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ActionResult<Usuario>> PutUsuario(Usuario usuario)
        {
            var result = await usuariosDbContext.Usuarios
                .FirstOrDefaultAsync(e => e.Id == usuario.Id);

            if (result != null) { 
                result.Nombre = usuario.Nombre;
                result.Apellido = usuario.Apellido;
                result.Telefono = usuario.Telefono;

                await usuariosDbContext.SaveChangesAsync();

                return result; 
            }

            return null;
        }
    }
}
