using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Pais Pais { get; set; } = null!;

    public virtual ICollection<Terminal> Terminales { get; set; } = new List<Terminal>();
}
