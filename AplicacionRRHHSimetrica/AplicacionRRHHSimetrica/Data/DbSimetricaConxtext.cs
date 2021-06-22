using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AplicacionRRHHSimetrica.Models;

namespace AplicacionRRHHSimetrica.Data
{
    public class DbSimetricaConxtext : DbContext
    {
        public DbSimetricaConxtext()
        {

        }

        public DbSet<Estatus> Estatus_ { get; set; }
        public DbSet<Area_Departments> Area_Departament_ { get; set; }

        public DbSet<Candidatos> Candidatos_ { get; set; }
        public DbSet<Evaluacion_Cand> Evaluacion_Cand_ { get; set; }
    }
}