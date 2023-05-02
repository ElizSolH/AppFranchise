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
    public class Cliente:Conexion
    {
        //Propiedades
        private string nomb;
        private string telf;
        private int fr;
        private int id;
        public string Nombre_Cl
        {
            set 
            { 
                nomb = value;
                if (nomb == "")
                    throw new Exception("Ingrese el nombre del representante o cliente.");
            }
            get { return nomb; }
        }
        public string Telefono_Cl
        {
            set 
            { 
                telf = value;
            }
            get { return telf; }
        }
        public int Franquicia
        {
            set { fr = value; }
            get { return fr; }
        }
        public int ID_Cl
        {
            set { id = value; }
            get { return id; }
        }
        
        //Método para insertar clientes solicitados a la tabla asociados a una franquicia
        string SqlInsertar;
        public virtual void Insertar(Label lbl,ListBox lbx)
        {
            //Obtener el ID de franquicia a partir de la selección
            Control objCl = new Control();
            fr = objCl.IdFranquicia(lbx);
            //Insertar
            DT = new DataTable();
            SqlInsertar = "Exec spu_añadir_clientes @nombre = '" + Nombre_Cl + "',@telefono = '" + telf + "',@franquicia = " + fr + ""; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlInsertar);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();

            lbl.Text = "Los clientes han sido registrados correctamente.";
        }
        //Método para mostrar los datos de un cliente para modificarlos
        public void DatosCliente(TextBox txtNomb, TextBox txtTelf,ListBox lbxCliente)
        {            
            
            Cliente cl = new Cliente();
            int idx = lbxCliente.SelectedIndex;
            cl = (Cliente)Control.lstClientes[idx];
            txtNomb.Text = cl.Nombre_Cl;
            txtTelf.Text = cl.Telefono_Cl;
            //Obtener el id
            SqlCommand sqlCmd = new SqlCommand("Exec spu_datos_cliente '"+cl.Nombre_Cl+"',"+cl.Franquicia+"");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                ID_Cl = int.Parse(sqlDR["ID_Cliente"].ToString());
            }
            else
            {
            }
            sqlDR.Close();    
        }
        //Método para modificar un cliente
        public void ModificarCliente(Label lbl,TextBox txtNomb, TextBox txtTelf,ListBox lbxFranquicia)
        {
            Control objControl = new Control();
            string SqlModificar;
            SqlModificar = ("Exec spu_modificar_clientes @nombre = '"+txtNomb.Text+"',@telefono = '"+txtTelf.Text+"',@franquicia ="+objControl.IdFranquicia(lbxFranquicia)); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Cliente modificado correctamente.";
        }
        //Método para eliminar un cliente
        public void EliminarCliente(Label lbl,ListBox lbxCliente)
        {
            int idx = lbxCliente.SelectedIndex;
            Cliente cl = new Cliente();
            cl = (Cliente)Control.lstClientes[idx];//Obtener los valores del cliente seleccionado 
            string SqlModificar;
            SqlModificar = ("Exec spu_eliminar_clientes "+cl.id); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Cliente o representante eliminado correctamente.";
        }
        //Constructor para crear una lista para mostrarse en un listBox y manipular sus datos
        public Cliente(int id,string nom,string telf,int fr)
        {
            this.id = id;
            this.nomb = nom;
            this.telf = telf;
            this.fr = fr;
        }
        //Constructor para crear lista para ir guardando los clientes y posteriormente añadirlos todos
        public Cliente(string nom, string telf, int fr)
        {
            this.nomb = nom;
            this.telf = telf;
            this.fr = fr;
        }
        
        //Constructor para crear una lista para obtener los clientes
        public Cliente(string nomb)
        {
            this.nomb = nomb;
        }
        //Constructor para la utilización de las propiedades y métodos de la clase
        public Cliente()
        {

        }
    }
}