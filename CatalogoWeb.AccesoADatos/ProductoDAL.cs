using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoWeb.EntidadesDeNegocio;

namespace CatalogoWeb.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(ProductoEN pProducto)
        {
            int result = 0; //variable
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProducto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(ProductoEN pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                producto.Nombre = pProducto.Nombre;
                producto.Color = pProducto.Color;
                producto.Talla = pProducto.Talla;
                producto.Precio = pProducto.Precio;
                producto.PrecioAnterior = pProducto.PrecioAnterior;
                producto.Imagen = pProducto.Imagen;
                producto.Descripcion = pProducto.Descripcion;
                producto.ProveedorID = pProducto.ProveedorID;
                producto.MarcaID = pProducto.MarcaID;
                producto.GeneroID = pProducto.GeneroID;
                producto.AdministracionID = pProducto.AdministracionID;

                bdContexto.Update(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(ProductoEN pProducto)
        {
            int result = 0;
            using (var bdcontexto = new BDContexto())
            {
                var producto = await bdcontexto.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                bdcontexto.Producto.Remove(producto);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<ProductoEN> ObtenerPorIdAsync(ProductoEN pProducto)
        {
            var producto = new ProductoEN();
            using (var bdcontexto = new BDContexto())
            {
                producto = await bdcontexto.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
            }
            return producto;
        }
        public static async Task<List<ProductoEN>> ObtenerTodosAsync()
        {
            var producto = new List<ProductoEN>();
            using (var bdcontexto = new BDContexto())
            {
                producto = await bdcontexto.Producto.ToListAsync();
            }
            return producto;
        }
        internal static IQueryable<ProductoEN> QuerySelect(IQueryable<ProductoEN> pQuery, ProductoEN pProducto)
        {
            if (pProducto.Id > 0)
                pQuery = pQuery.Where(p => p.Id == pProducto.Id);

            if (pProducto.ProveedorID > 0)
                pQuery.Where(p => p.Id == pProducto.ProveedorID);

            if (pProducto.GeneroID > 0)
                pQuery.Where(p => p.Id == pProducto.GeneroID);

            if (pProducto.MarcaID > 0)
                pQuery.Where(p => p.Id == pProducto.MarcaID);

            if (pProducto.AdministracionID > 0)
                pQuery.Where(p => p.Id == pProducto.AdministracionID);

            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(p => p.Nombre.Contains(pProducto.Nombre));
            if (!string.IsNullOrWhiteSpace(pProducto.Color))
                pQuery = pQuery.Where(p => p.Color.Contains(pProducto.Color));
            if (!string.IsNullOrWhiteSpace(pProducto.Talla))
                pQuery = pQuery.Where(p => p.Talla.Contains(pProducto.Talla));
            if (!string.IsNullOrWhiteSpace(pProducto.Precio))
                pQuery = pQuery.Where(p => p.Precio.Contains(pProducto.Precio));
            if (!string.IsNullOrWhiteSpace(pProducto.PrecioAnterior))
                pQuery = pQuery.Where(p => p.PrecioAnterior.Contains(pProducto.PrecioAnterior));
            if (!string.IsNullOrWhiteSpace(pProducto.Imagen))
                pQuery = pQuery.Where(p => p.Imagen.Contains(pProducto.Imagen));
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))

                pQuery = pQuery.Where(p => p.Descripcion.Contains(pProducto.Descripcion));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pProducto.top_aux > 0)
                pQuery = pQuery.Take(pProducto.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<ProductoEN>> BuscarAsync(ProductoEN pProducto)
        {
            var producto = new List<ProductoEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                producto = await select.ToListAsync();
            }
            return producto;
        }
        public static async Task<List<ProductoEN>> BuscarIncluirProductoAsync(ProductoEN pProducto)
        {
            var producto = new List<ProductoEN>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto).Include(p => p.Proveedor).AsQueryable();
                select = QuerySelect(select, pProducto).Include(p => p.Marca).AsQueryable();
                select = QuerySelect(select, pProducto).Include(p => p.Genero).AsQueryable();
                producto = await select.ToListAsync();
            }
            return producto;
        }
    }
}
