using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFranchise_prototipo_2_
{
    public partial class Pedidos1 : System.Web.UI.Page
    {
        Envio clEnv = new Envio();
        Solicitud clSol = new Solicitud();
        Entrega clEnt = new Entrega();
        Control clControl = new Control();
        Empleado clEmp = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                lblUsuario.Text = Session["Usuario"].ToString();
                if (Session["Puesto"].ToString() == "Vendedor")
                {
                    pnlAgregar.Visible = true;
                    pnlEnvio.Visible = false;
                    pnlRecibo.Visible = false;
                    txtCantidad.Enabled = true;
                    txtMedida.Enabled = true;
                    txtMonto.Enabled = true;
                    txtProducto.Enabled = true;
                    ddlCliente.Enabled = true;
                    butAccion.Text = "Registrar";
                }
                else if (Session["Puesto"].ToString() == "Repartidor")
                {
                    pnlAgregar.Visible = false;
                    pnlEnvio.Visible = false;
                    pnlRecibo.Visible = true;
                    clControl.EnvioLB(lbxEnvios);
                }
                else if (Session["Puesto"].ToString() == "Administrador d")
                {
                    pnlAgregar.Visible = false;
                    pnlEnvio.Visible = true;
                    pnlRecibo.Visible = false;
                    clControl.PedidoAsignado(txtPedidoAsignado);
                }
            }
        }

        protected void butRegistroEnvio_Click(object sender, EventArgs e)
        {
            clEnv.InsertarEnv(lblMensaje, calFechaEnvio);
            clControl.PedidoAsignado(txtPedidoAsignado);
        }

        protected void butRegistroRecibo_Click(object sender, EventArgs e)
        {
            clEnt.InsertarRec(lblMensaje, calFechaEntrega, lbxEnvios, txtEstado);
        }

        protected void butAccion_Click(object sender, EventArgs e)
        {
            clSol.Cantidad_Producto = int.Parse(txtCantidad.Text);
            clSol.Empleado = clEmp.ID_Empleado(Session["Empleado"].ToString(), Session["Puesto"].ToString(), Session["Usuario"].ToString());
            clSol.Fecha_Pedido = calFechaPedido.SelectedDate.ToString("MM/dd/yyyy");
            clSol.Medida_Producto = txtMedida.Text;
            clSol.Monto_Pedido = int.Parse(txtMonto.Text);
            clSol.Producto = txtProducto.Text;
            clSol.Insertar(lblMensaje, ddlCliente);
            clControl.PedidoLB(lbxPedidosRegistrados);
        }

        protected void lbxEnvios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxEnvios.SelectedIndex > -1)
                clControl.DatosEnviosRecibo(lbxEnvios, txtDatosEnvioP);
        }

        protected void lbxPedidosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void calFechaPedido_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void calFechaEnvio_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}