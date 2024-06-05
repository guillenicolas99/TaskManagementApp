using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDominio.Entities
{
    public class Prioridad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrioridad { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "La clase es requerida")]
        [MaxLength(50)]
        public required string Clase { get; set; }

        public virtual ICollection<Tarea>? Tareas { get; set; }

    }
}
