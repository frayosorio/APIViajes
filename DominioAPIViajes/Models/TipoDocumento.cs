using System;

namespace DominioAPIViajes.Models;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Sigla { get; set; }

}
