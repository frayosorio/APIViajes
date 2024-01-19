using DominioAPIViajes.Models;
using RepositorioAPIViajes.Interfaces;
using ServicioAPIViajes.Interfaces;


namespace ServicioAPIViajes.Services
{
    public class ViajeServicio : IViajeServicio
    {

        private readonly IViajeRepositorio repository;

        public ViajeServicio(IViajeRepositorio repository)
        {
            this.repository = repository;
        }

        public void Actualizar(Viaje viaje)
        {
            repository.Actualizar(viaje);
        }

        public void Agregar(Viaje viaje)
        {
            repository.Agregar(viaje);
        }

        public void Eliminar(int id)
        {
            repository.Eliminar(id);
        }

        public Viaje? ObtenerPorId(int id)
        {
            return repository.ObtenerPorId(id);
        }

        public IEnumerable<Viaje> ObtenerPorOrigenDestino(int idOrigen, int idDestino)
        {
            return repository.ObtenerPorOrigenDestino(idOrigen, idDestino);
        }

        public IEnumerable<Viaje> ObtenerTodos()
        {
            return repository.ObtenerTodos();
        }
    }
}
