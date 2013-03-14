using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;
using ExcepcionesPersonalizadas;
namespace Logica
{
    internal class LogicaCotizacion : ILogicaCotizacion
    {
        //singleton
        //------------------------------------------------
        private static LogicaCotizacion _instancia = null;
        private LogicaCotizacion() { }

        public static LogicaCotizacion GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCotizacion();

            return _instancia;
        }


        public List<Cotizacion> ListarCotizaciones()
        {
            try
            {
                PersistenciaCotizacion ps = new PersistenciaCotizacion();
                return ps.ListarCotizaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AltaCotizacion(Cotizacion s)
        {
            try
            {
                PersistenciaCotizacion pc = new PersistenciaCotizacion();
                pc.AltaCotizacion(s);
            }
            catch (ErrorCotizacionYaExiste ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCotizacion(Cotizacion s)
        {
            try
            {
                PersistenciaCotizacion pc = new PersistenciaCotizacion();
                pc.EliminarCotizacion(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cotizacion BuscarCotizacion(Cotizacion s)
        {
            try
            {
                PersistenciaCotizacion pc = new PersistenciaCotizacion();
                return pc.BuscarCotizacion(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarCotizacion(Cotizacion s, Empleado e)
        {
            try
            {
                PersistenciaCotizacion pc = new PersistenciaCotizacion();
                pc.ModificarCotizacion(s, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
