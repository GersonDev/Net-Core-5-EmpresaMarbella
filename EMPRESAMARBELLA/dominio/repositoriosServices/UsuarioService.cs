using EMPRESAMARBELLA.dataSourcesContext.Entities;
using EMPRESAMARBELLA.dominio.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMPRESAMARBELLA.dominio.repositoriosServices
{
    public class UsuarioService
    {
        private readonly UsuariosDbContext usuariosDbContext;

        public UsuarioService(UsuariosDbContext usuariosDbContext)
        {
            this.usuariosDbContext = usuariosDbContext;
        }
        public async Task <List<Usuario>> GetUsuarios()
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
    }
}
