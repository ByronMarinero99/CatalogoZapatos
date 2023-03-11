using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using CatalogoWeb.EntidadesDeNegocio;
using System.Diagnostics.Contracts;

namespace CatalogoWeb.AccesoADatos
{
    public class GeneroDAL
    {
        public static async Task<int> CrearAsync(GeneroEN pGenero)
        {
            int result = 0; //variable
            using (var bdcontexto = new BDContexto())
            {
                bdcontexto.Add(pGenero);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(GeneroEN pGenero)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var genero = await bdcontexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
                genero.Nombre = pGenero.Nombre;
              

                bdcontexto.Update(genero);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(GeneroEN pGenero)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var genero = await bdcontexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
                bdcontexto.Genero.Remove(genero);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<GeneroEN> ObtenerPorId(GeneroEN pGenero)
        {
            var genero = new GeneroEN();
            using (var bdcontexto = new BDContexto())
            {
                genero = await bdcontexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
            }
            return genero;
        }
        public static async Task<List<GeneroEN>> ObtenerTodosAsync()
        {
            var genero = new List<GeneroEN>();
            using (var bdcontexto = new BDContexto())
            {
                genero = await bdcontexto.Genero.ToListAsync();
            }
            return genero;
        }
        internal static IQueryable<GeneroEN> QuerySelect(IQueryable<GeneroEN> pQuery, GeneroEN pGenero)
        {
            if (pGenero.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pGenero.Id);
            if (!string.IsNullOrWhiteSpace(pGenero.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pGenero.Nombre));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pGenero.top_aux > 0)
                pQuery = pQuery.Take(pGenero.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<GeneroEN>> BuscarAsync(GeneroEN pGenero)
        {
            var genero = new List<GeneroEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Genero.AsQueryable();
                select = QuerySelect(select, pGenero);
                genero = await select.ToListAsync();
            }
            return genero;
        }
    }
}
