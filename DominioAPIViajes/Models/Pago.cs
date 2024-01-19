using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public int IdModoPago { get; set; }

    public DateTime Fecha { get; set; }

    public double Valor { get; set; }

    public virtual ModoPago ModoPago { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}
