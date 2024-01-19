using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CodigoAlfa { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    public virtual ICollection<Transportador> Transportadores { get; set; } = new List<Transportador>();
}
