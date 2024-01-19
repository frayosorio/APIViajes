using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Transportador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual Pais Pais { get; set; } = null!;

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
