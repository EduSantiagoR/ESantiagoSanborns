using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int IdProveedor { get; set; }

    public int IdCategoria { get; set; }

    public string Estatus { get; set; } = null!;

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
