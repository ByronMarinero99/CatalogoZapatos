using CatalogoWeb.EntidadesDeNegocio;
using CatalogoWeb.InterfazDeUsuario.Models;
using CatalogoWeb.LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class HomeController : Controller
    {
        ProveedorBL proveedorBL = new ProveedorBL();
        MarcaBL marcaBL = new MarcaBL();
        GeneroBL generoBL = new GeneroBL();
        ProductoBL productoBL = new ProductoBL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(ProductoEN pProducto = null)
        {
            if (pProducto == null)
                pProducto = new ProductoEN();

            if (pProducto.top_aux == 0)
                pProducto.top_aux = 10;

            else if (pProducto.top_aux == -1)
                pProducto.top_aux = 0;

            var productos = await productoBL.BuscarAsync(pProducto);
            ViewBag.Marcas = await marcaBL.ObtenerTodosAsync();
            ViewBag.Generos = await generoBL.ObtenerTodosAsync();
            ViewBag.Proveedores = await proveedorBL.ObtenerTodosAsync();
            ViewBag.Top = pProducto.top_aux;
            return View(productos);
        }
        public async Task<IActionResult> Details(int id)
        {
            var producto = await productoBL.ObtenerPorIDAsync(new ProductoEN { Id = id });
            producto.Proveedor = await proveedorBL.ObtenerPorIdAsync(new ProveedorEN { Id = producto.ProveedorID });
            producto.Marca = await marcaBL.ObtenerPorIDAsync(new MarcaEN { Id = producto.MarcaID });
            producto.Genero = await generoBL.ObtenerPorIdAsync(new GeneroEN { Id = producto.GeneroID });
            return View(producto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}