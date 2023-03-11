using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogoWeb.EntidadesDeNegocio
{
    public class GeneroEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo son 10 caracteres")]
        public string Nombre { get; set; }

        public List<ProductoEN> productos { get; set; } //Propiedad de Navegacion
        [NotMapped]
        public int top_aux { get; set; } //propiedad auxiliar que sirve para especificar
                                         //el numero de registros que queremos consultar.
    }
}
