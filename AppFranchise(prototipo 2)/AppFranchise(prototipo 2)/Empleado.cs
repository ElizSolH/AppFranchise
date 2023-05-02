/*Nombre del autor: Solís Hernández Elizabeth
 * Nombre del programa: AppFranchise (Prototipo 2)
 * Descripción del programa: Segundo prototipo del software de control de franquicias, empleados y pedidos de la tienda Kawaii Shop
 * Fecha de creación: 17 de noviembre del 2016
 * Versión: 2.0*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace AppFranchise_prototipo_2_
{
    public class Empleado:Conexion
    {
        //Propiedades de la clase:
        private string nomb;
        private int edad;
        private string rol;
        private string nusu;
        private string psw;
        private int id;
        public string Nombre
        {
            set 
            { 
                nomb = value;
                if (nomb == "")
                    throw new Exception("No debe dejar en blanco el nombre");
                foreach (char letra in nomb)
                {
                    switch (letra)
                    {
                        case 'á': continue;
                        case 'é': continue;
                        case 'í': continue;
                        case 'ó': continue;
                        case 'ú': continue;
                    }                    
                }
            }
            get { return nomb; }
        }
        public int Edad_Emp
        {
            set 
            { 
                edad = value;
                if (edad < 18 || edad > 70)
                    throw new Exception("El empleado no puede ser menor de edad ni mayor a 70 años");
            }
            get { return edad; }
        }
        public string Rol_Emp
        {
            set 
            { 
                rol = value;
                if (rol == "")
                    throw new Exception("Es necesario asignar al empleado en un puesto o rol para poder registrarlo.");
            }
            get { return rol; }
        }
        public string Usuario
        {
            set 
            { 
                nusu = value;
                if (nusu == "")
                    throw new Exception("Es necesario ingresar un nombre de usuario para tener acceso al sistema.");
            }
            get { return nusu; }
        }
        public string Contraseña
        {
            set 
            { 
                psw = value;
                if (psw == "")
                    throw new Exception("No se ha ingresado una contraseña para el acceso al sistema.");
            }
            get { return psw; }
        }
        private int ID_Emp
        {
            set { id = value; }
            get { return id; }
        }
        //Método para mostrar todos los empleados
        public void Mostrar(GridView GV) 
        {
            DT = new DataTable();
            strCmd = "Select * from vista_empleados"; //Mostrar los empleados con una vista
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            SqlDA = new SqlDataAdapter(sqlCmd);
            SqlDA.Fill(DT);
            GV.DataSource = DT;
            GV.DataBind();
        }
        //Método para insertar empleados a la tabla
        string SqlInsertar;
        public virtual void Insertar(Label lbl)
        {
            DT = new DataTable();
            SqlInsertar = "Exec spu_añadir_empleados @nombre = '"+nomb+"',@edad = "+edad+",@contra = '"+psw+"',@rol = '"+rol+"',@usuario = '"+nusu+"'"; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlInsertar);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();
            lbl.Text="Empleado con nombre "+nomb+" añadido correctamente.";
        }
        //Método para eliminar empleados
        string SqlEliminar;
        public void Eliminar(Label lbl,DropDownList ddl)
        {
            int idx = ddl.SelectedIndex;
            Empleado emp = new Empleado();
            emp = (Empleado)Control.lstEmpleados[idx];
            SqlEliminar = ("Exec spu_delete_empleados @usuario = '"+emp.nusu+"'"); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlEliminar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text="Empleado eliminado correctamente.";
        }
        //Método para modificar un empleado en la base de datos
        string SqlModificar;
        public void Modificar(Label lbl,DropDownList ddl)
        {
            Control objControl = new Control();
            SqlModificar = ("Exec spu_modif_empleados @nombre = '"+nomb+"',@edad ="+edad+",@psw='"+psw+"',@rol = '"+rol+"',@usu = '"+nusu+"',@id="+objControl.IdEmpleado(ddl));//Procedimiento para modificar un empleado
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text="Empleado modificado correctamente";
        }
        //Método para obtener los roles o puestos de Kawaii Shop y mostrarlos en un DropDownList en el módulo de Login
        public void PuestoDDL(DropDownList ddl)
        {
            SqlDA = new SqlDataAdapter("Select * from vista_puestos", sqlCon);
            DS = new System.Data.DataSet();

            SqlDA.Fill(DS);

            ddl.DataSource = DS.Tables[0].DefaultView;
            ddl.DataTextField = "Puesto";
            ddl.DataBind();
        }
        //Método para verificar que el usuario y contraseña ingresados son correctos
        public Boolean Logear() //Logear
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandText = "Select count (*) from Empleados where Usuario_emp= '" +nusu+ "' and Contraseña_emp = '" + psw + "' and Rol_emp='"+rol+"'";
            cmd.ExecuteNonQuery();
            int resp = Convert.ToInt32(cmd.ExecuteScalar());
            if (resp == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Método para obtener todos los datos del empleado en TextBox para que los pueda modificar el usuario
        public void DatosEmpleado(TextBox txtNombre,TextBox txtEdad,TextBox txtPuesto,TextBox txtUsuario,TextBox txtContraseña,DropDownList ddl)
        {
            int idx=ddl.SelectedIndex;
            Empleado emp = new Empleado();
            emp = (Empleado)Control.lstEmpleados[idx];
            txtContraseña.Text = emp.Contraseña;
            txtEdad.Text = emp.Edad_Emp.ToString();
            txtNombre.Text = emp.Nombre;
            txtPuesto.Text = emp.Rol_Emp;
            txtUsuario.Text = emp.Usuario;
        }
        //Método para obtener el nombre del empleado
        public string Nombre_Empleado(string usuario, string rol)
        {
            string empleado="";
            sqlCmd = new SqlCommand("EXEC spu_nombre_empleado '"+usuario+"','"+rol+"'", sqlCon);
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if(sqlDR.Read()==true)
            empleado = sqlDR["Nombre_Emp"].ToString();

            sqlDR.Close();
            return empleado;
        }
        //Método para obtener el ID del empleado a partir del nombre de usuario y el rol para registrar pedidos
        public int Id_Empleado(DropDownList ddl)
        {
            int id;
            int idx = ddl.SelectedIndex;
            Empleado emp = new Empleado();
            emp = (Empleado)Control.lstEmpleados[idx];
            SqlCommand sqlCmd = new SqlCommand("Exec spu_edad_empleado '"+emp.Usuario+"','"+emp.Rol_Emp+"'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                id = int.Parse(sqlDR["Id_Empleado"].ToString());
            }
            else
            {
                id = 0;
            }
            sqlDR.Close();
            return id;
        }
        //Método para obtener la edad del empleado
        public int Edad_Empleado(string usuario,string rol)
        {
            int edad=0;
            sqlCmd = new SqlCommand("Exec spu_edad_empleado '"+usuario+"','"+rol+"'", sqlCon);
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if(sqlDR.Read()==true)
            {
                edad = int.Parse(sqlDR["Edad_emp"].ToString());
            }
            sqlDR.Close();
            return edad;
        }
        //Constructor
        public Empleado()
        {

        }
        //Constructor para estructura de datos Lista
        public Empleado(string Nombre,int edad,string rol,string NomUsu, string psw)
        {
            this.nomb = Nombre;
            this.edad = edad;
            this.rol = rol;
            this.nusu = NomUsu;
            this.psw = psw;
        }


        //Método para obtener el ID del empleado que va a registrar el pedido
        public int ID_Empleado(string nombre, string rol, string usuario)
        {
            int id;
            SqlCommand sqlCmd = new SqlCommand("Exec spu_datos_empleado '" + nombre + "'," + Edad_Empleado(usuario, rol) + ",'" + rol + "'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                id = int.Parse(sqlDR["Id_Empleado"].ToString());
            }
            else
            {
                id = 0;
            }
            sqlDR.Close();
            return id;
        }
        
    }
}