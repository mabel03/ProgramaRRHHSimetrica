using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionRRHHSimetrica.Models
{
    [Table("EVALUACION_CAND")]
    public class Evaluacion_Cand
    {

        [Key]
        [Column("CODIGO", Order = 0)]
        public int CODIGO { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el candidato")]
        public int CANDIDATO { get; set; }

        [ForeignKey("CANDIDATO")]
        public virtual Candidatos C_CANDIDATO { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el personal")]
        [Column("PERSONAL_RRHH")]
        [MaxLength(21)]
        [Display(Name ="PERSONAL RRHH")]
        public string PERSONAL_RRHH { get; set; }

        [Column("COMENTARIO")]
        [MaxLength(450)]
        public string COMENTARIO { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el estatus")]
        public int ESTATUS { get; set; }

        [ForeignKey("ESTATUS")]
        public virtual Estatus C_ESTATUS { get; set; }

        public DateTime FECHA_TRAN { get; set; }

    }
}