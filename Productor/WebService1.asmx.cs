using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace Productor
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
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string insert_prod(string cod, string nombre, string marca, string desc, double compra, double venta, string material)
        {
            Oracon conn = new Oracon();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.insert_prod(conn.Conn, cod, nombre, marca, desc, compra, venta, material);
        }

        [WebMethod]
        public string get_prod(int id)
        {
            Oracon conn = new Oracon();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.get_prod(conn.Conn, id);
        }

        [WebMethod]
        public string get_all_prod()
        {
            Oracon conn = new Oracon();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.get_all_prod(conn.Conn);
        }

        [WebMethod]
        public string update_prod(int id, string cod, string nombre, string marca, string desc, double compra, double venta, string material)
        {
            Oracon conn = new Oracon();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.update_prod(conn.Conn, id, cod, nombre, marca, desc, compra, venta, material);
        }

        [WebMethod]
        public string delete_prod(int id)
        {
            Oracon conn = new Oracon();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.delete_prod(conn.Conn, id);
        }
    }
}
