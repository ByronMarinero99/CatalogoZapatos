using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.EntidadesDeNegocio;
using CatalogoWeb.LogicaDeNegocio;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class GeneroController : Controller
    {
        GeneroBL generoBL = new GeneroBL();

        // Ación que muestra la página principal de genero
        public async Task<IActionResult> Index(GeneroEN pGenero = null)
        {
            if (pGenero == null)
                pGenero = new GeneroEN();
            if (pGenero.top_aux == 0)
                pGenero.top_aux = 10;
            else if (pGenero.top_aux == -1)
                pGenero.top_aux = 0;

            var genero = await generoBL.BuscarAsync(pGenero);
            ViewBag.Top = pGenero.top_aux;
            return View(genero);
        }

        // Acción que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var genero = await generoBL.ObtenerPorIdAsync(new GeneroEN { Id = id});
            return View(genero);
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
        public async Task<IActionResult> Create(GeneroEN pGenero)
        {
            try
            {
                int result = await generoBL.CrearAsync(pGenero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pGenero);
            }
        }

        //Acción que muestra los datos del registro cargados en el formulario para editarlos
        public async Task<IActionResult> Edit(GeneroEN pGenero)
        {
            var genero = await generoBL.ObtenerPorIdAsync(pGenero);
            ViewBag.Error = "";
            return View(genero);
        }

        // Accion que recibe los datos modificados y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GeneroEN pGenero)
        {
            try
            {
                int result = await generoBL.ModificarAsync(pGenero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "";
                return View(pGenero);
            }
        }

        // Acción que muestra página para confirmar la eliminación
        public async Task<IActionResult> Delete(GeneroEN pGenero)
        {
            ViewBag.Error = "";
            var genero = await generoBL.ObtenerPorIdAsync(pGenero);
            return View(genero);
        }

        // Acción que recibe la confirmación para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GeneroEN pGenero)
        {
            try
            {
                int result = await generoBL.EliminarAsync(pGenero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pGenero);
            }
        }
    }
}
