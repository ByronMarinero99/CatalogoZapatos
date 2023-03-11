using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoWeb.EntidadesDeNegocio;
using CatalogoWeb.AccesoADatos;
using System.Diagnostics.Contracts;

namespace CatalogoWeb.LogicaDeNegocio
{
    public class GeneroBL
    {
        public async Task<int> CrearAsync(GeneroEN pGenero)
        {
            return await GeneroDAL.CrearAsync(pGenero);
        }
        public async Task<int> ModificarAsync(GeneroEN pGenero)
        {
            return await GeneroDAL.ModificarAsync(pGenero);
        }
        public async Task<int> EliminarAsync(GeneroEN pContacto)
        {
            return await GeneroDAL.EliminarAsync(pContacto);
        }

        public async Task<GeneroEN> ObtenerPorIdAsync(GeneroEN pGenero)
        {
            return await GeneroDAL.ObtenerPorId(pGenero);
        }
        public async Task<List<GeneroEN>> ObtenerTodosAsync()
        {
            return await GeneroDAL.ObtenerTodosAsync();
        }
        public async Task<List<GeneroEN>> BuscarAsync(GeneroEN pGenero)
        {
            return await GeneroDAL.BuscarAsync(pGenero);
        }
    }
}
