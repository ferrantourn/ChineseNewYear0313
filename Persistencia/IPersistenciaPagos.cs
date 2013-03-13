using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    interface IPersistenciaPagos
    {
        Pago ObtenerUltimoPagoPrestamo(Prestamo p);
        List<Pago> ListarUltimoPagoPrestamos(Sucursal s);
    }
}
