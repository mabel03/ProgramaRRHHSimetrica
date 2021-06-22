using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AplicacionRRHHSimetrica.Data;
using AplicacionRRHHSimetrica.Models;

namespace AplicacionRRHHSimetrica.Services.CandidatoServices
{
    public class CandidatoServ
    {
        private DbSimetricaConxtext db = new DbSimetricaConxtext();


        public Candidatos BuscarId(int? id)
        {
            try
            {
                Candidatos evaluacion_Cand = db.Candidatos_.Find(id);
                return evaluacion_Cand;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public List<Area_Departments> _Departments()
        {
            return db.Area_Departament_.ToList(); 
        }

        public List<Candidatos> BotonEliminarCandidato()
        {
            var candidatos_ = db.Candidatos_.Include(c => c.C_AREA).ToList();
            var Evaluacion = db.Evaluacion_Cand_;
            for (int i = 0; i < candidatos_.Count(); i++)
            {
                int Codigo = candidatos_[i].CODIGO;
                var decision = Evaluacion.Where(x => x.CANDIDATO == Codigo).FirstOrDefault();
                if (decision != null)
                {
                    candidatos_[i].Decision = true;// no se muestre el boton
                }
                else
                {
                    candidatos_[i].Decision = false; //se nuestre el boton
                }
            }

            return candidatos_.ToList();
        }

        public void AgregarCandidatos(Candidatos candidatos)
        {
            try
            {
                db.Candidatos_.Add(candidatos);
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public void EditarCandidatos(Candidatos candidatos)
        {
            try
            {
                var cand = db.Candidatos_.FirstOrDefault(p => p.CODIGO == candidatos.CODIGO);
                if (cand != null)
                {
                    db.Entry(cand).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void EliminarCandidato(int id)
        {
            try
            {
                Candidatos candidatos = db.Candidatos_.Find(id);
                db.Candidatos_.Remove(candidatos);
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}