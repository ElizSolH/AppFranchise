using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFranchise_prototipo_2_
{
    public partial class Franquicias : System.Web.UI.Page
    {
        Control clControl = new Control();
        Franquicia clFranquicia = new Franquicia();
        Cliente clClientes = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    ddlAccion.Items.Add("Registrar");
                    ddlAccion.Items.Add("Modificar");
                    ddlAccion.Items.Add("Eliminar");
                    pnlContenido.Visible = true;
                    pnlAgregar.Visible = false;
                    pnlCliente.Visible = false;
                    clControl.FranquiciasRegistradas(lbxFranquicias);
                    butClienteAccion.Text = "Añadir representante(s)";
                    butIniciarClientes.Visible = false;
                    lbxClientes.Items.Add("Seleccione una franquicia");
                    lblUsuario.Text = Session["Empleado"].ToString();
                }
                catch (Exception err)
                {
                    lblMensaje.Text = err.Message;
                }
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccion.SelectedItem.ToString() == "Registrar")
            {
                butIniciarFranquicia.Text = "Añadir franquicia";
                butIniciarClientes.Text = "Añadir representante(s)";
                pnlContenido.Visible = false;
                butIniciarClientes.Visible = true;
                butClienteAccion.Enabled = true;
                butAgregaCliente.Visible = true;
                butEliminarUltimo.Visible = true;
            }
            else if (ddlAccion.SelectedItem.ToString() == "Modificar")
            {
                butIniciarFranquicia.Text = "Modificar franquicia";
                butIniciarClientes.Text = "Modificar representante";
                pnlContenido.Visible = false;
                butClienteAccion.Enabled = true;
                butAgregaCliente.Visible = false;
                butEliminarUltimo.Visible = false;
            }
            else if (ddlAccion.SelectedItem.ToString() == "Eliminar")
            {
                butIniciarFranquicia.Text = "Eliminar franquicia";
                butIniciarClientes.Text = "Eliminar representante";
                pnlContenido.Visible = false;
                butClienteAccion.Enabled = false;
                butEliminarUltimo.Visible = false;
            }
        }

        protected void lbxFranquicias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = lbxFranquicias.SelectedIndex;
            if (lbxFranquicias.SelectedIndex >= 0)
            {
                clControl.ClienteDeFranquicia(lbxFranquicias, lbxClientes);
                butIniciarClientes.Visible = true;
                butClienteAccion.Enabled = false;
            }       
        }

        protected void lbxClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void butIniciarFranquicia_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContenido.Visible = true;
                if (ddlAccion.SelectedItem.ToString() == "Registrar")
                {
                    pnlAgregar.Visible = true;
                    pnlCliente.Visible = false;
                    txtDireccion.Enabled = true;
                    txtPais.Enabled = true;
                    txtTelfFranquicia.Enabled = true;
                    butFranquiciaAccion.Text = "Añadir";
                }
                else if (ddlAccion.SelectedItem.ToString() == "Modificar")
                {
                    pnlAgregar.Visible = true;
                    pnlCliente.Visible = false;
                    txtDireccion.Enabled = true;
                    txtPais.Enabled = true;
                    txtTelfFranquicia.Enabled = true;
                    clFranquicia.FranquiciaDatos(txtDireccion, txtPais, txtTelfFranquicia, Control.lstFranquicias, lbxFranquicias);
                    butFranquiciaAccion.Text = "Modificar";
                }
                else if (ddlAccion.SelectedItem.ToString() == "Eliminar")
                {
                    clFranquicia.FranquiciaDatos(txtDireccion, txtPais, txtTelefonoCliente, Control.lstFranquicias, lbxFranquicias);
                    clFranquicia.EliminarFranquicia(lblMensaje);
                    clControl.FranquiciasRegistradas(lbxFranquicias);
                }
            }
            catch (Exception err)
            {
                pnlContenido.Visible = false;
                lblMensaje.Text = "Ha sucedido un error: " + err.Message;
                lblMensaje.Text = err.Message.Replace("El índice estaba fuera del intervalo. Debe ser un valor no negativo e inferior al tamaño de la colección.\r\nNombre del parámetro: index", "Seleccione una franquicia para poder modificar sus datos.");
            }
        }

        protected void butFranquiciaAccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (butFranquiciaAccion.Text == "Añadir")
                {
                    clFranquicia.Direccion = txtDireccion.Text;
                    clFranquicia.Pais_fr = txtPais.Text;
                    clFranquicia.Telefono_Fr = txtTelfFranquicia.Text;
                    clFranquicia.RegistrarFranquicia(lblMensaje);
                    clControl.FranquiciasRegistradas(lbxFranquicias);
                }
                else if (butFranquiciaAccion.Text == "Modificar")
                {
                    clFranquicia.Pais_fr = txtPais.Text;
                    clFranquicia.Direccion = txtDireccion.Text;
                    clFranquicia.Telefono_Fr = txtTelfFranquicia.Text;
                    clFranquicia.ModificarFranquicia(lblMensaje);
                    clControl.FranquiciasRegistradas(lbxFranquicias);
                }
            }
            catch (Exception err)
            {
                lblMensaje.Text = "Ha sucedido un error: " + err.Message;
            }
        }

        protected void butClienteAccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (butClienteAccion.Text == "Añadir representante(s)")
                {
                    clControl.GuardarCliente(lbxNuevosClientes, lblMensaje, lbxFranquicias);
                }
                else if (butClienteAccion.Text == "Modificar representante")
                {
                    clClientes.ModificarCliente(lblMensaje, txtNombreCliente, txtTelefonoCliente, lbxFranquicias);
                    clControl.ClienteDeFranquicia(lbxFranquicias, lbxClientes);
                }
            }
            catch (Exception err)
            {
                lblMensaje.Text = "Ha sucedido un error: " + err.Message;
            }
        }

        protected void butEliminarUltimo_Click(object sender, EventArgs e)
        {
            clControl.EliminarClientePila(lbxNuevosClientes);
        }

        protected void butAgregaCliente_Click(object sender, EventArgs e)
        {
            clControl.ClienteAñadir(lbxFranquicias, lbxNuevosClientes, txtNombreCliente, txtTelefonoCliente);
        }

        protected void butIniciarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                pnlContenido.Visible = true;
                if (ddlAccion.SelectedItem.ToString() == "Registrar")
                {
                    pnlAgregar.Visible = false;
                    pnlCliente.Visible = true;
                    txtTelefonoCliente.Enabled = true;
                    txtNombreCliente.Enabled = true;
                    butAgregaCliente.Enabled = true;
                    lbxNuevosClientes.Visible = true;
                    butClienteAccion.Enabled = true;
                    butAgregaCliente.Visible = true;
                }
                else if (ddlAccion.SelectedItem.ToString() == "Modificar")
                {
                    if (lbxClientes.SelectedIndex > -1)
                    {
                        clClientes.DatosCliente(txtNombreCliente, txtTelefonoCliente, lbxClientes);
                    }
                    pnlAgregar.Visible = false;
                    pnlCliente.Visible = true;
                    txtTelefonoCliente.Enabled = true;
                    txtNombreCliente.Enabled = false;
                    butAgregaCliente.Enabled = false;
                    butClienteAccion.Text = "Modificar representante";
                    lbxNuevosClientes.Visible = false;
                    butClienteAccion.Enabled = true;
                    butAgregaCliente.Visible = false;
                }
                else if (ddlAccion.SelectedItem.ToString() == "Eliminar")
                {
                    clClientes.EliminarCliente(lblMensaje, lbxClientes);
                    pnlAgregar.Visible = false;
                    pnlCliente.Visible = false;
                    txtTelefonoCliente.Enabled = false;
                    txtNombreCliente.Enabled = false;
                    butAgregaCliente.Enabled = false;
                    butClienteAccion.Enabled = false;
                    lbxNuevosClientes.Visible = false;
                    butAgregaCliente.Visible = false;
                    clControl.ClienteDeFranquicia(lbxFranquicias, lbxClientes);
                }
            }
            catch (Exception err)
            {
                pnlContenido.Visible = false;
                lblMensaje.Text = "Ha sucedido un error: " + err.Message;
                lblMensaje.Text = err.Message.Replace("El índice estaba fuera del intervalo. Debe ser un valor no negativo e inferior al tamaño de la colección.\r\nNombre del parámetro: index", "Seleccione un elemento (franquicia o cliente) para poder modificar sus datos.");
            }
        }

        protected void lbxNuevosClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /*Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time*/
        }
    }
}