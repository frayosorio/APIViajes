using System;
using System.Collections.Generic;

namespace DominioAPIViajes.Models;

public partial class Terminal
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipo { get; set; }

    public string? CodigoIata { get; set; }

    public int IdCiudad { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual TipoTerminal Tipo { get; set; } = null!;

}
