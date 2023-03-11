using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoWeb.EntidadesDeNegocio;


namespace CatalogoWeb.AccesoADatos
{
    internal class BDContexto : DbContext
    {
        public DbSet<MarcaEN> Marca  {get; set;}
        public DbSet<GeneroEN> Genero { get; set; }
        public DbSet<ProductoEN> Producto { get; set; }
        public DbSet<ProveedorEN> Proveedor { get; set; }
        public DbSet<AdministracionEN> Administracion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //CONEXION DE JONATHAN
            //options.UseSqlServer(@"Data Source = JONATHAN\SQLEXPRESS; Initial Catalog = CatalogoZapatosBD; Integrated Security = true");
            //CONEXION DE MAURA
            //options.UseSqlServer(@"Data Source = MAURASAURER; Initial Catalog = CatalogoZapatosBD; Integrated Security = true");
            // options.UseSqlServer(@"Data Source = DESKTOP-NFDMETJ; Initial Catalog = CatalogoZapatosBD; Integrated Security = true");
            //Lab
            //options.UseSqlServer(@"Data Source = M02-CI\MSSQLSERVER2019; Initial Catalog = CatalogoZapatosBD; Integrated Security = true");
            //CONEXION KARLA
            //options.UseSqlServer(@"Data Source = DESKTOP-NFDMETJ; Initial Catalog = CatalogoZapatosBD; Integrated Security = true");
            //CONEXION FRANK
            // options.UseSqlServer(@"Data Source=DESKTOP-46UEJO3;Initial Catalog=CatalogoZapatosBD;Integrated Security=True");
            //CONEXION BYRON
            options.UseSqlServer(@"Data Source=.;Initial Catalog=CatalogoZapatosBD;Integrated Security=True");
        }


    }
}
