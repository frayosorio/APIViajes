using DominioAPIViajes.Models;


namespace RepositorioAPIViajes.Interfaces
{
    public interface IViajeRepositorio
    {
        public IEnumerable<Viaje> ObtenerTodos();

        public IEnumerable<Viaje> ObtenerPorOrigenDestino(int idOrigen, int idDestino);

        public Viaje? ObtenerPorId(int id);

        public void Agregar(Viaje viaje);

        public void Actualizar(Viaje viaje);

        public void Eliminar(int id);

    }

}
