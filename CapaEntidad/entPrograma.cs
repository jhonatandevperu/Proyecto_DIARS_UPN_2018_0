using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entPrograma
    {
        public int ProgramaID { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Coordinadorprograma { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Descripcionprograma { get; set; }

        [DisplayFormat(DataFormatString = "{0:d-M-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime Fechainicioprograma { get; set; }

        [DisplayFormat(DataFormatString = "{0:d-M-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime Fechafinprograma { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombreprograma { get; set; }

        public entObra Obra { get; set; }
        public entResidente Residente { get; set; }
    }
}
