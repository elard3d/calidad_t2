using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Respositories
{
    public interface ILibroRepository{
        public Libro GetDetail(int id);
        public void AddComentario(Usuario user, Comentario comentario);
    }
    public class LibroRepository : ILibroRepository
    {

        private AppBibliotecaContext _context;

        public LibroRepository(AppBibliotecaContext context)
        {
            _context = context;
        }
        public void AddComentario(Usuario user, Comentario comentario)
        {
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            _context.Comentarios.Add(comentario);

            var libro = _context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            _context.SaveChanges();
        }

        public Libro GetDetail(int id)
        {
            return _context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
    }
}
