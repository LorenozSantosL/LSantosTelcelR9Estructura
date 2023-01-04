using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Empleado empleado = new BL.Empleado();
            BL.Result result = BL.Empleado.GetAll();
            empleado.Empleados = new List<object>();
            if(result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = result.Message;
            }
            return View(empleado);
            
        }

        [HttpPost]
        public ActionResult GetAll(string NombreEmpleado)
        {
            BL.Empleado empleado = new BL.Empleado();
            empleado.Empleados = new List<object>();

            BL.Result result = BL.Empleado.GetByNombre(NombreEmpleado);

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = result.Message;
            }

            return View(empleado);
        }

        public ActionResult Delete(int EmpleadoID)
        {
            BL.Result result = BL.Empleado.Delete(EmpleadoID);

            if (result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Error: "+result.Message;
            }

            return PartialView("Modal");
        }
    }
}