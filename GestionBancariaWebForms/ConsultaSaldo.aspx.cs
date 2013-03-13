using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
using ExcepcionesPersonalizadas;

public partial class ConsultaSaldo : System.Web.UI.Page
{
    public Cliente USUARIO_LOGUEADO
    {
        get
        {
            if (Session["Usuario"] == null)
                return null;
            return (Cliente)Session["Usuario"];
        }
        set
        {
            if (Session["Usuario"] == null)
                Session.Add("Usuario", value);
            else
                Session["Usuario"] = value;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        try
        {
            LogicaCuentas lc = new LogicaCuentas();
          CuentasListRepeater.DataSource =   lc.ListarCuentasCliente(USUARIO_LOGUEADO);
          CuentasListRepeater.DataBind();
        }
        catch (Exception ex)
        {
            lblInfo.Text = ex.Message;
        }
    }
}