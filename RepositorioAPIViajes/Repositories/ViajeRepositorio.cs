using DominioAPIViajes.Models;
using Microsoft.EntityFrameworkCore;
using RepositorioAPIViajes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioAPIViajes.Repositories
{
    public class ViajeRepositorio : IViajeRepositorio
    {

        private readonly DbContext context;

        public ViajeRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(Viaje viaje)
        {
            context.Set<Viaje>().Add(viaje);
            context.SaveChanges();
        }

        public void Actualizar(Viaje viaje)
        {
            context.Entry(viaje).State = EntityState.Modified;
            context.SaveChanges();
        }


        public Viaje? ObtenerPorId(int id)
        {
            return context.Set<Viaje>().Find(id);
        }

        public IEnumerable<Viaje> ObtenerTodos()
        {
            return context.Set<Viaje>().ToList();
        }

        public void Eliminar(int id)
        {
            var viaje = context.Set<Viaje>().Find(id);
            if (viaje != null)
            {
                context.Set<Viaje>().Remove(viaje);
                context.SaveChanges();
            }
        }

        public IEnumerable<Viaje> ObtenerPorOrigenDestino(int idOrigen, int idDestino)
        {
            return context.Set<Viaje>().Where<Viaje>(v => v.IdOrigen== idOrigen && v.IdDestino==idDestino);
        }
    }
}
