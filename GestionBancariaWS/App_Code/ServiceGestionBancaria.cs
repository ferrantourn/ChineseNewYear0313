using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
using Entidades;
using Logica;
using System.Xml;
using System;
using ExcepcionesPersonalizadas;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class ServiceGestionBancaria : System.Web.Services.WebService
{
    public ServiceGestionBancaria()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public Usuario getLoginUsuario(string userName, string pass)
    {
        try
        {
            LogicaUsuarios ls = new LogicaUsuarios();
            return ls.getLoginUsuario(userName,pass);
        }
        catch (ErrorUsuarioNoExiste exal)
        {
            throw new SoapException(exal.Message, SoapException.ClientFaultCode, exal.Message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    [WebMethod]
    public XmlDocument ConsultaMovimientos(Cuenta c, DateTime d)
    {
        #region this must go to the web service class
        //ILogicaUsuario le = FabricaLogica.getLogicaUsuario();
        LogicaCuentas lc = new LogicaCuentas();

        List<Movimiento> movs = lc.ConsultaMovimientosCuenta(c, d);
        XmlDocument ArchivoRetornoXml = new XmlDocument();

        XmlNode raiz = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "raiz", null);

        foreach (Movimiento m in movs)
        {
            XmlNode NuevoPadre = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "Cuenta", null);

            //numero movimiento
            XmlNode NumMovimiento = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "NumeroMovimiento", null);
            NumMovimiento.InnerText = Convert.ToString(m.IDMOVIMIENTO);
            NuevoPadre.AppendChild(NumMovimiento);

            //fecha
            XmlNode Fecha = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "Fecha", null);
            Fecha.InnerText = Convert.ToString(m.FECHA);
            NuevoPadre.AppendChild(Fecha);

            //Moneda
            XmlNode Moneda = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "Moneda", null);
            Moneda.InnerText = m.MONEDA;
            NuevoPadre.AppendChild(Moneda);

            //Monto
            XmlNode Monto = ArchivoRetornoXml.CreateNode(XmlNodeType.Element, "Monto", null);
            Monto.InnerText = Convert.ToString(m.MONEDA);
            NuevoPadre.AppendChild(Monto);

            raiz.AppendChild(NuevoPadre);
        }
        ArchivoRetornoXml.AppendChild(raiz);
        return ArchivoRetornoXml;
        #endregion
    }


    public List<Cuenta> ListarCuentasCliente(Usuario u)
    {
        try
        {
            LogicaCuentas pc = new LogicaCuentas();
            return pc.ListarCuentasCliente((Cliente)u);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    

   




































































































































    

}