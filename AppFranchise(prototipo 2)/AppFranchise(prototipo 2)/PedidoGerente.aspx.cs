using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFranchise_prototipo_2_
{
    public partial class PedidoGerente : System.Web.UI.Page
    {
        Solicitud clPedidos = new Solicitud();
        Control clControl = new Control();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                lblUsuario.Text = Session["Usuario"].ToString();
                ddlAccion.Items.Add("Registrar pedido");
                ddlAccion.Items.Add("Modificar pedido");
                ddlAccion.Items.Add("Cancelar pedido");
                clControl.AñadirListClientes(ddlCliente);
                clControl.PedidoLB(lbxPedidosRegistrados);
                butAccion.Text = "Registrar";
                clPedidos.DatosEnvio(ddlCliente, txtFranquiciaDireccion);
                txtFecha.Visible = false;
                pnlAgregar.Visible = true;
                pnlMostrarPedidos.Visible = true;
                ddlAccion.Visible = true;
                lblInstruccion.Visible = true;
                //Debido a que puede realizar todas las acciones del DropDownList, se permite inicialmente añadir
                txtCantidad.Enabled = true;
                txtMedida.Enabled = true;
                txtMonto.Enabled = true;
                txtProducto.Enabled = true;
                ddlCliente.Enabled = true;
                butAccion.Text = "Registrar";
                lbxPedidosRegistrados.Enabled = true;
                calFechaPedido.Visible = true;
            }
        }

        protected void lbxPedidosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccion.SelectedItem.ToString() == "Modificar pedido")
            {
                if (lbxPedidosRegistrados.SelectedIndex > -1)
                {
                    clPedidos.DatosPedido(lbxPedidosRegistrados, txtCantidad, txtFecha, txtMedida, txtMonto, txtProducto);
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccion.SelectedItem.ToString() == "Registrar pedido")
            {
                lbxPedidosRegistrados.Visible = true;
                txtCantidad.Enabled = true;
                txtMedida.Enabled = true;
                txtMonto.Enabled = true;
                txtProducto.Enabled = true;
                ddlCliente.Enabled = true;
                calFechaPedido.Visible = true;
                txtFecha.Visible = false;
                butAccion.Visible = true;
                txtCantidad.Visible = true;
                txtMedida.Visible = true;
                txtMonto.Visible = true;
                txtProducto.Visible = true;
                ddlCliente.Visible = true;
                //Etiquetas:
                lblPedidoInstruccion.Text = "Ingrese los datos del pedido solicitado: ";
                lblCantidadPedido.Visible = true;
                lblClientePedido.Visible = true;
                lblDestinoPedido.Visible = true;
                lblFechaPedido.Visible = true;
                lblProductoPedido.Visible = true;
                lblMedidaPedido.Visible = true;
                lblMontoPedido.Visible = true;
                //Botón de acción
                butAccion.Text = "Registrar";
            }
            else if (ddlAccion.SelectedItem.ToString() == "Modificar pedido")
            {
                lbxPedidosRegistrados.Visible = true;
                txtCantidad.Enabled = true;
                txtMedida.Enabled = true;
                txtMonto.Enabled = true;
                txtProducto.Enabled = true;
                ddlCliente.Enabled = false;
                calFechaPedido.Visible = false;
                txtFecha.Visible = true;
                butAccion.Visible = true;
                txtCantidad.Visible = true;
                txtMedida.Visible = true;
                txtMonto.Visible = true;
                txtProducto.Visible = true;
                ddlCliente.Visible = false;
                butAccion.Text = "Modificar";
                //Etiquetas:
                lblCantidadPedido.Visible = true;
                lblClientePedido.Visible = false;
                lblDestinoPedido.Visible = false;
                lblFechaPedido.Visible = true;
                lblProductoPedido.Visible = true;
                lblMedidaPedido.Visible = true;
                lblMontoPedido.Visible = true;
                lblPedidoInstruccion.Text = "Seleccione el pedido que desea modificar.";

            }
            else if (ddlAccion.SelectedItem.ToString() == "Cancelar pedido")
            {
                lbxPedidosRegistrados.Visible = true;
                txtCantidad.Enabled = false;
                txtMedida.Enabled = false;
                txtMonto.Enabled = false;
                txtProducto.Enabled = false;
                ddlCliente.Enabled = false;
                txtCantidad.Visible = false;
                txtMedida.Visible = false;
                txtMonto.Visible = false;
                txtProducto.Visible = false;
                ddlCliente.Visible = false;
                calFechaPedido.Visible = false;
                txtFecha.Visible = false;
                butAccion.Visible = true;
                //Etiquetas:
                lblCantidadPedido.Visible = false;
                lblClientePedido.Visible = false;
                lblDestinoPedido.Visible = false;
                lblFechaPedido.Visible = false;
                lblProductoPedido.Visible = false;
                lblMedidaPedido.Visible = false;
                lblMontoPedido.Visible = false;
                butAccion.Text = "Eliminar";
                lblPedidoInstruccion.Text = "Seleccione el pedido que desea eliminar.";
            }

        }

        protected void butAccion_Click(object sender, EventArgs e)
        {
            if (butAccion.Text == "Registrar")
            {
                Empleado clEmp= new Empleado();
                clPedidos.Cantidad_Producto = int.Parse(txtCantidad.Text);
                clPedidos.Empleado = clEmp.ID_Empleado(Session["Empleado"].ToString(), Session["Puesto"].ToString(), Session["Usuario"].ToString());
                clPedidos.Fecha_Pedido = calFechaPedido.SelectedDate.ToString("MM/dd/yyyy");
                clPedidos.Medida_Producto = txtMedida.Text;
                clPedidos.Monto_Pedido = int.Parse(txtMonto.Text);
                clPedidos.Producto = txtProducto.Text;
                clPedidos.Insertar(lblMensaje, ddlCliente);
                clControl.PedidoLB(lbxPedidosRegistrados);
            }
            else if (butAccion.Text == "Modificar")
            {
                clPedidos.Modificar(lbxPedidosRegistrados, lblMensaje, txtProducto, txtCantidad, txtMedida, txtMonto);
                clControl.PedidoLB(lbxPedidosRegistrados);
            }
            else if (butAccion.Text == "Eliminar")
            {
                clPedidos.Eliminar( lblMensaje,lbxPedidosRegistrados);
                clControl.PedidoLB(lbxPedidosRegistrados);
            }

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedIndex >= 0)
            {
                clPedidos.DatosEnvio(ddlCliente, txtFranquiciaDireccion);
            }
        }

        protected void calFechaPedido_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}