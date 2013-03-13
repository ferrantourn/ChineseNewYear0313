using System;
using System.Collections.Generic;
using Entidades;
using Persistencia;
using ExcepcionesPersonalizadas;

namespace Logica
{
    public class LogicaUsuarios : ILogicaUsuarios
    {

        public void AltaUsuario(Usuario u)
        {
            try
            {
                if (u is Cliente)
                {
                    PersistenciaClientes pclientes = new PersistenciaClientes();
                    pclientes.AltaCliente((Cliente)u);
                }
                else
                {
                    PersistenciaEmpleados pempleados = new PersistenciaEmpleados();
                    pempleados.AltaEmpleado((Empleado)u);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ActualizarUsuario(Usuario u)
        {
            try
            {
                if (u is Cliente)
                {
                    PersistenciaClientes pclientes = new PersistenciaClientes();
                    pclientes.ModificarCliente((Cliente)u);
                }
                else
                {
                    PersistenciaEmpleados pempleados = new PersistenciaEmpleados();
                    pempleados.ModificarEmpleado((Empleado)u);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarUsuario(Usuario u)
        {
            try
            {
                if (u is Cliente)
                {
                    PersistenciaClientes pclientes = new PersistenciaClientes();
                    pclientes.EliminarCliente((Cliente)u);
                }
                else
                {
                    PersistenciaEmpleados pempleados = new PersistenciaEmpleados();
                    pempleados.EliminarEmpleado((Empleado)u);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Cliente> ListarClientes()
        {
            try
            {
                PersistenciaClientes pclientes = new PersistenciaClientes();
                return pclientes.ListarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                PersistenciaEmpleados pemp = new PersistenciaEmpleados();
                return pemp.ListarEmpleados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarioPorCi(Usuario u)
        {
            try
            {
                if (u is Cliente)
                {
                    PersistenciaClientes pclientes = new PersistenciaClientes();
                    return pclientes.BuscarClientePorCi((Cliente)u);
                }
                else
                {
                    PersistenciaEmpleados pempleados = new PersistenciaEmpleados();
                    return pempleados.BuscarEmpleadoPorCi((Empleado)u);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Usuario getLoginUsuario(string NombreUsuario, string Pass)
        {
            try
            {
                //ServicioRemoting.ServicioAlumno _objServicioA = new ServicioRemoting.ServicioAlumno();
                PersistenciaClientes pc = new PersistenciaClientes();
                Cliente a = pc.LoginCliente(NombreUsuario, Pass);
                if (a != null)
                {
                    return a;
                }
                else
                {
                    PersistenciaEmpleados pe = new PersistenciaEmpleados();

                    //ServicioRemoting.ServicioDocente _objServicioD = new ServicioRemoting.ServicioDocente();
                    pe.LoginEmpleado(NombreUsuario, Pass);
                    Empleado e = pe.LoginEmpleado(NombreUsuario, Pass);

                    return e;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarPassword(Cliente c, string newPass)
        {
            try
            {
                PersistenciaClientes pc = new PersistenciaClientes();
                pc.ModificarPassword(c, newPass);
            }
            catch (ErrorPasswordActualNoValido ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
