using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();

            if (result.Correct)
            {
                ML.Aseguradora aseguradora = new ML.Aseguradora();
                aseguradora.Aseguradoras = result.Objects;

                return View(aseguradora);
            }
            else
            {
                ViewBag.Message = $"Error: {result.ErrorMessage}";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ML.Result resultUsuarios = BL.Usuario.GetAllEF(new ML.Usuario());

            if (IdAseguradora == null)
            {
                //Formulario vacio pal ADD
                aseguradora.Usuario = new ML.Usuario();
            }
            else
            {
                //Formulario lleno por GetByID
                ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }

            foreach (ML.Usuario usuario in resultUsuarios.Objects)
            {
                usuario.Nombre = $"{usuario.Nombre} {usuario.ApellidoPaterno} {usuario.ApellidoMaterno}";
                //usuario.Nombre = usuario.Nombre + usuario.ApellidoPaterno + usuario.ApellidoMaterno;
            }
            aseguradora.Usuario.Usuarios = resultUsuarios.Objects;

            return View(aseguradora);
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora == 0)
            {
                ML.Result result = BL.Aseguradora.AddEF(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Aseguradora agregada con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            else
            {
                //Update
                ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Aseguradora modificada con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int? IdAseguradora)
        {
            if (IdAseguradora == null)
            {
                ViewBag.Message = "Error al intentar encontrar al usuario.";
            }
            else
            {
                ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora.Value);

                if (result.Correct)
                {
                    ViewBag.Message = "Aseguradora eliminada con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            return PartialView("Modal");
        }
    }
}