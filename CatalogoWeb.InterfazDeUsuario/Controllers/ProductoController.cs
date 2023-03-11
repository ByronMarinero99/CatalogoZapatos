using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.LogicaDeNegocio;
using CatalogoWeb.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Contracts;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class ProductoController : Controller
    {
        ProveedorBL proveedorBL = new ProveedorBL();
        MarcaBL marcaBL = new MarcaBL();
        GeneroBL generoBL = new GeneroBL();
        ProductoBL productoBL = new ProductoBL();
        AdministracionBL administracionBL = new AdministracionBL();

        // Acción que muestra la página Proveedor
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

        // Acción que muestra los detalles de un Producto
        public async Task<IActionResult> Details(int id)
        {
            var producto = await productoBL.ObtenerPorIDAsync(new ProductoEN { Id = id });
            producto.Proveedor = await proveedorBL.ObtenerPorIdAsync(new ProveedorEN { Id = producto.ProveedorID });
            producto.Marca = await marcaBL.ObtenerPorIDAsync(new MarcaEN { Id = producto.MarcaID });
            producto.Genero = await generoBL.ObtenerPorIdAsync(new GeneroEN { Id = producto.GeneroID });
            producto.Administracion = await administracionBL.ObtenerPorIdAsync (new AdministracionEN { Id= producto.AdministracionID });
            return View(producto);
        }

        // Acción para agregar un nuevo Producto
        public async Task<IActionResult> Create()
        {
            ViewBag.Proveedores = await proveedorBL.ObtenerTodosAsync();
            ViewBag.Marcas = await marcaBL.ObtenerTodosAsync();
            ViewBag.Generos = await generoBL.ObtenerTodosAsync();
            ViewBag.Administradores = await administracionBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // Acción que recibe los datos del formulario y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoEN pProducto)
        {
            try
            {
                int result = await productoBL.CrearAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Proveedor = await proveedorBL.ObtenerTodosAsync();
                ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
                ViewBag.Genero = await generoBL.ObtenerTodosAsync();
                ViewBag.Administrador = await administracionBL.ObtenerTodosAsync();

                return View(pProducto);
            }
        }

        
        // Acción que muestra los datos del registro cargados en el formulario
        public async Task<IActionResult> Edit(ProductoEN pProducto)
        {
            var producto = await productoBL.ObtenerPorIDAsync(pProducto);
            ViewBag.Proveedores = await proveedorBL.ObtenerTodosAsync();
            ViewBag.Marcas = await marcaBL.ObtenerTodosAsync();
            ViewBag.Generos = await generoBL.ObtenerTodosAsync();
            ViewBag.Administradores = await administracionBL.ObtenerTodosAsync();

            ViewBag.Error = "";
            return View(producto);
        }



        // Acción que recibe los datos modificados para enviarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoEN pProducto)
        {
            try
            {
                int result = await productoBL.ModificarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Proveedores = await proveedorBL.ObtenerTodosAsync();
                ViewBag.Marcas = await marcaBL.ObtenerTodosAsync();
                ViewBag.Generos = await generoBL.ObtenerTodosAsync();
                ViewBag.Administradores = await administracionBL.ObtenerTodosAsync();


                return View(pProducto);
            }
        }

        //  Acción que muestra los datos del registro para confirmar la eliminación
        public async Task<IActionResult> Delete(ProductoEN pProducto)
        {
            var producto = await productoBL.ObtenerPorIDAsync(pProducto);
            producto.Proveedor = await proveedorBL.ObtenerPorIdAsync(new ProveedorEN { Id = producto.ProveedorID });
            producto.Marca = await marcaBL.ObtenerPorIDAsync(new MarcaEN { Id = producto.MarcaID });
            producto.Genero = await generoBL.ObtenerPorIdAsync(new GeneroEN { Id = producto.GeneroID });
            producto.Administracion = await administracionBL.ObtenerPorIdAsync(new AdministracionEN { Id = producto.AdministracionID });

            return View(producto);
            
        }

        // Acción que recibe la confirmación para eliminar un registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductoEN pProducto)
        {
            try
            {
                int result = await productoBL.EliminarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var producto = await productoBL.ObtenerPorIDAsync(pProducto);
                if (producto == null)
                    producto = new ProductoEN();

                if (producto.Id > 0)
                    producto.Proveedor = await proveedorBL.ObtenerPorIdAsync(new ProveedorEN { Id = producto.ProveedorID });
                    producto.Marca = await marcaBL.ObtenerPorIDAsync(new MarcaEN { Id = producto.MarcaID });
                    producto.Genero = await generoBL.ObtenerPorIdAsync(new GeneroEN { Id = producto.GeneroID });
                    producto.Administracion = await administracionBL.ObtenerPorIdAsync(new AdministracionEN { Id = producto.AdministracionID });


                return View(pProducto);
            }
        }
    }
}
