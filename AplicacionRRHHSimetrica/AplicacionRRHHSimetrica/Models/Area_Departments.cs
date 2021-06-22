using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicacionRRHHSimetrica.Models
{
    [Table("AREA_DEAPARTMENTO")]
    public class Area_Departments
    {
        [Key]
        [Column("CODIGO", Order = 0)]
        public int CODIGO { get; set; }

        [Required]
        [Column("NOMBRE")]
        [MaxLength(25)]
        public string NOMBRE { get; set; }

    }
}