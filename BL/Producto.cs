namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoSanbornsContext context = new DL.EsantiagoSanbornsContext())
                {
                    var query = (from producto in context.Productos
                                 join proveedor in context.Proveedors on producto.IdProveedor equals proveedor.IdProveedor
                                 join categoria in context.Categoria on producto.IdCategoria equals categoria.IdCategoria
                                 join ciudad in context.Ciudads on proveedor.IdCiudad equals ciudad.IdCiudad
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     NombreProducto = producto.Nombre,
                                     Descripcion = producto.Descripcion,
                                     Stock = producto.Stock,
                                     PrecioUnitario = producto.PrecioUnitario,
                                     IdCategoria = categoria.IdCategoria,
                                     NombreCategoria = categoria.Nombre,
                                     IdProveedor = proveedor.IdProveedor,
                                     NombreProveedor = proveedor.Nombre,
                                     ApellidoPaterno = proveedor.ApellidoPaterno,
                                     ApellidoMaterno = proveedor.ApellidoMaterno,
                                     IdCiudad = ciudad.IdCiudad,
                                     NombreCiudad = ciudad.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.Ciudad = new ML.Ciudad();
                            producto.Categoria = new ML.Categoria();

                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.Descripcion = item.Descripcion;
                            producto.Stock = item.Stock;
                            producto.PrecioUnitario = item.PrecioUnitario;
                            producto.Categoria.IdCategora = item.IdCategoria;
                            producto.Categoria.Nombre = item.NombreCategoria;
                            producto.Proveedor.IdProveedor = item.IdProveedor;
                            producto.Proveedor.Nombre = item.NombreProveedor;
                            producto.Proveedor.ApellidoPaterno = item.ApellidoPaterno;
                            producto.Proveedor.ApellidoMaterno = item.ApellidoMaterno;
                            producto.Proveedor.Ciudad.IdCiudad = item.IdCiudad;
                            producto.Proveedor.Ciudad.Nombre = item.NombreCiudad;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los productos.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetDescontinuados()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoSanbornsContext context = new DL.EsantiagoSanbornsContext())
                {
                    var query = (from producto in context.Productos
                                 join categoria in context.Categoria on producto.IdCategoria equals categoria.IdCategoria
                                 join proveedor in context.Proveedors on producto.IdProveedor equals proveedor.IdProveedor
                                 where producto.Estatus == "Descontinuado" 
                                 && (producto.IdProveedor == 4 || producto.IdProveedor == 7 || producto.IdProveedor == 10 || producto.IdProveedor == 12)
                                 && producto.Stock > 0
                                 && producto.PrecioUnitario >= 39 && producto.PrecioUnitario <= 190
                                 orderby producto.IdProveedor, producto.PrecioUnitario ascending
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     NombreProducto = producto.Nombre,
                                     Descripcion = producto.Descripcion,
                                     Stock = producto.Stock,
                                     PrecioUnitario = producto.PrecioUnitario,
                                     Estatus = producto.Estatus,
                                     IdProveedor = producto.IdProveedor,
                                     NombreProveedor = proveedor.Nombre,
                                     IdCategoria = categoria.IdCategoria,
                                     NombreCategoria = categoria.Nombre
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Proveedor = new ML.Proveedor();
                            producto.Categoria = new ML.Categoria();

                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.Descripcion = item.Descripcion;
                            producto.Stock = item.Stock;
                            producto.Estatus = item.Estatus;
                            producto.PrecioUnitario = item.PrecioUnitario;
                            producto.Proveedor.IdProveedor = item.IdProveedor;
                            producto.Proveedor.Nombre = item.NombreProveedor;
                            producto.Categoria.IdCategora = item.IdCategoria;
                            producto.Categoria.Nombre = item.NombreCategoria;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al obtener los productos.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetPromedios()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EsantiagoSanbornsContext context = new DL.EsantiagoSanbornsContext())
                {
                    var query = (from producto in context.Productos
                                 join categoria in context.Categoria on producto.IdCategoria equals categoria.IdCategoria
                                 where producto.PrecioUnitario < 50
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     NombreProducto = producto.Nombre,
                                     PrecioUnitario = producto.PrecioUnitario,
                                     IdCategoria = categoria.IdCategoria,
                                     NombreCat = categoria.Nombre
                                 }).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Categoria = new ML.Categoria();

                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.PrecioUnitario = item.PrecioUnitario;
                            producto.Categoria.IdCategora = item.IdCategoria;
                            producto.Categoria.Nombre = item.NombreCat;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar las ordenes de compra.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
