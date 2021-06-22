using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionRRHHSimetrica.Models
{
    [Table("ESTATUS")]
    public class Estatus
    {
        [Key]
        [Column("CODIGO", Order = 0)]
        public int CODIGO { get; set; }

        [Required]
        [Column("ESTATUS")]
        [MaxLength(15)]
        public string ESTATUS { get; set; }
    }
}