using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negrito.Models
{

    [Table("Especialidade")]

    public class Especialidade

    {

        [Key]

        [Column("IDEspecialidade")]
        [Display(Name = "IDEspecialidade")]
        [Required]
        public int IDEspecialidade { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Especialidade")]
        [Required]
        public string Especialidad { get; set; }

          public ICollection<Profissional> Profissional { get; set; }


    }
}
