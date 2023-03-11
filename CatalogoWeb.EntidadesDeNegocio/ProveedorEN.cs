using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.EntidadesDeNegocio
{
    public class ProveedorEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 50 caracteres")]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "La dirección de la empresa es requerida")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 50 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Teléfono de la empresa es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El número móvil es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 15 caracteres")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El correo de la empresa es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 100 caracteres")]
        public string Correo { get; set; }

        public List<ProductoEN> Producto { get; set; } //propiedad de navegacion
        [NotMapped]
        public int top_aux { get; set; } //propiedad auxiliar que sirve para especificar
                                         //el numero de registros que queremos consultar.
    }
}
