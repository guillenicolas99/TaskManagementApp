﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public required string Nombre{ get; set; }

        public virtual ICollection<Tarea>? Tareas { get; set; }
    }
}
