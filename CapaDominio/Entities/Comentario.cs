using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entities
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComentario { get; set; }

        [MinLength(3)]
        public string? ComentarioTxt {  get; set; }

        public DateTime FechaComentario { get; set; }

        public int IdTarea { get; set; }
        [ForeignKey("IdTarea")]
        public virtual Tarea? Tarea { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get;set; }

    }
}
