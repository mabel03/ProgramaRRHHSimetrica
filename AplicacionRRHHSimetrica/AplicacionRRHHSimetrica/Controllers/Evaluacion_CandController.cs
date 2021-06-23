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
        private DbSimetricaConxtext db = new DbSimetricaConxtext();
        private EvaluacionCanServ evaluacionCanServ = new EvaluacionCanServ();

        public ActionResult Index()
        {
            var candidato = Request["CANDIDATO"];
            var evaluacion_Cand_ = db.Evaluacion_Cand_.Include(e => e.C_CANDIDATO).Include(e => e.C_ESTATUS);
          
            if(candidato != null)
            {
                int CodigoCandidato = int.Parse(candidato);
                evaluacion_Cand_ = evaluacion_Cand_.Where(h => h.CANDIDATO == CodigoCandidato);
            }
            ViewBag.CANDIDATO = new SelectList(evaluacionCanServ.ListadoCandidato(), "CODIGO", "NOMBRE");
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
        // BUSCAR CANDIDATO
        public ActionResult Buscar(string palabra)
        {
            IEnumerable<Evaluacion_Cand> libros;
            var candidatos_ = db.Evaluacion_Cand_.Include(c => c.C_CANDIDATO).ToList();
            var Evaluacion = db.Evaluacion_Cand_;
            for (int i = 0; i < candidatos_.Count(); i++)
            {
                int Codigo = candidatos_[i].CODIGO;
                var decision = Evaluacion.Where(x => x.CANDIDATO == Codigo).FirstOrDefault();
            }
            using (var bd = new DbSimetricaConxtext())
            {
                libros = bd.Evaluacion_Cand_;

                if (!String.IsNullOrEmpty(palabra))
                {
                    //libros = candidatos_.Where(l => l.CANDIDATO.ToUpper().Contains(palabra.ToUpper()));
                }

                libros = libros.ToList();
            }

            return View(libros);
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
