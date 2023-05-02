using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFranchise_prototipo_2_
{
    public partial class Inicio : System.Web.UI.Page
    {
        Empleado clEmp = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                lblError.Text = clEmp.Mensaje_conexion;
                clEmp.PuestoDDL(ddlPerfil_Usuario);
            }
        }

        protected void butIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                clEmp.Usuario = txtUsuario.Text;
                clEmp.Contraseña = txtContraseña.Text;
                clEmp.Rol_Emp = ddlPerfil_Usuario.SelectedItem.ToString();
                Session["Usuario"] = txtUsuario.Text;
                Session["Puesto"] = ddlPerfil_Usuario.SelectedItem.ToString();
                Session["Empleado"] = clEmp.Nombre_Empleado(txtUsuario.Text, ddlPerfil_Usuario.SelectedItem.ToString());
                if (clEmp.Logear() == true)
                {
                    if (ddlPerfil_Usuario.SelectedItem.ToString() == "Gerente general" || ddlPerfil_Usuario.SelectedItem.ToString() == "Gerente General")
                    {
                        Response.Redirect("~/Empleados.aspx");
                    }
                    else if (ddlPerfil_Usuario.SelectedItem.ToString() == "Vendedor")
                    {
                        Response.Redirect("~/Pedidos.aspx");
                    }
                    else if (ddlPerfil_Usuario.SelectedItem.ToString() == "Repartidor")
                    {
                        Response.Redirect("~/Pedidos.aspx");
                    }
                    else if (ddlPerfil_Usuario.SelectedItem.ToString() == "Administrador d")
                    {
                        Response.Redirect("~/Pedidos.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Usuario y/o contraseña incorrecto(s).";
                }
            }
            catch (Exception err)
            {
                lblError.Text = "Error: " + err.Message;
            }
        }
    }
}