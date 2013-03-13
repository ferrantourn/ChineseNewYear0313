using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;
using ExcepcionesPersonalizadas;
using System.Xml;

namespace Logica
{
    public class LogicaCuentas : ILogicaCuentas
    {


        public void AltaCuenta(Cuenta c)
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                pc.AltaCuenta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Cuenta> ListarCuentas()
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                return pc.ListarCuentas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Cuenta> ListarCuentasCliente(Cliente c)
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                return pc.BuscarCuentasCliente(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarCuenta(Cuenta c)
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                pc.EliminarCuenta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cuenta BuscarCuenta(Cuenta c)
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                return pc.BuscarCuenta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarCuenta(Cuenta c)
        {
            try
            {
                PersistenciaCuentas pc = new PersistenciaCuentas();
                pc.ModificarCuenta(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void RealizarMovimiento(Movimiento m)
        {
            try
            {
                LogicaCuentas lcuentas = new LogicaCuentas();
                Cuenta cuenta = lcuentas.BuscarCuenta(m.CUENTA);

                if (cuenta != null)
                {
                    PersistenciaMovimientos pc = new PersistenciaMovimientos();

                    if (m.CUENTA.MONEDA != m.MONEDA)
                    {
                        //OBTENEMOS COTIZACION
                        //--------------------
                        LogicaCotizacion lc = new LogicaCotizacion();
                        Cotizacion c = new Cotizacion();
                        c.FECHA = DateTime.Now;
                        c = lc.BuscarCotizacion(c);

                        if (c != null)
                        {
                            decimal montoMovimiento;
                            if (m.CUENTA.MONEDA == "USD")
                            {
                                //la cuenta esta en dolares y el deposito se esta haciendo en pesos
                                montoMovimiento = m.MONTO / c.PRECIOVENTA;
                            }
                            else
                            {
                                //la cuenta esta en pesos y el deposito se esta haciendo en dolares
                                montoMovimiento = m.MONTO * c.PRECIOCOMPRA;
                            }

                            //actualizamos el nuevo monto del movimiento;
                            //-------------------------------------------
                            m.MONTO = montoMovimiento;
                        }
                    }

                    if (m.TIPOMOVIMIENTO == 1 && m.MONTO > cuenta.SALDO)
                    {
                        throw new ErrorSaldoInsuficienteParaRetiro();
                    }

                    pc.RealizarMovimiento(m);
                }
            }
            catch (ErrorSaldoInsuficienteParaRetiro ex)
            {
                throw ex;
            }
            catch (ErrorSucursalNoExiste ex)
            {
                throw ex;
            }
            catch (ErrorUsuarioNoExiste ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void RealizarTransferencia(Movimiento movOrigen, Movimiento movDestino)
        {
            try
            {
                LogicaCuentas lcuentas = new LogicaCuentas();
                Cuenta cuentaOrigen = lcuentas.BuscarCuenta(movOrigen.CUENTA);
                PersistenciaMovimientos pc = new PersistenciaMovimientos();

                //MOVIMIENTO ORIGEN
                if (cuentaOrigen != null)
                {

                    if (movOrigen.CUENTA.MONEDA != movOrigen.MONEDA)
                    {
                        //OBTENEMOS COTIZACION
                        //--------------------
                        LogicaCotizacion lc = new LogicaCotizacion();
                        Cotizacion c = new Cotizacion();
                        c.FECHA = DateTime.Now;
                        c = lc.BuscarCotizacion(c);

                        if (c != null)
                        {
                            decimal montoMovimiento;
                            if (movOrigen.CUENTA.MONEDA == "USD")
                            {
                                //la cuenta esta en dolares y el deposito se esta haciendo en pesos
                                montoMovimiento = movOrigen.MONTO / c.PRECIOVENTA;
                            }
                            else
                            {
                                //la cuenta esta en pesos y el deposito se esta haciendo en dolares
                                montoMovimiento = movOrigen.MONTO * c.PRECIOCOMPRA;
                            }

                            //actualizamos el nuevo monto del movimiento;
                            //-------------------------------------------
                            movOrigen.MONTO = montoMovimiento;
                        }
                    }

                    if (movOrigen.TIPOMOVIMIENTO == 1 && movOrigen.MONTO > cuentaOrigen.SALDO)
                    {
                        throw new ErrorSaldoInsuficienteParaRetiro();
                    }
                }


                //MOVIMIENTO DEPOSITO
                Cuenta cuentaDestino = lcuentas.BuscarCuenta(movDestino.CUENTA);
                if (cuentaDestino != null)
                {

                    if (movOrigen.CUENTA.MONEDA != movOrigen.MONEDA)
                    {
                        //OBTENEMOS COTIZACION
                        //--------------------
                        LogicaCotizacion lc = new LogicaCotizacion();
                        Cotizacion c = new Cotizacion();
                        c.FECHA = DateTime.Now;
                        c = lc.BuscarCotizacion(c);

                        if (c != null)
                        {
                            decimal montoMovimiento;
                            if (movDestino.CUENTA.MONEDA == "USD")
                            {
                                //la cuenta esta en dolares y el deposito se esta haciendo en pesos
                                montoMovimiento = movDestino.MONTO / c.PRECIOVENTA;
                            }
                            else
                            {
                                //la cuenta esta en pesos y el deposito se esta haciendo en dolares
                                montoMovimiento = movDestino.MONTO * c.PRECIOCOMPRA;
                            }

                            //actualizamos el nuevo monto del movimiento;
                            //-------------------------------------------
                            movDestino.MONTO = montoMovimiento;
                        }
                    }

                    //if (movOrigen.TIPOMOVIMIENTO == 1 && movOrigen.MONTO > cuentaDestino.SALDO)
                    //{
                    //    throw new ErrorSaldoInsuficienteParaRetiro();
                    //}

                    //REALIZO LA TRANSFERENCIA
                    //------------------------
                    pc.RealizarTransferencia(movOrigen, movDestino);
                }
            }
            catch (ErrorSaldoInsuficienteParaRetiro ex)
            {
                throw ex;
            }
            catch (ErrorSucursalNoExiste ex)
            {
                throw ex;
            }
            catch (ErrorUsuarioNoExiste ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Movimiento> ConsultaMovimientosCuenta(Cuenta c, DateTime d)
        {
            try
            {
                PersistenciaMovimientos pm = new PersistenciaMovimientos();
                return pm.ConsultaMovimientos(c, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
