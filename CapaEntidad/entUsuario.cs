using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public  class entUsuario
    {
        public int UsuarioID { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nombre de usuario no debe ser mayor a 20 caracteres y menos que 3 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombreusuario { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Contraseña no debe ser mayor a 20 caracteres y menos que 3 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Contrasenausuario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public bool Estadousuario { get;  set; }

        public entResidente Residente { get; set; }
    }
}
