using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Respositories
{
    public interface IAuthRepository
    {
        public Usuario GetUserLogin(Claim claim);
        public Usuario FindUser(String user, String password);
    }

    public class AuthRepository : IAuthRepository
    {
        private AppBibliotecaContext _context;

        public AuthRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public Usuario FindUser(string user, string password)
        {
            var Usuario = _context.Usuarios.Where(o => o.Username == user && o.Password == password).FirstOrDefault();
            return Usuario;
        }

        public Usuario GetUserLogin(Claim claim)
        {
            var user = _context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }

    }
}
