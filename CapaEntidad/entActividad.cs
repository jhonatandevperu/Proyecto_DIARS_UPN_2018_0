using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entActividad
    {
        public int ActividadID { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombreactividad { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Prioridadactividad { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime Fechainicioactividad { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime Fechafinactividad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Totaloperariosactividad { get; set; }
    }
}
