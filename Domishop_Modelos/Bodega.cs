using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domishop_Modelos
{
    public class Bodega
    {
        //------------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }

        //------------------------------------------------------------------------------
        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage ="El maximo es de 60 Caracteres")]
        public string Nombre { get; set; } = string.Empty;

        //------------------------------------------------------------------------------
        [Required(ErrorMessage = "Descripcion es Requerido")]
        [MaxLength(100, ErrorMessage = "El maximo es de 100 Caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        //------------------------------------------------------------------------------
        [Required(ErrorMessage = "Descripcion es Requerido")]
        public bool Estado { get; set; }
    }
}
