using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {

        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<object> Empleados { get; set; }
        public BL.Puesto Puesto { get; set; }
        public BL.Departamento Departamento { get; set; }


        public static BL.Result GetAll()
        {
            BL.Result result = new BL.Result();

            try
            {
                using(DL.LSantosTelcelR9EstructuraEntities context = new DL.LSantosTelcelR9EstructuraEntities())
                {
                    var empleados = context.EmpeladoGetAll().ToList();

                    result.Objects = new List<object>();

                    if(empleados != null)
                    {
                        foreach(var obj in empleados)
                        {
                            BL.Empleado empleado = new BL.Empleado();

                            empleado.EmpleadoID = obj.EmpleadoID;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Departamento = new BL.Departamento();
                            empleado.Departamento.DepartamentoId = obj.DepartamentoId.Value;
                            empleado.Departamento.Descripcion = obj.DescripcionDepartamento;
                            empleado.Puesto = new BL.Puesto();
                            empleado.Puesto.PuestoId = obj.PuestoId.Value;
                            empleado.Puesto.Descripcion = obj.DescripcionPuesto;

                            result.Objects.Add(empleado);
                        }
                        
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error : "+ result.EX;
            }

            return result;
        }

        public static BL.Result GetByNombre(string empleadoNombre)
        {
            BL.Result result = new Result();
            try
            {
                using (DL.LSantosTelcelR9EstructuraEntities context = new DL.LSantosTelcelR9EstructuraEntities())
                {
                    var empleados = context.EmpleadoGetByNombre(empleadoNombre).ToList();

                    result.Objects = new List<object>();

                    if (empleados != null)
                    {
                        foreach(var obj in empleados)
                        {
                            BL.Empleado empleado = new BL.Empleado();

                            empleado.EmpleadoID = obj.EmpleadoID;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;

                            empleado.Departamento = new BL.Departamento();
                            empleado.Departamento.DepartamentoId = obj.DepartamentoId.Value;
                            empleado.Departamento.Descripcion = obj.DescripcionDepartamento;

                            empleado.Puesto = new BL.Puesto();
                            empleado.Puesto.PuestoId = obj.PuestoId.Value;
                            empleado.Puesto.Descripcion = obj.DescripcionPuesto;

                            result.Objects.Add(empleado);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error : " + result.EX;
            }

            return result;
        }


        public static BL.Result Delete(int EmpleadoId)
        {
            BL.Result result = new BL.Result();

            try
            {
                using(DL.LSantosTelcelR9EstructuraEntities context = new DL.LSantosTelcelR9EstructuraEntities())
                {
                    int EmpleadoDeleted = context.EmpleadoDelete(EmpleadoId);

                    if(EmpleadoDeleted > 0)
                    {
                        result.Message = "Se ha eliminado el empleado";
                        result.Correct=true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Error : " + result.EX;
            }
            return result;
        }
        

    }
}
