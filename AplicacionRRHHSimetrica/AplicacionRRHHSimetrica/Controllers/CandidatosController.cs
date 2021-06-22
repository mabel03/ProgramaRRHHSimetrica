using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionRRHHSimetrica.Data;
using AplicacionRRHHSimetrica.Models;
using AplicacionRRHHSimetrica.Services.CandidatoServices;

namespace AplicacionRRHHSimetrica.Controllers
{
    public class CandidatosController : Controller
    {
        private CandidatoServ candidatoServ = new CandidatoServ();

        public ActionResult Index()
        {

            var candidatos = candidatoServ.BotonEliminarCandidato();
            return View(candidatos);
        }

        public ActionResult CrearCandidato()
        {
            ViewBag.AREA = new SelectList(candidatoServ._Departments(), "CODIGO", "NOMBRE");
            return View();
        }

        [HttpPost]
        public ActionResult CrearCandidato(Candidatos candidatos)
        {
            if (ModelState.IsValid)
            {
                candidatoServ.AgregarCandidatos(candidatos);
                return RedirectToAction("Index");
            }

            ViewBag.AREA = new SelectList(candidatoServ._Departments(), "CODIGO", "NOMBRE", candidatos.AREA);
            return View(candidatos);
        }

        public ActionResult EditarCandidatos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos candidatos = candidatoServ.BuscarId(id);
            if (candidatos == null)
            {
                return HttpNotFound();
            }
            ViewBag.AREA = new SelectList(candidatoServ._Departments(), "CODIGO", "NOMBRE", candidatos.AREA);
            return View(candidatos);
        }

        public ActionResult EliminarCnandidatosEva(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos candidatos = candidatoServ.BuscarId(id);
            if (candidatos == null)
            {

            }
            ViewBag.AREA = new SelectList(candidatoServ._Departments(), "CODIGO", "NOMBRE", candidatos.AREA);
            return View(candidatos);
        }

        [HttpPost]
        public ActionResult EditarCandidatos(Candidatos candidatos)
        {
            if (ModelState.IsValid)
            {
                candidatoServ.EditarCandidatos(candidatos);
                return RedirectToAction("Index");
            }
            ViewBag.AREA = new SelectList(candidatoServ._Departments(), "CODIGO", "NOMBRE", candidatos.AREA);
            return View(candidatos);
        }

        public ActionResult EliminarCandidato(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos candidatos = candidatoServ.BuscarId(id);
            if (candidatos == null)
            {
                return HttpNotFound();
            }
            return View(candidatos);
        }

        [HttpPost, ActionName("EliminarCandidato")]
        public ActionResult ConfirmarEliminar(int id)
        {
            candidatoServ.EliminarCandidato(id);
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
