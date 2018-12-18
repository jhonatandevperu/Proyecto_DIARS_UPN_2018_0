using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entTarea
    {
        public int TareaID { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombretarea { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Numerooperariostarea { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Duraciontarea { get; set; }
    }
}
