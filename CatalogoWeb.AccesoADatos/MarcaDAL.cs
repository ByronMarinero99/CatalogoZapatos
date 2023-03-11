using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoWeb.EntidadesDeNegocio;

namespace CatalogoWeb.AccesoADatos
{
    public class MarcaDAL
    {
        public static async Task<int> CrearAsync(MarcaEN pMarca)
        {
            int result = 0; //variable
            using (var bdcontexto = new BDContexto())
            {
                bdcontexto.Add(pMarca);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(MarcaEN pMarca)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var marca = await bdcontexto.Marca.FirstOrDefaultAsync(m => m.Id == pMarca.Id);
                marca.Nombre = pMarca.Nombre;

                bdcontexto.Update(marca);
                result = await bdcontexto.SaveChangesAsync();

            }
            return result;
        }
        public static async Task<int> EliminarAsync(MarcaEN pMarca)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var marca = await bdcontexto.Marca.FirstOrDefaultAsync(m => m.Id == pMarca.Id);
                bdcontexto.Marca.Remove(marca);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<MarcaEN> ObtenerPorId(MarcaEN pMarca)
        {
            var marca = new MarcaEN();
            using (var bdcontexto = new BDContexto())
            {
                marca = await bdcontexto.Marca.FirstOrDefaultAsync(m => m.Id == pMarca.Id);
            }
            return marca;
        }
        public static async Task<List<MarcaEN>> ObtenerTodosAsync()
        {
            var marca = new List<MarcaEN>();
            using (var bdcontexto = new BDContexto())
            {
                marca = await bdcontexto.Marca.ToListAsync();
            }
            return marca;
        }
        internal static IQueryable<MarcaEN> QuerySelect(IQueryable<MarcaEN> pQuery, MarcaEN pMarca)
        {
            if (pMarca.Id > 0)
                pQuery = pQuery.Where(m => m.Id == pMarca.Id);
            if (!string.IsNullOrWhiteSpace(pMarca.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pMarca.Nombre));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pMarca.top_aux > 0)
                pQuery = pQuery.Take(pMarca.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<MarcaEN>> BuscarAsync(MarcaEN pMarca)
        {
            var marca = new List<MarcaEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Marca.AsQueryable();
                select = QuerySelect(select, pMarca);
                marca = await select.ToListAsync();
            }
            return marca;
        }
        public static async Task<List<MarcaEN>> BuscarIncluirMarcaAsync(MarcaEN pMarca)
        {
            var marca = new List<MarcaEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Marca.AsQueryable();
                select = QuerySelect(select, pMarca).Include(m => m.Productos).AsQueryable();
                marca = await select.ToListAsync();
            }
            return marca;
        }
    }
}
