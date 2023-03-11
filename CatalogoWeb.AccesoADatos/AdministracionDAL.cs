using CatalogoWeb.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.AccesoADatos
{
    public class AdministracionDAL
    {
        public static async Task<int> CrearAsync(AdministracionEN pAdmin)
        {
            int result = 0; //variable
            using (var bdcontexto = new BDContexto())
            {
                bdcontexto.Add(pAdmin);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(AdministracionEN pAdmin)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var admin = await bdcontexto.Administracion.FirstOrDefaultAsync(a => a.Id == pAdmin.Id);
                admin.Nombre = pAdmin.Nombre;
                admin.CodigoEmpleado = pAdmin.CodigoEmpleado;
                admin.Clave = pAdmin.Clave;


                bdcontexto.Update(admin);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(AdministracionEN pAdmin)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var admin = await bdcontexto.Administracion.FirstOrDefaultAsync(a => a.Id == pAdmin.Id);
                bdcontexto.Administracion.Remove(admin);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<AdministracionEN> ObtenerPorId(AdministracionEN pAdmin)
        {
            var admin = new AdministracionEN();
            using (var bdcontexto = new BDContexto())
            {
                admin = await bdcontexto.Administracion.FirstOrDefaultAsync(a => a.Id == pAdmin.Id);
            }
            return admin;
        }
        public static async Task<List<AdministracionEN>> ObtenerTodosAsync()
        {
            var admin = new List<AdministracionEN>();
            using (var bdcontexto = new BDContexto())
            {
                admin = await bdcontexto.Administracion.ToListAsync();
            }
            return admin;
        }
        internal static IQueryable<AdministracionEN> QuerySelect(IQueryable<AdministracionEN> pQuery, AdministracionEN pAdmin)
        {
            if (pAdmin.Id > 0)
                pQuery = pQuery.Where(a => a.Id == pAdmin.Id);
            if (!string.IsNullOrWhiteSpace(pAdmin.Nombre))
                pQuery = pQuery.Where(a => a.Nombre.Contains(pAdmin.Nombre));
            if (pAdmin.Id > 0)
                pQuery = pQuery.Where(a => a.Id == pAdmin.Id);
            if (!string.IsNullOrWhiteSpace(pAdmin.CodigoEmpleado))
                pQuery = pQuery.Where(a => a.CodigoEmpleado.Contains(pAdmin.CodigoEmpleado));
            if (pAdmin.Id > 0)
                pQuery = pQuery.Where(a => a.Id == pAdmin.Id);
            if (!string.IsNullOrWhiteSpace(pAdmin.Clave))
                pQuery = pQuery.Where(a => a.Clave.Contains(pAdmin.Clave));

            pQuery = pQuery.OrderByDescending(a => a.Id).AsQueryable();

            if (pAdmin.top_aux > 0)
                pQuery = pQuery.Take(pAdmin.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<AdministracionEN>> BuscarAsync(AdministracionEN pAdmin)
        {
            var admin = new List<AdministracionEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Administracion.AsQueryable();
                select = QuerySelect(select, pAdmin);
                admin = await select.ToListAsync();
            }
            return admin;
        }

    }
}
