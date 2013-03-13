using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Logica
{
    interface ILogicaPrestamo
    {
         decimal CalcularMontoCuotaPrestamo(Prestamo p);
         List<Prestamo> ListarPrestamosAtrasados(Sucursal s);
         List<Prestamo> ListarPrestamo();
         void AltaPrestamo(Prestamo s);
         void CancelarPrestamo(Prestamo s);
         Prestamo BuscarPrestamo(Prestamo s);
         void ActualizarPrestamo(Prestamo c);
         List<Pago> IsPrestamoCancelado(ref Prestamo p);
    }
}
