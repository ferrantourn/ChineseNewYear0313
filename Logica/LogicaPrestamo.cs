using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    public class LogicaPrestamo : ILogicaPrestamo
    {

        public decimal CalcularMontoCuotaPrestamo(Prestamo p)
        {
            try
            {
                Prestamo prestamo = BuscarPrestamo(p);
                if (prestamo != null)
                {
                    decimal monto = Decimal.Zero;
                    monto = prestamo.MONTO / prestamo.TOTALCUOTAS;
                    return monto;
                }

                return Decimal.Zero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// LISTA LOS PRESTAMOS QUE ESTAN ATRASADOS EN SU PAGO
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<Prestamo> ListarPrestamosAtrasados(Sucursal s)
        {
            try
            {
                PersistenciaPagos pp = new PersistenciaPagos();
                List<Pago> ultimosPagos = pp.ListarUltimoPagoPrestamos(s);

                List<Prestamo> prestamosAtrasados = new List<Prestamo>();

                foreach (Pago pago in ultimosPagos)
                {
                    DateTime fechaUltimoPagoPrestamo = pago.FECHAPAGO;
                    DateTime fechaPagoPrestamoMesActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, pago.PRESTAMO.FECHAEMITIDO.Day);

                    if (fechaPagoPrestamoMesActual > fechaUltimoPagoPrestamo)
                    {
                        if (DateTime.Today > fechaPagoPrestamoMesActual)
                        {
                            prestamosAtrasados.Add(pago.PRESTAMO);
                        }
                    }
                }

                return prestamosAtrasados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Prestamo> ListarPrestamo()
        {
            try
            {
                PersistenciaPrestamo ps = new PersistenciaPrestamo();
                //return ps.ListarPrestamo();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AltaPrestamo(Prestamo s)
        {
            try
            {
                PersistenciaPrestamo pc = new PersistenciaPrestamo();
                //pc.AltaPrestamo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarPrestamo(Prestamo s) //Cancelar prestamo, no elimina solo lo marca como cancelado en la base de datos.
        {
            try
            {
                PersistenciaPrestamo pp = new PersistenciaPrestamo();
                pp.CancelarPrestamo(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Prestamo BuscarPrestamo(Prestamo s)
        {
            try
            {
                PersistenciaPrestamo pp = new PersistenciaPrestamo();
                return pp.BuscarPrestamo(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPrestamo(Prestamo c) //en teoría no se debería poder modificar un presamo, solo buscarlo, o pagar cuotas y cancelar
        {
            try
            {
                PersistenciaPrestamo pc = new PersistenciaPrestamo();
                //pc.ModificarPrestamo(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Pago> IsPrestamoCancelado(ref Prestamo p)
        {
            try
            {
                LogicaPagos lp = new LogicaPagos();
                List<Pago> pagos = lp.ListarPagos(p);

                if (pagos.Count == p.TOTALCUOTAS)
                {
                    p.CANCELADO = true;
                }
                else
                {
                    p.CANCELADO = false;
                }
               
                return pagos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
