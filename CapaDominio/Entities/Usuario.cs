using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario{ get; set; }

        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El correo del usuario es requerido")]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        [MinLength(8)]
        public required string Password { get; set; }

        public ICollection<Tarea>? TareasPropietario { get; set; }
        public ICollection<Tarea>? TareasAsignado { get; set; }
        public ICollection<Comentario>? Comentarios {  get; set; }

    }
}
