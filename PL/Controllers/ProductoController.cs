using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            ML.Producto producto = new ML.Producto { Productos = result.Objects };
            return View(producto);
        }
        public IActionResult Descontinuados()
        {
            ML.Result result = BL.Producto.GetDescontinuados();
            ML.Producto producto = new ML.Producto { Productos = result.Objects };
            return View(producto);
        }
        public IActionResult Promedios()
        {
            ML.Result result = BL.Producto.GetPromedios();
            ML.Producto producto = new ML.Producto { Productos = result.Objects };
            return View(producto);
        }
    }
}
