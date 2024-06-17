using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entities
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarea { get; set; }

        [Required(ErrorMessage = "El título de la tarea es requerido")]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Title { get; set; }

        [Required(ErrorMessage = "La descripción de la tarea es requerido")]
        [MinLength(3)]
        [MaxLength(250)]
        public required string Description { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaEstimadaEntrega { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual Estado? Estado { get; set; }

        public int IdPrioridad { get; set; }
        [ForeignKey("IdPrioridad")]
        public virtual Prioridad? Prioridad { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }

        public int IdUsuarioPropietario { get; set; }
        [ForeignKey("IdUsuarioPropietario")]
        public virtual Usuario? UsuarioPropietario { get; set; }

        public int IdUsuarioAsignado { get; set; }
        [ForeignKey("IdUsuarioAsignado")]
        public virtual Usuario? UsuarioAsignado { get; set; }

        public virtual ICollection<Comentario>? Comentarios { get; set; }
    }
}
