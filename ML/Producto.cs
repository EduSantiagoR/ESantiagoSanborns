using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string Estatus { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public List<object> Productos { get; set; }
    }
}
