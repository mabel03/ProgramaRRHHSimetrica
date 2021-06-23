using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AplicacionRRHHSimetrica.Data;
using AplicacionRRHHSimetrica.Models;
using AplicacionRRHHSimetrica.Services.EvaluacionCandService;

namespace AplicacionRRHHSimetrica.Controllers
{
    public class Evaluacion_CandController : Controller
    {
        private EvaluacionCanServ evaluacionCanServ = new EvaluacionCanServ();

        public ActionResult Index()
        {
            var candidato = Request["CANDIDATO"];
            var evaluacion_Cand_ = evaluacionCanServ.BuscarCandidato();


            if (candidato != null)
            {
                int CodigoCandidato = int.Parse(candidato);
                evaluacion_Cand_ = evaluacion_Cand_.Where(h => h.CANDIDATO == CodigoCandidato).ToList();
            }
            List<Candidatos> lista = new List<Candidatos>();
            lista.Add(null);
            lista.AddRange(evaluacionCanServ.ListadoCandidato());
                
            ViewBag.CANDIDATO = new SelectList(lista, "CODIGO", "NOMBRE");
            return View(evaluacion_Cand_);
        }


        public ActionResult CrearEvaluacion()
        {
            ViewBag.CANDIDATO = new SelectList(evaluacionCanServ.ListadoCandidato(), "CODIGO", "NOMBRE");
            ViewBag.ESTATUS = new SelectList(evaluacionCanServ.ListadoEstatus(), "CODIGO", "ESTATUS");
            return View();
        }

        [HttpPost]
        public ActionResult CrearEvaluacion(Evaluacion_Cand evaluacion_Cand)
        {
            if (ModelState.IsValid)
            {
                evaluacionCanServ.AgregarEvaluacion(evaluacion_Cand);
                return RedirectToAction("Index");
            }

            ViewBag.CANDIDATO = new SelectList(evaluacionCanServ.ListadoCandidato(), "CODIGO", "NOMBRE", evaluacion_Cand.CANDIDATO);
            ViewBag.ESTATUS = new SelectList(evaluacionCanServ.ListadoEstatus(), "CODIGO", "ESTATUS", evaluacion_Cand.ESTATUS);
            return View(evaluacion_Cand);
        }

        public ActionResult EditarEvaluacion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion_Cand evaluacion_Cand = evaluacionCanServ.BuscarId(id);
            if (evaluacion_Cand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANDIDATO = new SelectList(evaluacionCanServ.ListadoCandidato(), "CODIGO", "NOMBRE", evaluacion_Cand.CANDIDATO);
            ViewBag.ESTATUS = new SelectList(evaluacionCanServ.ListadoEstatus(), "CODIGO", "ESTATUS", evaluacion_Cand.ESTATUS);
            return View(evaluacion_Cand);
        }

        [HttpPost]
        public ActionResult EditarEvaluacion (Evaluacion_Cand evaluacion_Cand)
        {
            if (ModelState.IsValid)
            {
                evaluacionCanServ.EditarEvaluacion(evaluacion_Cand);
                return RedirectToAction("Index");
            }
            ViewBag.CANDIDATO = new SelectList(evaluacionCanServ.ListadoCandidato(), "CODIGO", "NOMBRE", evaluacion_Cand.CANDIDATO);
            ViewBag.ESTATUS = new SelectList(evaluacionCanServ.ListadoEstatus(), "CODIGO", "ESTATUS", evaluacion_Cand.ESTATUS);
            return View(evaluacion_Cand);
        }

        public ActionResult EliminarEvaluacion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion_Cand evaluacion_Cand = evaluacionCanServ.BuscarId(id);
            if (evaluacion_Cand == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion_Cand);
        }

        [HttpPost, ActionName("EliminarEvaluacion")]
        public ActionResult EliminarConfirmar(int id)
        {
            evaluacionCanServ.EliminarEvaluacion(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
