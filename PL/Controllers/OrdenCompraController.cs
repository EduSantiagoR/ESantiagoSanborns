using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class OrdenCompraController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.OrdenCompra.GetAll();
            ML.OrdenCompra ordenCompra = new ML.OrdenCompra { OrdenesCompra = result.Objects };
            return View(ordenCompra);
        }
        public IActionResult Reporte()
        {
            ML.Result result = BL.OrdenCompra.GetReport();
            ML.OrdenCompra orden = new ML.OrdenCompra { OrdenesCompra = result.Objects };
            return View(orden);
        }
    }
}
