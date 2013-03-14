
using System;

namespace Persistencia
{
    public class FabricaPersistencia:MarshalByRefObject
    {

        public FabricaPersistencia()
        {
        }

        public  IPersistenciaClientes getPersistenciaDocentes()
        {
            return (PersistenciaClientes.GetInstancia());
        }

        //public static IPersistenciaCotizacion getPersistenciaAlumnos()
        public  IPersistenciaCotizacion getPersistenciaAlumnos()

        {
            return (PersistenciaCotizacion.GetInstancia());
        }

        public  IPersistenciaCuentas getPersistenciaEmails()
        {
            return (PersistenciaCuentas.GetInstancia());
        }

        public  IPersistenciaEmpleados getPersistenciaCarpetas()
        {
            return (PersistenciaEmpleados.GetInstancia());
        }

        public IPersistenciaMovimientos getPersistenciaCarpetas()
        {
            return (PersistenciaMovimientos.GetInstancia());
        }

        public IPersistenciaPagos getPersistenciaCarpetas()
        {
            return (PersistenciaPagos.GetInstancia());
        }

        public IPersistenciaPrestamo getPersistenciaCarpetas()
        {
            return (PersistenciaPrestamo.GetInstancia());
        }

        public IPersistenciaSucursal getPersistenciaCarpetas()
        {
            return (PersistenciaSucursal.GetInstancia());
        }
    }

}
