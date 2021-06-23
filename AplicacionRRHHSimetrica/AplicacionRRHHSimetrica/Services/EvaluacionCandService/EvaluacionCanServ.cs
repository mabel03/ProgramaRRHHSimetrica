using System;
using System.Collections.Generic;
using System.Linq;
using AplicacionRRHHSimetrica.Models;
using AplicacionRRHHSimetrica.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace AplicacionRRHHSimetrica.Services.EvaluacionCandService
{
    public class EvaluacionCanServ
    {
        private DbSimetricaConxtext db = new DbSimetricaConxtext();

        public Evaluacion_Cand BuscarId(int? id)
        {
            try
            {
                Evaluacion_Cand evaluacion_Cand = db.Evaluacion_Cand_.Find(id);
                return evaluacion_Cand;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        //public Evaluacion_Cand BuscarCandidato()
        //{
        //    List<>
        //}

        public List<Candidatos> ListadoCandidato()
        {
            return db.Candidatos_.ToList();
        }

        public List<Estatus> ListadoEstatus()
        {
            return db.Estatus_.ToList();
        }
         
        public List<Evaluacion_Cand> ListadoEvaluacion()
        {
            return db.Evaluacion_Cand_.ToList();
        }

        public void AgregarEvaluacion(Evaluacion_Cand evaluacion_)
        {
            try
            {
                evaluacion_.FECHA_TRAN = DateTime.Now;
                db.Evaluacion_Cand_.Add(evaluacion_);
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public void EditarEvaluacion(Evaluacion_Cand evaluacion_)
        {
            try
            {
                var evaluacion = db.Evaluacion_Cand_.FirstOrDefault(p => p.CODIGO == evaluacion_.CODIGO);
                if (evaluacion != null)
                {
                    db.Entry(evaluacion).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void EliminarEvaluacion(int id)
        {
            try
            {
                Evaluacion_Cand evaluacion_Cand = db.Evaluacion_Cand_.Find(id);
                db.Evaluacion_Cand_.Remove(evaluacion_Cand);
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        private List<Evaluacion_Cand> evaluacion_s;

    }
}