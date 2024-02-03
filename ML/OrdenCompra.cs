using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class OrdenCompra
    {
        public int IdOrdenCompra { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Cliente { get; set; }
        public List<object> OrdenesCompra { get; set; }
    }
}
