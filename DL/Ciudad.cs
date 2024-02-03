using System;
using System.Collections.Generic;

namespace DL;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
