using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoDocumento { get; set; }

    public string Documento { get; set; } = null!;

    public DateOnly Nacimiento { get; set; }

    public string? Movil { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public int IdCiudad { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual TipoDocumento TipoDocumento { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
