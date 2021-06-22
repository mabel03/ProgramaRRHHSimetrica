using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AplicacionRRHHSimetrica.Services;

namespace AplicacionRRHHSimetrica.Models
{
    [Table("CANDIDATOS")]
    public class Candidatos
    {
        [Key]
        [Column("CODIGO", Order = 0)]
        public int CODIGO { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el nombre")]
        [Column("NOMBRE")]
        [MaxLength(25)]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el apellido")]
        [Column("APELLIDO")]
        [MaxLength(30)]
        public string APELLIDO { get; set; }

        [ValidarCedula]
        [Required(ErrorMessage = "Es obligatorio ingresar el cedula")]
        [Column("CEDULA")]
        [MaxLength(11)]
        public string CEDULA { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el email")]
        [EmailAddress]
        [Column("EMAIL")]
        [MaxLength(21)]
        public string EMAIL { get; set; }

        [Column("DIRECCION")]
        [MaxLength(21)]
        public string DIRECCION { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el lenguaje")]
        [Column("LENGUAJE_PRO")]
        [MaxLength(20)]
        public string LENGUAJE_PRO { get; set; }

        [Column("EXPERIENCIA")]
        [MaxLength(500)]
        public string EXPERIENCIA { get; set; }

        [Column("TIEMPO_EXPE")]
        public int TIEMPO_EXPE { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el area")]
        public int AREA { get; set; }

        [ForeignKey("AREA")]
        public virtual Area_Departments C_AREA { get; set; }

        [NotMapped]
        public bool Decision { get; set; }
    }
}