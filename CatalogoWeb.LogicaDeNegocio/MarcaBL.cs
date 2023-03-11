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
    public class MarcaBL
    {
        public async Task<int> CrearAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.CrearAsync(pMarca);
        }
        public async Task<int> ModificarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.ModificarAsync(pMarca);
        }
        public async Task<int> EliminarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.EliminarAsync(pMarca);
        }

        public async Task<MarcaEN> ObtenerPorIDAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.ObtenerPorId(pMarca);

        }
        public async Task<List<MarcaEN>> ObtenerTodosAsync()
        {
            return await MarcaDAL.ObtenerTodosAsync();
        }

        public async Task<List<MarcaEN>> BuscarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.BuscarAsync(pMarca);

        }
    }
}
