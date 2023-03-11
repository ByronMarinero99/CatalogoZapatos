using CatalogoWeb.AccesoADatos;
using CatalogoWeb.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.LogicaDeNegocio
{
    public class AdministracionBL
    {
        public async Task<int> CrearAsync(AdministracionEN pAdministracion)
        {
            return await AdministracionDAL.CrearAsync(pAdministracion);
        }
        public async Task<int> ModificarAsync(AdministracionEN pAdministracion)
        {
            return await AdministracionDAL.ModificarAsync(pAdministracion);
        }
        public async Task<int> EliminarAsync(AdministracionEN pAdministracion)
        {
            return await AdministracionDAL.EliminarAsync(pAdministracion);
        }

        public async Task<AdministracionEN> ObtenerPorIdAsync(AdministracionEN pAdministracion)
        {
            return await AdministracionDAL.ObtenerPorId(pAdministracion);
        }
        public async Task<List<AdministracionEN>> ObtenerTodosAsync()
        {
            return await AdministracionDAL.ObtenerTodosAsync();
        }
        public async Task<List<AdministracionEN>> BuscarAsync(AdministracionEN pAdministracion)
        {
            return await AdministracionDAL.BuscarAsync(pAdministracion);
        }
    }
}
