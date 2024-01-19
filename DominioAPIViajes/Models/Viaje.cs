using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public int IdOrigen { get; set; }

    public int IdDestino { get; set; }

    public int IdTransportador { get; set; }

    public TimeOnly Hora { get; set; }

    public int Duracion { get; set; }

    public double Precio { get; set; }

    public virtual Terminal Destino { get; set; } = null!;

    public virtual Terminal Origen { get; set; } = null!;

    public virtual Transportador Transportador { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
