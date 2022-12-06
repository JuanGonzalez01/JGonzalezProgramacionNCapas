using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            ML.Result resultRol = BL.Rol.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultRol.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = $"Error: {result.ErrorMessage}";
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            ML.Result resultRol = BL.Rol.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultRol.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = $"Error: {result.ErrorMessage}";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            ML.Result resultRol = BL.Rol.GetAll();            
            ML.Result resultPaises = BL.Pais.GetAll();            
            
            if (idUsuario == null)
            {
                //Formulario vacio pal ADD
                usuario.Rol = new ML.Rol();

                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            }
            else
            {
                //Formulario lleno por GetByID
                ML.Result result = BL.Usuario.GetByIdEF(idUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            
            usuario.Rol.Roles = resultRol.Objects;
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            HttpPostedFileBase archivo = Request.Files["file"];
            if (archivo.ContentLength != 0)
            {
                byte[] imgBytes = GetBytes(archivo);
                usuario.Imagen = Convert.ToBase64String(imgBytes);
            }
            
            if (usuario.IdUsuario==0)
            {
                ML.Result result = BL.Usuario.AddEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario agregado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            else
            {
                ML.Result result = BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario modificado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete (int? IdUsuario)
        {
            if (IdUsuario == null)
            {
                ViewBag.Message = "Error al intentar encontrar al usuario.";
            }
            else
            {
                ML.Result result = BL.Usuario.DeleteEF(IdUsuario.Value);

                if (result.Correct)
                {
                    ViewBag.Message = "Usuario eliminado con éxito.";
                }
                else
                {
                    ViewBag.Message = $"Error: {result.ErrorMessage}";
                }
            }
            return PartialView("Modal");
        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public byte[] GetBytes(HttpPostedFileBase archivo)
        {
            BinaryReader reader = new BinaryReader(archivo.InputStream);
            byte[] arreglo = reader.ReadBytes((int)archivo.ContentLength);
            
            return arreglo;
        }

        public JsonResult CambiarStatus(byte idUsuario, bool status)
        {
            ML.Result result = BL.Usuario.ChangeStatus(idUsuario, status);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
