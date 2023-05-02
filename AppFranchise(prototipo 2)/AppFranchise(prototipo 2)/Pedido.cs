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
    public class Pedido:Conexion
    {
        //Propiedades de la clase Pedidos:
        private string fenvio;
        private string fped;
        private string frec;
        private string prod;
        private double monto;
        private int cant;
        private string medida;
        private int cl;
        private int emp;
        private int id;
        private string destino;
        public string Destino_pedido
        {
            set { destino = value; }
            get { return destino; }
        }
        public int ID_pedido
        {
            set { id = value; }
            get { return id; }
        }
        public string Fecha_Envio
        {
            set
            { fenvio = value; }
            get { return fenvio; }
        }
        public string Fecha_Pedido
        {
            set { fped = value; }
            get { return fped; }
        }
        public string Fecha_Recibo
        {
            set { frec = value; }
            get { return frec; }
        }
        public string Producto
        {
            set { prod = value; }
            get { return prod; }
        }
        public double Monto_Pedido
        {
            set { monto = value; }
            get { return monto; }
        }
        public int Cantidad_Producto
        {
            set { cant = value; }
            get { return cant; }
        }
        public string Medida_Producto
        {
            set { medida = value; }
            get { return medida; }
        }
        public int Cliente
        {
            set { cl = value; }
            get { return cl; }
        }
        public int Empleado
        {
            set { emp = value; }
            get { return emp; }
        }
        //Constructor para mostrar historial de pedidos
        public Pedido(string fenvio, string frecibo, string fpedido, string medida, double monto, string producto, int cantidad, int cl, int emp)
        {
            this.cant = cantidad;
            this.fenvio = fenvio;
            this.frec = frecibo;
            this.fped = fpedido;
            this.medida = medida;
            this.monto = monto;
            this.prod = producto;
            this.cl = cl;
            this.emp = emp;
        }

        //Constructor para cola de Pedidos realizados y que aún no han sido enviados, para registrar fecha de envio posteriormente
        public Pedido(int id, string fpedido, string medida, double monto, string producto, int cantidad, string destino)
        {
            this.id = id;
            this.fped = fpedido;
            this.medida = medida;
            this.monto = monto;
            this.prod = producto;
            this.cant = cantidad;
            this.destino = destino;
        }
        //Constructor para lista de Pedidos realizados y enviados para registrar su entrega
        public Pedido(int id, string fpedido, string fenvio, string medida, double monto, string producto, int cantidad, string destino)
        {
            this.id = id;
            this.fped = fpedido;
            this.fenvio = fenvio;
            this.medida = medida;
            this.monto = monto;
            this.prod = producto;
            this.cant = cantidad;
            this.destino = destino;
        }
        
        //Constructor 
        public Pedido(string fenvio, string frecibo, string fpedido)
        {
            this.fenvio = fenvio;
            this.frec = frecibo;
            this.fped = fpedido;
        }
        public Pedido()
        {

        }  
    }
    public class Solicitud:Pedido
    {
        //Método para insertar pedidos solicitados a la tabla
        string SqlInsertar;
        public void Insertar(Label lbl, DropDownList ddl)
        {
            int idx = ddl.SelectedIndex;
            Cliente cl = (Cliente)Control.lstClientes[idx];
            Control objControl = new Control();
            DT = new DataTable();
            SqlInsertar = "Exec spu_añadir_pedidos @fpedido = '" + Fecha_Pedido + "', @cantidad=" + Cantidad_Producto + ",@producto='" + Producto + "',@medida='" + Medida_Producto + "',@monto=" + Monto_Pedido + ",@empleado=" + Empleado + ",@cliente=" + cl.ID_Cl; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlInsertar);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();
            lbl.Text = "El pedido ha sido registrado correctamente.";
        }
        //Método para mostrar los datos de pedido dependiendo el pedido seleccionado para poder modificarlo
        public void DatosPedido(ListBox lbx, TextBox txtCant, TextBox txtFped, TextBox txtMedida, TextBox txtMonto, TextBox txtProd)
        {
            int idx = lbx.SelectedIndex;
            Pedido ped = new Pedido();
            ped = Control.dicPedidos[idx];
            txtCant.Text = ped.Cantidad_Producto.ToString();
            txtFped.Text = ped.Fecha_Pedido;
            txtMedida.Text = ped.Medida_Producto;
            txtMonto.Text = ped.Monto_Pedido.ToString();
            txtProd.Text = ped.Producto;
        }
        //Método para cancelar pedido
        string SqlEliminar;
        public void Eliminar(Label lbl,ListBox lbxped)
        {
            int idx = lbxped.SelectedIndex;
            Pedido ped = new Pedido();
            ped = (Pedido)Control.dicPedidos[idx];
            SqlEliminar = ("Exec spu_eliminar_pedido"+ped.ID_pedido); //Procedimiento para eliminar en la tabla
            SqlCommand SqlCmd = new SqlCommand(SqlEliminar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Pedido cancelado correctamente.";
        }
        //Método para modificar un pedido registrado en la base de datos
        string SqlModificar;
        public void Modificar(ListBox lbxped,Label lbl,TextBox txtProducto,TextBox txtCantidad,TextBox txtMedida, TextBox txtMonto)
        {
            int idx = lbxped.SelectedIndex;
            Pedido ped = new Pedido();
            ped = (Pedido)Control.dicPedidos[idx];
            SqlModificar = ("Exec spu_modificar_pedidos "+txtCantidad.Text+",'"+txtProducto.Text+"','"+txtMedida.Text+"',"+txtMonto.Text+","+ped.ID_pedido);//Procedimiento para modificar un empleado
            SqlCommand SqlCmd = new SqlCommand(SqlModificar);
            SqlCmd.Connection = sqlCon;
            SqlCmd.ExecuteNonQuery();
            lbl.Text = "Pedido modificado correctamente";
        }
        //Método para mostrar los datos de envio dependiedo el cliente seleccionado
        public void DatosEnvio(DropDownList ddl, TextBox txt)
        {
            Control objControl = new Control();
            int idx = ddl.SelectedIndex;
            Cliente cl = new Cliente();
            cl = (Cliente)Control.lstClientes[idx];
            int id = cl.Franquicia;
            SqlCommand sqlCmd = new SqlCommand("Exec spu_datos_franq_id  " + id);
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.Read() == true)
            {
                string dir, pais;
                dir = sqlDR["Direccion_franq"].ToString();
                pais = sqlDR["Pais_franq"].ToString();
                txt.Text = dir + ". " + pais;
            }
            sqlDR.Close();
        }
    }
    public class Envio:Pedido
    {        
        //Método para registrar la fecha de envío de un pedido
        string SqlEnvio;
        public void InsertarEnv(Label lbl, Calendar cal)
        {
            DT = new DataTable();
            SqlEnvio = "Exec spu_añadir_envio @numPed=" + Control.colEnvios.Peek().ID_pedido + ",@fenvio='" + cal.SelectedDate.ToString("MM/dd/yyyy") + "'"; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlEnvio);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();
            Control.colEnvios.Dequeue();
            lbl.Text = "El envío ha sido registrado correctamente.";
        }
    }
    public class Entrega:Pedido
    {

        //Método para registrar la fecha de recibo de un pedido y el estado del producto al recibirlo
        string SqlRecibo;
        public void InsertarRec(Label lbl, Calendar cal, ListBox lbx, TextBox txt)
        {
            int idx = lbx.SelectedIndex;
            Pedido ped = new Pedido();
            ped = Control.dicPedidos[idx];
            int id;
            id = ped.ID_pedido;
            DT = new DataTable();
            SqlRecibo = "Exec spu_añadir_recibo @numPed=" + id + ",@frecibo='" + cal.SelectedDate.ToString("MM/dd/yyyy") + "',@estado='" + txt.Text + "'"; //Procedimiento para insertar en la tabla
            SqlCommand sqlCmd = new SqlCommand(SqlRecibo);
            sqlCmd.Connection = sqlCon;
            sqlCmd.ExecuteNonQuery();
            lbl.Text = "El recibo del pedido ha sido registrado correctamente.";
        }
    }
}