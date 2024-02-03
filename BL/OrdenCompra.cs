using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdenCompra
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoSanbornsContext context = new DL.EsantiagoSanbornsContext())
                {
                    var query = (from compra in context.OrdenCompras
                                 join producto in context.Productos on compra.IdProducto equals producto.IdProducto
                                 select new
                                 {
                                     IdOrdenCompra = compra.IdOrdenCompra,
                                     Cantidad = compra.Cantidad,
                                     FechaCompra = compra.FechaCompra,
                                     Cliente = compra.Cliente,
                                     IdProducto = producto.IdProducto,
                                     NombreProducto = producto.Nombre,
                                     Descripcion = producto.Descripcion,
                                     PrecioUnitario = producto.PrecioUnitario
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.OrdenCompra ordenCompra = new ML.OrdenCompra();
                            ordenCompra.Producto = new ML.Producto();

                            ordenCompra.IdOrdenCompra = item.IdOrdenCompra;
                            ordenCompra.Cantidad = item.Cantidad;
                            ordenCompra.FechaCompra = item.FechaCompra;
                            ordenCompra.Cliente = item.Cliente;
                            ordenCompra.Producto.IdProducto = item.IdProducto;
                            ordenCompra.Producto.Nombre = item.NombreProducto;
                            ordenCompra.Producto.Descripcion = item.Descripcion;
                            ordenCompra.Producto.PrecioUnitario = item.PrecioUnitario;

                            result.Objects.Add(ordenCompra);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar las ordenes de compra.";
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
        public static ML.Result GetReport()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.EsantiagoSanbornsContext context = new DL.EsantiagoSanbornsContext())
                {
                    var query = context.OrdenCompras.FromSqlRaw("ProductoGetReport").ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.OrdenCompra ordenCompra = new ML.OrdenCompra();
                            ordenCompra.Producto = new ML.Producto();
                            ordenCompra.Producto.Proveedor = new ML.Proveedor();
                            ordenCompra.Producto.Proveedor.Ciudad = new ML.Ciudad();

                            ordenCompra.IdOrdenCompra = item.IdOrdenCompra;
                            ordenCompra.Cliente = item.Cliente;
                            ordenCompra.FechaCompra = item.FechaCompra;
                            ordenCompra.Cantidad = item.Cantidad;
                            ordenCompra.Producto.Nombre = item.NombreProducto;
                            ordenCompra.Producto.Proveedor.Nombre = item.Proveedor;
                            ordenCompra.Producto.Proveedor.Ciudad.Nombre = item.Ciudad;

                            result.Objects.Add(ordenCompra);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al reslizar el reporte.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.Ex = ex;
                result.Correct = true;
            }
            return result;
        }
    }
}
