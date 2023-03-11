using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.LogicaDeNegocio;
using CatalogoWeb.EntidadesDeNegocio;
using CatalogoWeb.AccesoADatos;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class MarcaController : Controller
    {
        MarcaBL marcaBL = new MarcaBL();
        // Ación que muestra la página principal de genero
        public async Task<IActionResult> Index(MarcaEN pMarca = null)
        {
            if (pMarca == null)
                pMarca = new MarcaEN();
            if (pMarca.top_aux == 0)
                pMarca.top_aux = 10;
            else if (pMarca.top_aux == -1)
                pMarca.top_aux = 0;

            var marca = await marcaBL.BuscarAsync(pMarca);
            ViewBag.Top = pMarca.top_aux;
            return View(marca);
        }

        // Acción que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var marca = await marcaBL.ObtenerPorIDAsync(new MarcaEN { Id = id });
            return View(marca);
        }

        // Acción que muestra el formulario para agregar un contacto nuevo
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Acción que recibe los datos del formulario para enviarlos a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaEN pMarca)
        {
            try
            {
                int result = await marcaBL.CrearAsync(pMarca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMarca);
            }
        }

        //Acción que muestra los datos del registro cargados en el formulario para editarlos
        public async Task<IActionResult> Edit(MarcaEN pMarca)
        {
            var marca = await marcaBL.ObtenerPorIDAsync(pMarca);
            ViewBag.Error = "";
            return View(marca);
        }

        // Accion que recibe los datos modificados y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MarcaEN pMarca)
        {
            try
            {
                int result = await marcaBL.ModificarAsync(pMarca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Acción que muestra página para confirmar la eliminación
        public async Task<IActionResult> Delete(MarcaEN pMarca)
        {
            ViewBag.Error = "";
            var marca = await marcaBL.ObtenerPorIDAsync(pMarca);
            return View(marca);
        }

        // Acción que recibe la confirmación para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, MarcaEN pMarca)
        {
            try
            {
                int result = await marcaBL.EliminarAsync(pMarca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
