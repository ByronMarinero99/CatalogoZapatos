using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoWeb.AccesoADatos;
using CatalogoWeb.EntidadesDeNegocio;

namespace CatalogoWeb.LogicaDeNegocio
{
    public class ProductoBL
    {
        public async Task<int> CrearAsync(ProductoEN pProducto)
        {
            return await ProductoDAL.CrearAsync(pProducto);
        }
        public async Task<int> ModificarAsync(ProductoEN pProducto)
        {
            return await ProductoDAL.ModificarAsync(pProducto);
        }
        public async Task<int> EliminarAsync(ProductoEN pProducto)
        {
            return await ProductoDAL.EliminarAsync(pProducto);
        }

        public async Task<ProductoEN> ObtenerPorIDAsync(ProductoEN pProducto)
        {
            return await ProductoDAL.ObtenerPorIdAsync(pProducto);

        }
        public async Task<List<ProductoEN>> ObtenerTodosAsync()
        {
            return await ProductoDAL.ObtenerTodosAsync();

        }

        public async Task<List<ProductoEN>> BuscarAsync(ProductoEN pProducto)
        {
            return await ProductoDAL.BuscarAsync(pProducto);

        }
        public async Task<List<ProductoEN>> buscarincluirproductoasync(ProductoEN pproducto)
        {
            return await ProductoDAL.BuscarIncluirProductoAsync(pproducto);
        }
    }
}
