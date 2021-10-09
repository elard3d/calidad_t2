using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalidadT2.Constantes;

namespace CalidadT2.Respositories
{
    public interface IBibliotecaRepository
    {
        public List<Biblioteca> ListaLibrosBiblioteca(Usuario user);
        public void AgregarABiblioteca(int libro, Usuario user);
        public void MarcadoLeyendo(int libroId, Usuario user);
        public void MarcadoTerminado(int libroId, Usuario user);
    }
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private AppBibliotecaContext _context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public void AgregarABiblioteca(int libro, Usuario user)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            _context.Bibliotecas.Add(biblioteca);
            _context.SaveChanges();
        }

        public List<Biblioteca> ListaLibrosBiblioteca(Usuario user)
        {
            var model = _context.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == user.Id)
                .ToList();

            return model;
        }

        public void MarcadoLeyendo(int libroId, Usuario user)
        {
            var libro = _context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            _context.SaveChanges();
        }

        public void MarcadoTerminado(int libroId, Usuario user)
        {
            var libro = _context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            _context.SaveChanges();
        }
    }
}
