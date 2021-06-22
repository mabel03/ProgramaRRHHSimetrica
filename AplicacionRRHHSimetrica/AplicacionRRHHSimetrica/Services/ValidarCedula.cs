using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AplicacionRRHHSimetrica.Data;
using AplicacionRRHHSimetrica.Models;

namespace AplicacionRRHHSimetrica.Services
{
    public class ValidarCedula : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            using (DbSimetricaConxtext db = new DbSimetricaConxtext())
            {
                string Cedula = (string)value;

                Candidatos candidatos = (Candidatos)validationContext.ObjectInstance;
                var existenciaID = candidatos.CODIGO;

                string Mensaje = string.Empty;

                if (existenciaID == 0)
                {

                    if (db.Candidatos_.Any(validarcedula => validarcedula.CEDULA == Cedula))
                    {
                        Mensaje = "Esta cedula ya existe";
                        return new ValidationResult(Mensaje);
                    }

                }

                return ValidationResult.Success;
            }

        }
    }
}