using System;
using System.Collections.Generic;

namespace DL;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaCompra { get; set; }
    public string Cliente { get; set; } = null!;
    //
    public string NombreProducto { get; set; }
    public string Proveedor { get; set; }
    public string Ciudad { get; set; }
    //

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
