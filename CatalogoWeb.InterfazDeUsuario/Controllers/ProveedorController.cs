using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CatalogoWeb.LogicaDeNegocio;
using CatalogoWeb.EntidadesDeNegocio;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class ProveedorController : Controller
    {
        ProveedorBL proveedorBL = new ProveedorBL();

        //Acción que muestra la pagina principal de proveedor
        public async Task<ActionResult> Index(ProveedorEN pProveedor = null)
        {
            if (pProveedor == null)
                pProveedor = new ProveedorEN();
            if (pProveedor.top_aux == 0)//Si no ha puesto cuantos quiere mostrar
                pProveedor.top_aux = 10; //Trae 10 registros por default
            else if (pProveedor.top_aux == -1)//Reseteamos
                pProveedor.top_aux = 0;

            var proveedor = await proveedorBL.BuscarAsync(pProveedor);
            ViewBag.Top = pProveedor.top_aux;
            return View(proveedor);
        }

        // Acción que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var proveedor = await proveedorBL.ObtenerPorIdAsync(new ProveedorEN { Id = id });
            return View(proveedor);
        }

        //Acción que muestra el formulario para agregar un contacto nuevo
        //No ponemos async porque no estamos yendo a la BD
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        //Acción que recibe los datos del formulario para enviarlos a la BD
        //Ponemos async porque vamos a la BD a buscar registros
        //ActionResult devuelve cualquier cosa
        //IActionResult más genérico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProveedorEN pProveedor)
        {
            try
            {
                int result = await proveedorBL.CrearAsync(pProveedor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProveedor);
            }
        }

        //Acción que muestra los datos del registro cargados en el formulario para editarlos
        public async Task<IActionResult> Edit(ProveedorEN pProveedor)
        {
            var proveedor = await proveedorBL.ObtenerPorIdAsync(pProveedor);
            ViewBag.Error = "";
            return View(proveedor);
        }

        //Acción que recibe los datos modificados y los envía a la BD
        [HttpPost]
        [ValidateAntiForgeryToken] //Herramienta que sirve para evitar que nos hagan inyecciones en SQL
        public async Task<IActionResult> Edit(int id, ProveedorEN pProveedor)
        {
            try
            {
                int result = await proveedorBL.ModificarAsync(pProveedor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "";
                return View(pProveedor);
            }
        }

        //Acción que muestra página para confirmar la eliminación
        public async Task<IActionResult> Delete(ProveedorEN pProveedor)
        {
            ViewBag.Error = "";

            var proveedor = await proveedorBL.ObtenerPorIdAsync(pProveedor);
            return View(proveedor);
        }

        //Acción que recibe la confirmación para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProveedorEN pProveedor)
        {
            try
            {
                int result = await proveedorBL.EliminarAsync(pProveedor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProveedor);
            }
        }
    }
}
