using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoWeb.EntidadesDeNegocio;


namespace CatalogoWeb.AccesoADatos
{
    public class ProveedorDAL
    {
        public static async Task<int> CrearAsync(ProveedorEN pProveedor)
        {
            int result = 0; //variable
            using (var bdcontexto = new BDContexto())
            {
                bdcontexto.Add(pProveedor);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(ProveedorEN pProveedor)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var proveedor = await bdcontexto.Proveedor.FirstOrDefaultAsync(p => p.Id == pProveedor.Id);
                proveedor.NombreEmpresa = pProveedor.NombreEmpresa;
                proveedor.Direccion = pProveedor.Direccion;
                proveedor.Telefono = pProveedor.Telefono;
                proveedor.Movil = pProveedor.Movil;
                proveedor.Correo = pProveedor.Correo;

                bdcontexto.Update(proveedor);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(ProveedorEN pProveedor)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var proveedor = await bdcontexto.Proveedor.FirstOrDefaultAsync(p => p.Id == pProveedor.Id);
                bdcontexto.Proveedor.Remove(proveedor);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<ProveedorEN> ObtenerPorId(ProveedorEN pProveedor)
        {
            var proveedor = new ProveedorEN();
            using (var bdcontexto = new BDContexto())
            {
                proveedor = await bdcontexto.Proveedor.FirstOrDefaultAsync(p => p.Id == pProveedor.Id);
            }
            return proveedor;
        }
        public static async Task<List<ProveedorEN>> ObtenerTodosAsync()
        {
            var proveedor = new List<ProveedorEN>();
            using (var bdcontexto = new BDContexto())
            {
                proveedor = await bdcontexto.Proveedor.ToListAsync();
            }
            return proveedor;
        }
        internal static IQueryable<ProveedorEN> QuerySelect(IQueryable<ProveedorEN> pQuery, ProveedorEN pProveedor)
        {
            if (pProveedor.Id > 0)
                pQuery = pQuery.Where(p => p.Id == pProveedor.Id);
            if (!string.IsNullOrWhiteSpace(pProveedor.NombreEmpresa))
                pQuery = pQuery.Where(c => c.NombreEmpresa.Contains(pProveedor.NombreEmpresa));
            if (!string.IsNullOrWhiteSpace(pProveedor.Direccion))
                pQuery = pQuery.Where(c => c.Telefono.Contains(pProveedor.Direccion));
            if (!string.IsNullOrWhiteSpace(pProveedor.Telefono))
                pQuery = pQuery.Where(c => c.Telefono.Contains(pProveedor.Telefono));
            if (!string.IsNullOrWhiteSpace(pProveedor.Movil))
                pQuery = pQuery.Where(c => c.Movil.Contains(pProveedor.Movil));
            if (!string.IsNullOrWhiteSpace(pProveedor.Correo))
                pQuery = pQuery.Where(c => c.Correo.Contains(pProveedor.Correo));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pProveedor.top_aux > 0)
                pQuery = pQuery.Take(pProveedor.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<ProveedorEN>> BuscarAsync(ProveedorEN pProveedor)
        {
            var proveedor = new List<ProveedorEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proveedor.AsQueryable();
                select = QuerySelect(select, pProveedor);
                proveedor = await select.ToListAsync();
            }
            return proveedor;
        }
        public static async Task<List<ProveedorEN>> BuscarIncluirProveedorAsync(ProveedorEN pProveedor)
        {
            var proveedor = new List<ProveedorEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proveedor.AsQueryable();
                select = QuerySelect(select, pProveedor).Include(p => p.Producto).AsQueryable();
                proveedor = await select.ToListAsync();
            }
            return proveedor;
        }
    }
}
