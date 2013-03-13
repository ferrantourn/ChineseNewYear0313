using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesPersonalizadas;
using Logica;
using Entidades;

public partial class Transferencia : System.Web.UI.Page
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

    public Cuenta CUENTA_DESTINO
    {
        get
        {
            if (Session["CUENTA_DESTINO"] == null)
                return null;
            return (Cuenta)Session["CUENTA_DESTINO"];
        }
        set
        {
            if (Session["CUENTA_DESTINO"] == null)
                Session.Add("CUENTA_DESTINO", value);
            else
                Session["CUENTA_DESTINO"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        try
        {
            LogicaCuentas lc = new LogicaCuentas();
            List<Cuenta> cuentas = lc.ListarCuentasCliente(USUARIO_LOGUEADO);

            if (cuentas != null)
            {
                foreach (Cuenta c in cuentas)
                {
                    ListItem l = new ListItem(c.TOSTRING, Convert.ToString(c.IDCUENTA));
                    ddlCuentas.Items.Add(l);
                }
            }
        }
        catch (Exception ex)
        {
            lblInfo.Text = ex.Message;
        }
    }


    protected void btnBuscaar_Click(object sender, EventArgs e)
    {
        try
        {
            LogicaCuentas lc = new LogicaCuentas();
            int cuentaDest;
            if (Int32.TryParse(txtCuentaDestino.Text, out cuentaDest))
            {
                Cuenta c = new Cuenta { IDCUENTA = cuentaDest };
                c = lc.BuscarCuenta(c);

                if (c != null)
                {
                    CUENTA_DESTINO = c;
                    lblTitular.Text = c.CLIENTE.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblInfo.Text = ex.Message;
        }
    }


    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            LogicaCuentas lc = new LogicaCuentas();
            Cuenta cuentaOrigen = new Cuenta { IDCUENTA = Convert.ToInt32(ddlCuentas.SelectedValue) };

            Movimiento mOrigen = new Movimiento
            {
                CUENTA = cuentaOrigen,
                MONEDA = ddlMoneda.SelectedValue,
                MONTO = Convert.ToDecimal(txtMonto.Text),
                SUCURSAL = cuentaOrigen.SUCURSAL,
                USUARIO = USUARIO_LOGUEADO
            };

            Movimiento mDestino = new Movimiento
            {
                CUENTA = CUENTA_DESTINO,
                MONEDA = ddlMoneda.SelectedValue,
                MONTO = Convert.ToDecimal(txtMonto.Text),
                SUCURSAL = CUENTA_DESTINO.SUCURSAL,
                USUARIO = USUARIO_LOGUEADO
            };

            lc.RealizarTransferencia(mOrigen, mDestino);
            lblInfo.Text = "Transferencia realizada con exito";

        }
        catch (Exception ex)
        {
            lblInfo.Text = ex.Message;
        }
    }
}