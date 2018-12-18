using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entResidente
    {
        public int ResidenteID { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Apellidosresidente { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Direccionresidente { get; set; }

        [StringLength(50, ErrorMessage = "Este campo no debe tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombresresidente { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Este campo no debe tener más de 10 dígitos.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Telefonoresidente { get; set; }
    }
}
