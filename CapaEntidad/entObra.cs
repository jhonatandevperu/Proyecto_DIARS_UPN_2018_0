using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entObra
    {
        public int ObraID { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string NombreObra { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string ResponsableObra { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string TipoObra { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string UbicacionObra { get; set; }
    }
}
