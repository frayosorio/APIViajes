using DominioAPIViajes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioAPIViajes.Interfaces
{
    public interface IViajeServicio
    {
        public IEnumerable<Viaje> ObtenerTodos();

        public IEnumerable<Viaje> ObtenerPorOrigenDestino(int idOrigen, int idDestino);

        public Viaje? ObtenerPorId(int id);

        public void Agregar(Viaje viaje);

        public void Actualizar(Viaje viaje);

        public void Eliminar(int id);
    }
}
