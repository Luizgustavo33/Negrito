using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negrito.Models
{
    [Table("Agendamento")]

    public class Agendamento
    {
        [Key]
        [Column("IDAgendamento")]
        [Display(Name = "IDAgendamento")]
        [Required]
        public int IDAgendamento { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Período (Manhã/tarde/noite)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Periodo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; set; }

        public int Nome_Paciente { get; set; }

        [ForeignKey("Nome_Paciente")]


        public virtual Paciente Paciente { get; set; }

        public int Nome_Profissional { get; set; }

        [ForeignKey("Nome_Profissional")]


        public virtual Profissional Profissional { get; set; }


    }
}
