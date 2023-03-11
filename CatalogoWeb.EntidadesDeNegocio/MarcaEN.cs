using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogoWeb.EntidadesDeNegocio
{
    public class MarcaEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nomre es requerido")]
        [MaxLength(25, ErrorMessage = "El largo máximo son 20 caracteres")]
        public string Nombre { get; set; }

        public List<ProductoEN> Productos { get; set; } //propiedad de navegacion
        [NotMapped]
        public int top_aux { get; set; } //propiedad auxiliar que sirve para especificar
                                         //el numero de registros que queremos consultar.
    }
}

