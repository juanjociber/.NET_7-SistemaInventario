using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es obligatorio")]
        [MaxLength(60,ErrorMessage ="Nombre debe tener máximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Descripcion es obligatorio")]
        [MaxLength(100,ErrorMessage ="Descripción debe tener máximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="Estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
