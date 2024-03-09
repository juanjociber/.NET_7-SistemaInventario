using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage ="Nombres son requeridos")]
        [MaxLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos son requeridos")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Dirección es requerido")]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ciudad es requerida")]
        [MaxLength(60)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "País es requerido")]
        [MaxLength(60)]
        public string Pais { get; set; }

        [NotMapped] //No permite que se agregue a la tabla de la DB
        public string Role { get; set; }
    }
}
