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
using System.Collections;

namespace AppFranchise_prototipo_2_
{
    public class Franquicia:Conexion
    {
        private string dir;
        private string pais;
        private string telf_fr;
        private static int idfr;
        private string nomb;
        private string telf_cl;
        public string Direccion
        {
            set { dir = value; }
            get { return dir; }
        }
        public string Pais_fr
        {
            set { pais = value; }
            get { return pais; }
        }
        public string Telefono_Fr
        {
            set { telf_fr = value; }
            get { return telf_fr; }
        }
        public static int ID_Fr
        {
            set { idfr = value; }
            get { return idfr; }
        }
        public string Nombre_Cl
        {
            set { nomb = value; }
            get { return nomb; }
        }
        public string Telefono_Cl
        {
            set { telf_cl = value; }
            get { return telf_cl; }
        }
        //Constructor
        public Franquicia()
        {

        }
        public Franquicia(string dir,string pais,string telf)
        {
            this.dir = dir;
            this.pais = pais;
            this.telf_fr = telf;
        }
        //Método para añadir nueva franquicia
        public void RegistrarFranquicia(Label lbl)
        {
            string SqlInsertar;
            DT = new DataTable();
            SqlInsertar = "Exec spu_añadir_franquicias @direccion = '"+dir+"',@telefono = '"+telf_fr+"',@pais = '"+pais+"'"; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlInsertar);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();
            lbl.Text = "La franquicia ha sido añadida correctamente.";//Regresa mensaje de registro correcto
        }
        //Método para modificar una franquicia
        public void ModificarFranquicia(Label lbl)
        {
            string SqlModificar;
            SqlModificar = ("Exec spu_modificar_franquicias @direccion = '"+dir+"',@telefono = '"+telf_fr+"',@pais = '"+pais+"', @id = "+idfr+""); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Franquicia modificada correctamente.";
        }
        //Método para obtener en textBox los datos de la franquicia para modificarlos
        public void FranquiciaDatos(TextBox dir, TextBox pais, TextBox telf,List<Franquicia> lst,ListBox lbx)
        {
            int idx=lbx.SelectedIndex;
            Franquicia fr = new Franquicia();
            fr = (Franquicia)lst[idx];
            SqlCommand sqlCmd = new SqlCommand("Exec spu_franquicia_datos '"+fr.dir+"','"+fr.pais+"'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                dir.Text = sqlDR["Direccion_franq"].ToString();
                pais.Text = sqlDR["Pais_franq"].ToString();
                telf.Text = sqlDR["Telefono_franq"].ToString();
                idfr = int.Parse(sqlDR["ID_Franquicia"].ToString());
            }
            else
            {
            }
            sqlDR.Close();       
        }
        //Método para eliminar una franquicia
        public void EliminarFranquicia(Label lbl)
        {
            string SqlModificar;
            SqlModificar = ("Exec spu_eliminar_franquicias @id="+idfr); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Franquicia eliminada correctamente.";
        }
        //Método para obtener la franquicia que representa el cliente seleccionado en el DropDownList
        public void FranquiciaCliente(DropDownList ddl, TextBox txt)
        {
            SqlCommand sqlCmd = new SqlCommand("exec spu_cliente_franquicia '" + ddl.SelectedItem.ToString() + "'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                string dir, pais;
                dir = sqlDR["Nombre_cl"].ToString();
                pais = sqlDR["Telefono_cl"].ToString();
                txt.Text = dir + ", " + pais;
            }
            else
            {
                txt.Text = "Cliente no asociado a una franquicia.";
            }
            sqlDR.Close();
        }
    }
}