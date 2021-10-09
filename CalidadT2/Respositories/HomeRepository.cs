using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Respositories
{


    public interface IHomeRepository
    {
        public List<Libro> ListaLibros();
    }
    public class HomeRepository : IHomeRepository
    {
        private AppBibliotecaContext _context;

        public HomeRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public List<Libro> ListaLibros()
        {
            return _context.Libros.Include(o => o.Autor).ToList();
        }
    }
}
