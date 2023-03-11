using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoWeb.AccesoADatos;
using CatalogoWeb.EntidadesDeNegocio;

namespace CatalogoWeb.LogicaDeNegocio
{
    public class ProveedorBL
    {
        public async Task<int> CrearAsync(ProveedorEN pProveedor)
        {
            return await ProveedorDAL.CrearAsync(pProveedor);
        }
        public async Task<int> ModificarAsync(ProveedorEN pProveedor)
        {
            return await ProveedorDAL.ModificarAsync(pProveedor);
        }
        public async Task<int> EliminarAsync(ProveedorEN pProveedor)
        {
            return await ProveedorDAL.EliminarAsync(pProveedor);
        }

        public async Task<ProveedorEN> ObtenerPorIdAsync(ProveedorEN pProveedor)
        {
            return await ProveedorDAL.ObtenerPorId(pProveedor);

        }
        public async Task<List<ProveedorEN>> ObtenerTodosAsync()
        {
            return await ProveedorDAL.ObtenerTodosAsync();
        }

        public async Task<List<ProveedorEN>> BuscarAsync(ProveedorEN pProveedor)
        {
            return await ProveedorDAL.BuscarAsync(pProveedor);

        }
    }
}
