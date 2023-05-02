using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFranchise_prototipo_2_
{
    public partial class Empleados : System.Web.UI.Page
    {
        Control objControl = new Control();
        Empleado clEmpleado = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEmpleadoUsuario.Text = Session["Empleado"].ToString();
                ddlAccion.Items.Add("Agregar");
                ddlAccion.Items.Add("Modificar");
                ddlAccion.Items.Add("Eliminar");
                ddlPuestos.Items.Add("Gerente general");
                ddlPuestos.Items.Add("Vendedor");
                ddlPuestos.Items.Add("Repartidor");
                ddlPuestos.Items.Add("Administrador de almacén");
                objControl.AñadirListEmpleados(ddlEmpleados);
                clEmpleado.Mostrar(gvwEmpleados);
                lblModificaElimina.Visible = false;
                ddlEmpleados.Visible = false;
                butAccion.Text = "Agregar";
                lblMensaje.Text = clEmpleado.Mensaje_conexion;
                txtPuesto.Visible = false;
                ddlPuestos.AutoPostBack = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccion.SelectedItem.ToString() == "Agregar")
            {
                lblModificaElimina.Visible = false;
                txtContraseña.Enabled = true;
                txtEdad.Enabled = true;
                txtNombre.Enabled = true;
                ddlPuestos.Enabled = true;
                txtUsuario.Enabled = true;
                ddlEmpleados.Visible = false;
                txtPuesto.Visible = false;
                txtPuesto.Enabled = false;
                ddlPuestos.AutoPostBack = false;
                butAccion.Text = "Agregar";
                ddlEmpleados.AutoPostBack = false;
            }
            else if (ddlAccion.SelectedItem.ToString() == "Modificar")
            {
                objControl.AñadirListEmpleados(ddlEmpleados);
                clEmpleado.DatosEmpleado(txtNombre, txtEdad, txtPuesto, txtUsuario, txtContraseña, ddlEmpleados);
                lblModificaElimina.Visible = true;
                lblModificaElimina.Text = "Empleado a modificar:";
                txtContraseña.Enabled = true;
                txtEdad.Enabled = true;
                txtNombre.Enabled = true;
                ddlPuestos.Enabled = true;
                txtUsuario.Enabled = true;
                ddlEmpleados.Visible = true;
                txtPuesto.Visible = true;
                txtPuesto.Enabled = false;
                ddlPuestos.AutoPostBack = true;
                butAccion.Text = "Modificar";
                ddlEmpleados.AutoPostBack = true;
            }
            else if (ddlAccion.SelectedItem.ToString() == "Eliminar")
            {
                lblModificaElimina.Visible = true;
                lblModificaElimina.Text = "Empleado a eliminar:";
                txtContraseña.Enabled = false;
                txtEdad.Enabled = false;
                txtNombre.Enabled = false;
                ddlPuestos.Enabled = false;
                txtUsuario.Enabled = false;
                ddlEmpleados.Visible = true;
                txtPuesto.Visible = true;
                txtPuesto.Enabled = false;
                ddlPuestos.AutoPostBack = false;
                butAccion.Text = "Eliminar";
                ddlEmpleados.AutoPostBack = false;
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /*Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time*/
        }
        protected void ddlEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            clEmpleado.DatosEmpleado(txtNombre, txtEdad, txtPuesto, txtUsuario, txtContraseña, ddlEmpleados);
        }

        protected void ddlPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccion.SelectedItem.ToString() == "Modificar")
            {
                txtPuesto.Text = ddlPuestos.SelectedItem.ToString();
            }
        }

        protected void butAccion_Click(object sender, EventArgs e)
        {
            if (butAccion.Text == "Agregar")
            {
                try
                {
                    clEmpleado.Contraseña = txtContraseña.Text;
                    clEmpleado.Edad_Emp = int.Parse(txtEdad.Text);
                    clEmpleado.Nombre = txtNombre.Text;
                    clEmpleado.Rol_Emp = ddlPuestos.SelectedItem.ToString();
                    clEmpleado.Usuario = txtUsuario.Text;
                    clEmpleado.Insertar(lblMensaje);
                    clEmpleado.Mostrar(gvwEmpleados);
                }
                catch (Exception error)
                {
                    lblMensaje.Text = error.Message.Replace("Violation of UNIQUE KEY constraint 'UQ__Empleado__354FBAA0AFBE35DE'. Cannot insert duplicate key in object 'dbo.Empleados'. The duplicate key value is (" + txtNombre.Text + ").\r\nThe statement has been terminated.", "No pueden haber dos empleados con el mismo nombre."); 
                }
            }
            else if (butAccion.Text == "Modificar")
            {
                clEmpleado.Contraseña = txtContraseña.Text;
                clEmpleado.Edad_Emp = int.Parse(txtEdad.Text);
                clEmpleado.Nombre = txtNombre.Text;
                clEmpleado.Rol_Emp = txtPuesto.Text;
                clEmpleado.Usuario = txtUsuario.Text;
                clEmpleado.Modificar(lblMensaje, ddlEmpleados);
                clEmpleado.Mostrar(gvwEmpleados);
            }
            else if (butAccion.Text == "Eliminar")
            {
                clEmpleado.Eliminar(lblMensaje, ddlEmpleados);
                clEmpleado.Mostrar(gvwEmpleados);
            }
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
            
    }
