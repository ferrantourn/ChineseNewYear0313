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
    

    //[WebMethod]
    //public Usuario getLoginUsuario(string userName, string pass)
    //{
    //    try
    //    {
    //        //ILogicaUsuario le = FabricaLogica.getLogicaUsuario();//
    //        //return le.getLoginUsuario(userName, pass);
    //    }
    //    /*catch (ErrorAlumnoBloqueado exal)
    //    {
    //        throw new SoapException(exal.Message, SoapException.ClientFaultCode, exal.Message);
    //    }*/
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}





































































































































    

}