using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.EntidadesDeNegocio
{
    public class AdministracionEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El largo máximo son 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código del empleado es requerido")]
        [MaxLength(5, ErrorMessage = "El largo máximo son 5 caracteres")]
        public string CodigoEmpleado { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        [MaxLength(10, ErrorMessage = "El largo máximo son 10 caracteres")]
        public string Clave { get; set; }
        public List<ProductoEN> Producto { get; set; } //propiedad de navegacion

        [NotMapped]
        public int top_aux { get; set; } //propiedad auxiliar que sirve para especificar

    }
}
