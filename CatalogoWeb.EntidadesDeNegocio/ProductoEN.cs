using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.EntidadesDeNegocio
{
    public class ProductoEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [MaxLength(20, ErrorMessage = "El largo máximo son 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El color del producto es requerido")]
        [MaxLength(20, ErrorMessage = "El largo máximo son 20 caracteres")]
        public string Color { get; set; }

        [Required(ErrorMessage = "La talla del producto es requerido")]
        [MaxLength(50, ErrorMessage = "El largo máximo son 50 caracteres")]
        public string Talla { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido")]
        [MaxLength(10, ErrorMessage = "El largo máximo son 10 caracteres")]
        public string Precio { get; set; }

        [MaxLength(15, ErrorMessage = "El largo máximo son 15 caracteres")]
        public string PrecioAnterior { get; set; }

        [Required(ErrorMessage = "La imagen del producto es requerido")]
        [MaxLength(300, ErrorMessage = "El largo máximo son 300 caracteres")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "La descripción del producto es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El ID del proveedor es requerido")]
        [ForeignKey("Proveedor")]
        [Display(Name = "Proveedor")]
        public int ProveedorID { get; set; }
        public ProveedorEN Proveedor { get; set; } //propiedad de navegacion

        [Required(ErrorMessage = "El ID de la marca es requerido")]
        [ForeignKey("Marca")]
        [Display(Name = "Marca")]
        public int MarcaID { get; set; }
        public MarcaEN Marca { get; set; } //propiedad de navegacion

        [Required(ErrorMessage = "El ID del género es requerido")]
        [ForeignKey("Genero")]
        [Display(Name = "Género")]
        public int GeneroID { get; set; }
        public GeneroEN Genero { get; set; } //propiedad de navegacion

        [Required(ErrorMessage = "El ID del administrador es requerido")]
        [ForeignKey("Administracion")]
        [Display(Name = "Código del administrador")]
        public int AdministracionID { get; set; }
        public AdministracionEN Administracion { get; set; }

        [NotMapped]
        public int top_aux { get; set; } //propiedad auxiliar que sirve para especificar
                                         //el numero de registros que queremos consultar.
    }
}

