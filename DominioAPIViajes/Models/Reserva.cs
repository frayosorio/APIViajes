using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public int IdViaje { get; set; }

    public int IdEstado { get; set; }

    public int IdTipo { get; set; }

    public int CantidadPasajeros { get; set; }

    public double PrecioPasajero { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual EstadoReserva Estado { get; set; } = null!;

    public virtual TipoViaje Tipo { get; set; } = null!;

    public virtual Viaje Viaje { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
