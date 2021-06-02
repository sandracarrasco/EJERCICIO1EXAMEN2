using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string nombre)
        {
            return "Hola a todos";
        }
        [WebMethod]
        public int suma(int a,int b)
        {
            return a + b;
        }


        [WebMethod]
        public DataSet materia(int ci)
        {
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            con.ConnectionString = "SERVER=LAPTOP-BSK5MLUQ;DATABASE=materias;integrated security=true;";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.CommandText = "select materia from materia where ci='"+ci+"'";
            ada.SelectCommand.CommandType = CommandType.Text;
            ada.SelectCommand.Connection = con;
            DataSet ds = new DataSet();
            ada.Fill(ds);
            return ds;
        }

        [HttpPost]
        public string Materia(int ci)
        {
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            con.ConnectionString = "SERVER=LAPTOP-BSK5MLUQ;DATABASE=materias;integrated security=true;";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.CommandText = "select materia from materia where ci='" + ci + "'";
            ada.SelectCommand.CommandType = CommandType.Text;
            ada.SelectCommand.Connection = con;
            
            return ada.ToString();
        }


    }
}
