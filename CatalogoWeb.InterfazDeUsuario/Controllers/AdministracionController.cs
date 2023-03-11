using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CatalogoWeb.LogicaDeNegocio;
using CatalogoWeb.EntidadesDeNegocio;
using CatalogoWeb.AccesoADatos;

namespace CatalogoWeb.InterfazDeUsuario.Controllers
{
    public class AdministracionController : Controller
    {
        AdministracionBL administracionBL = new AdministracionBL();
        // GET: AdministracionController
        public async Task<ActionResult> Index(AdministracionEN pAdministracion = null)
        {
            if (pAdministracion == null)
                pAdministracion = new AdministracionEN();
            if (pAdministracion.top_aux == 0)//Si no ha puesto cuantos quiere mostrar
                pAdministracion.top_aux = 10; //Trae 10 registros por default
            else if (pAdministracion.top_aux == -1)//Reseteamos
                pAdministracion.top_aux = 0;

            var proveedor = await administracionBL.BuscarAsync(pAdministracion);
            ViewBag.Top = pAdministracion.top_aux;
            return View(proveedor);
        }

        // GET: AdministracionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var administracion = await administracionBL.ObtenerPorIdAsync(new AdministracionEN { Id = id });
            return View(administracion);
        }

        // GET: AdministracionController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: AdministracionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdministracionEN pAdministracion)
        {
            try
            {
                int result = await administracionBL.CrearAsync(pAdministracion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pAdministracion);
            }
        }

        // GET: AdministracionController/Edit/5
        public async Task<IActionResult> Edit(AdministracionEN pAdministracion)
        {
            var administracion = await administracionBL.ObtenerPorIdAsync(pAdministracion);
            ViewBag.Error = "";
            return View(administracion);
        }

        // POST: AdministracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdministracionEN pAdministracion)
        {
            try
            {
                int result = await administracionBL.ModificarAsync(pAdministracion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "";
                return View(pAdministracion);
            }
        }

        // GET: AdministracionController/Delete/5
        public async Task<IActionResult> Delete(AdministracionEN pAdministracion)
        {
            ViewBag.Error = "";

            var administracion = await administracionBL.ObtenerPorIdAsync(pAdministracion);
            return View(administracion);
        }

        // POST: AdministracionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdministracionEN pAdministracion)
        {
            try
            {
                int result = await administracionBL.EliminarAsync(pAdministracion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pAdministracion);
            }
        }
    }
}
