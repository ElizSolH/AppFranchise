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
    public class Conexion
    {
        //Clase exclusiva para la conexión a la BDD
        public SqlConnection sqlCon; //Variable para conexión con SQL
        public SqlCommand sqlCmd; //Variable para mostrar datos en la tabla de la BDD
        public String strCmd;
        public DataTable DT;
        public SqlDataAdapter SqlDA;
        public SqlDataReader sqlDR;
        public DataSet DS;
        private string mensaje;
        public string Mensaje_conexion
        {
            set { mensaje = value; }
            get { return mensaje; }
        }

        public Conexion()
        {
            //Realizará la conexión con la base de datos AppFranchise
            try //se utiliza un try catch para capturar los posibles errores
            {
                //Realizar la conexión con la BDD
                sqlCon = new SqlConnection("Data Source =LocalHost; Initial Catalog = AppFranchise2; Integrated Security = true");
                sqlCon.Open(); //Abrir la conexión
            }
            catch (SqlException)
            {
                mensaje="No se ha podido establecer la conexión con la base de datos.\nEs posible que la base de datos no se encuentre en el sistema.";//Si la red o la base de datos no tiene el nombre correcto, marcará error
            }
        }

    }
}