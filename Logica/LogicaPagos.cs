using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    public class LogicaPagos : ILogicaPagos
    {
        public void PagarCuota(Prestamo p)
        {
            try
            {
                PersistenciaPrestamo persPrestamo = new PersistenciaPrestamo();
                //persPrestamo.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pago> ListarPagos(Prestamo p)
        {
            try
            {
                PersistenciaPagos ps = new PersistenciaPagos();
                //return ps.ListarPrestamo();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPago(Pago p)
        {
            try
            {
                PersistenciaPagos pc = new PersistenciaPagos();
                //pc.EliminarPrestamo(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pago BuscarPago(Pago p)
        {
            try
            {
                PersistenciaPagos pc = new PersistenciaPagos();
                //return pc.BuscaPrestamo();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
