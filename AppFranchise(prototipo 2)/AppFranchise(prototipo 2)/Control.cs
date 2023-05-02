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
    //Clase exclusiva para estructuras de datos
    public class Control:Conexion
    {
        //Variables y propiedades: Listas, diccionarios, pilas y colas
        private static List<Empleado> lst_emp = new List<Empleado>();
        private static List<Franquicia> lst_fr = new List<Franquicia>();
        private static List<Pedido> lst_ped = new List<Pedido>();
        private static List<Pedido> lst_env = new List<Pedido>();
        //Lista de todos los clientes
        private static List<Cliente> lst_cl = new List<Cliente>();
        //Pila para registro de clientes y poder eliminar el último añadido antes de almacenarlo en la base de datos
        private static Stack<Cliente> stk_clientes = new Stack<Cliente>();
        //Diccionario para almacenar todos los pedidos e identificarlo por ID
        private static Dictionary<int, Pedido> dic_ped = new Dictionary<int, Pedido>();
        //Pila para almacenar los pedidos e ir asignando el primer pedido
        private static Queue<Pedido> col_envio = new Queue<Pedido>();
        public static List<Empleado> lstEmpleados
        {
            set { lst_emp = value; }
            get { return lst_emp; }

        }
        public static List<Franquicia> lstFranquicias
        {
            set { lst_fr = value; }
            get { return lst_fr; }
        }
        public static List<Pedido> lstPedidos
        {
            set { lst_ped = value; }
            get { return lst_ped; }
        }
        public static List<Pedido> lstEnvios
        {
            set { lst_env = value; }
            get { return lst_env; }
        }
        public static List<Cliente> lstClientes
        {
            set { lst_cl = value; }
            get { return lst_cl; }
        }
        public static Dictionary<int, Pedido> dicPedidos
        {
            set { dic_ped = value; }
            get { return dic_ped; }
        }
        public static Queue<Pedido> colEnvios
        {
            set { col_envio = value; }
            get { return col_envio; }
        }
        //Método para obtener todos los empleados en una lista y mostrarlo en un DropDownList
        public void AñadirListEmpleados(DropDownList ddl)
        {
            ddl.Items.Clear();
            lst_emp.Clear();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Empleados");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string nomb, rol, nusu, psw;
                int edad;
                while (sqlDR.Read())
                {
                    nomb = sqlDR["Nombre_Emp"].ToString();
                    edad = int.Parse(sqlDR["Edad_Emp"].ToString());
                    rol = sqlDR["Rol_Emp"].ToString();
                    nusu = sqlDR["Usuario_Emp"].ToString();
                    psw = sqlDR["Contraseña_Emp"].ToString();
                    lst_emp.Add(new Empleado(nomb, edad, rol, nusu, psw));

                }
                foreach (Empleado emp in lst_emp)
                {
                    ddl.Items.Add(emp.Nombre + ", " + emp.Rol_Emp);
                }
            }
            sqlDR.Close();
        }
        //Método para obtener todos los clientes en una lista y mostrarlos en un DropDownList
        public void AñadirListClientes(DropDownList ddl)
        {
            ddl.Items.Clear();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Clientes");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string nomb, cl;
                int fr, id;
                while (sqlDR.Read())
                {
                    nomb = sqlDR["Nombre_cli"].ToString();
                    cl = sqlDR["Telefono_cli"].ToString();
                    fr = int.Parse(sqlDR["ID_Franquicia"].ToString());
                    id = int.Parse(sqlDR["Id_Cliente"].ToString());
                    lst_cl.Add(new Cliente(id, nomb, cl, fr));
                }
                foreach (Cliente cliente in lst_cl)
                {
                    ddl.Items.Add(cliente.Nombre_Cl);
                }
            }
            sqlDR.Close();
        }
        
        //Método para mostrar todas las franquicias registradas en un listBox y una DropDownList
        public void FranquiciasRegistradas(ListBox lbx)
        {
            lbx.Items.Clear();
            lst_fr.Clear();
            SqlCommand sqlCmd = new SqlCommand("Select * from vista_franquicias");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string direccion, pais, telf;
                while (sqlDR.Read())
                {
                    direccion = sqlDR["Dirección"].ToString();
                    pais = sqlDR["País"].ToString();
                    telf = sqlDR["Teléfono"].ToString();
                    lst_fr.Add(new Franquicia(direccion, pais, telf));
                }
                foreach (Franquicia fr in lstFranquicias)
                {
                    lbx.Items.Add(fr.Direccion + ", " + fr.Pais_fr + ". Teléfono: " + fr.Telefono_Fr);
                }
            }
            sqlDR.Close();
        }
        //Método para obtener el id de la franquicia seleccionada en el ListBox
        public int IdFranquicia(ListBox lbx)
        {
            int idx = lbx.SelectedIndex;
            Franquicia franq = new Franquicia();
            franq = (Franquicia)lst_fr[idx];
            SqlCommand sqlCmd = new SqlCommand("Exec spu_franquicia_datos '" + franq.Direccion + "','" + franq.Pais_fr + "'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            int id;
            if (sqlDR.Read() == true)
            {
                id = int.Parse(sqlDR["Id_franquicia"].ToString());
            }
            else
            {
                id = 0;
            }
            sqlDR.Close();
            return id;
        }
        //Método para obtener el id del empleado a partir de la lista
        public int IdEmpleado(DropDownList ddl)
        {
            int idx = ddl.SelectedIndex;
            Empleado emp = new Empleado();
            emp = (Empleado)lst_emp[idx];
            SqlCommand sqlCmd = new SqlCommand("Exec spu_datos_empleado '" + emp.Nombre + "'," + emp.Edad_Emp + ",'" + emp.Rol_Emp + "'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            int id;
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
        //Método para obtener el id del cliente
        public int IdCliente(DropDownList ddl)
        {
            int idx = ddl.SelectedIndex;
            Cliente cl = new Cliente();
            cl = (Cliente)lst_cl[idx];
            SqlCommand sqlCmd = new SqlCommand("Exec spu_cliente_id '" + cl.Nombre_Cl + "'");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            int id;
            if (sqlDR.Read() == true)
            {
                id = int.Parse(sqlDR["Id_Cliente"].ToString());
            }
            else
            {
                id = 0;
            }
            sqlDR.Close();
            return id;
        }
        //Método para mostrar todos los clientes o representates de la franquicia seleccionada
        public void ClienteDeFranquicia(ListBox lbxfr, ListBox lbxc)
        {
            lbxc.Items.Clear();
            lst_cl.Clear();
            SqlCommand sqlCmd = new SqlCommand("exec spu_representa_franquicia " + IdFranquicia(lbxfr));
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string nombre, telefono;
                int fr, id;
                while (sqlDR.Read())
                {
                    nombre = sqlDR["Nombre_cli"].ToString();
                    telefono = sqlDR["Telefono_cli"].ToString();
                    fr = int.Parse(sqlDR["ID_Franquicia"].ToString());
                    id = int.Parse(sqlDR["Id_cliente"].ToString());
                    lst_cl.Add(new Cliente(id, nombre, telefono, fr));
                }
                foreach (Cliente cl in lst_cl)
                {
                    lbxc.Items.Add(cl.Nombre_Cl);
                }
            }
            sqlDR.Close();
        }
        //Método para añadir el cliente a una lista y mostrar la lista en un listBox
        public void ClienteAñadir(ListBox lbxFr, ListBox lbxCl, TextBox txtNomb, TextBox txtTelf)
        {
            lbxCl.Items.Clear();
            stk_clientes.Push(new Cliente(txtNomb.Text, txtTelf.Text, IdFranquicia(lbxFr)));
            foreach (Cliente cl in stk_clientes)
            {
                lbxCl.Items.Add(cl.Nombre_Cl);
            }
            txtNomb.Text = "";
            txtTelf.Text = "";
        }
        //Método para almacenar los clientes o representantes asociados en la franquicia
        public void GuardarCliente(ListBox lbxCl, Label lbl, ListBox lbxFr)
        {
            foreach (Cliente cl in stk_clientes)
            {
                Cliente clCliente = new Cliente();
                clCliente.Nombre_Cl = cl.Nombre_Cl;
                clCliente.Telefono_Cl = cl.Telefono_Cl;
                clCliente.Insertar(lbl, lbxFr);
            }
            lbxCl.Items.Clear();
            stk_clientes.Clear();
        }
        //Quitar el último cliente añadido a una pila, antes de registrarlo a la base de datos
        public void EliminarClientePila(ListBox lbxCl)
        {
            lbxCl.Items.Clear();
            stk_clientes.Pop();
            foreach (Cliente cl in stk_clientes)
            {
                lbxCl.Items.Add(cl.Nombre_Cl);
            }
        }
        //Método para obtener los pedidos registrados en una lista y una cola y mostrarlos en un ListBox
        public void PedidoLB(ListBox lbx1)
        {
            dic_ped.Clear();
            col_envio.Clear();
            lbx1.Items.Clear();
            SqlCommand sqlCmd = new SqlCommand("Select * from vista_pedidos_destino");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string producto, fechaPedido, medida, destino;
                int cantidad, idPed, it = 0;
                double monto;
                while (sqlDR.Read())
                {
                    producto = sqlDR["Producto"].ToString();
                    cantidad = int.Parse(sqlDR["Cantidad"].ToString());
                    fechaPedido = Convert.ToDateTime(sqlDR["Fecha"].ToString()).ToShortDateString();
                    medida = sqlDR["Unidad_Medida"].ToString();
                    monto = double.Parse(sqlDR["Monto"].ToString());
                    idPed = int.Parse(sqlDR["Num_pedido"].ToString());
                    string pais = sqlDR["Pais"].ToString();
                    string dir = sqlDR["Direccion"].ToString();
                    destino = dir + " " + pais;
                    dic_ped.Add(it, new Pedido(idPed, fechaPedido, medida, monto, producto, cantidad, destino));
                    it++;
                    col_envio.Enqueue(new Pedido(idPed, fechaPedido, medida, monto, producto, cantidad, destino));
                }
                foreach (KeyValuePair<int, Pedido> ped in dic_ped)
                {
                    lbx1.Items.Add(ped.Value.Fecha_Pedido + " - " + ped.Value.Cantidad_Producto + " " + ped.Value.Medida_Producto + " de " + ped.Value.Producto);
                }
                sqlDR.Close();
            }
        }
        //Asignar un pedido para su envio
        public void PedidoAsignado(TextBox txt)
        {
            if (col_envio.Count() > 0)
                txt.Text = col_envio.Peek().Cantidad_Producto.ToString() + " " + col_envio.Peek().Medida_Producto + " de " + col_envio.Peek().Producto.ToString() + ". Destino: " + col_envio.Peek().Destino_pedido;
            else
                txt.Text = "No hay envíos por realizar";
        }
        //Mostrar los pedidos enviados
        public void EnvioLB(ListBox lbx)
        {
            lbx.Items.Clear();
            lst_env.Clear();
            SqlCommand sqlCmd = new SqlCommand("Select * from vista_envios");
            DS = new System.Data.DataSet();
            sqlCmd.Connection = base.sqlCon;
            sqlDR = sqlCmd.ExecuteReader();
            if (sqlDR.HasRows == true)
            {
                string producto, fechaEnvio, medida, destino, fechaPedido;
                double monto;
                int cantidad, idPed;
                while (sqlDR.Read())
                {
                    producto = sqlDR["Producto"].ToString();
                    cantidad = int.Parse(sqlDR["Cantidad"].ToString());
                    fechaPedido = Convert.ToDateTime(sqlDR["Solicitado"].ToString()).ToShortDateString();
                    fechaEnvio = Convert.ToDateTime(sqlDR["Enviado"].ToString()).ToShortDateString();
                    medida = sqlDR["Unidad_Medida"].ToString();
                    monto = double.Parse(sqlDR["Monto"].ToString());
                    idPed = int.Parse(sqlDR["Num_pedido"].ToString());
                    string pais = sqlDR["Pais"].ToString();
                    string dir = sqlDR["Direccion"].ToString();
                    destino = dir + " " + pais;
                    lst_env.Add(new Pedido(idPed, fechaPedido, fechaEnvio, medida, monto, producto, cantidad, destino));
                }
                foreach (Pedido ped in lst_env)
                {
                    lbx.Items.Add(ped.Cantidad_Producto.ToString() + " " + ped.Medida_Producto + " de " + ped.Producto + ". Solicitado:" + ped.Fecha_Pedido + ". Recibido:" + ped.Fecha_Envio);
                }
            }
        }

        public void DatosEnviosRecibo(ListBox lbx, TextBox txt)
        {
            int idx = lbx.SelectedIndex;
            Pedido ped = new Pedido();
            ped = lst_env[idx];
            int id;
            id = ped.ID_pedido;
            string mensaje = ped.Cantidad_Producto.ToString() + " " + ped.Medida_Producto + " de " + ped.Producto + ". Destino: " + ped.Destino_pedido;
            txt.Text = mensaje;
        }


    }
}