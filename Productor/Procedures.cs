using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace Productor
{
    public class Procedures
    {
        public Procedures()
        {
            
        }

        public string insert_prod(OracleConnection conn, string cod, string nombre, string marca, string desc, double compra, double venta, string material)
        {
            //Insert
            OracleParameter p_cod = new OracleParameter();
            p_cod.OracleDbType = OracleDbType.Varchar2;
            p_cod.Value = cod;

            OracleParameter p_nombre = new OracleParameter();
            p_nombre.OracleDbType = OracleDbType.Varchar2;
            p_nombre.Value = nombre;

            OracleParameter p_marca = new OracleParameter();
            p_marca.OracleDbType = OracleDbType.Varchar2;
            p_marca.Value = marca;

            OracleParameter p_desc = new OracleParameter();
            p_desc.OracleDbType = OracleDbType.Varchar2;
            p_desc.Value = desc;

            OracleParameter p_compra = new OracleParameter();
            p_compra.OracleDbType = OracleDbType.Double;
            p_compra.Value = compra;

            OracleParameter p_venta = new OracleParameter();
            p_venta.OracleDbType = OracleDbType.Double;
            p_venta.Value = venta;

            OracleParameter p_material = new OracleParameter();
            p_material.OracleDbType = OracleDbType.Varchar2;
            p_material.Value = material;

            OracleCommand cmd = new OracleCommand("insert_prod", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_cod);
            cmd.Parameters.Add(p_nombre);
            cmd.Parameters.Add(p_marca);
            cmd.Parameters.Add(p_desc);
            cmd.Parameters.Add(p_compra);
            cmd.Parameters.Add(p_venta);
            cmd.Parameters.Add(p_material);


            //return cmd.Parameters. .ToString();

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto insertado";
            }
            catch
            {
                return "Error al insertar el nuevo producto";
            }
            
        }

        public string get_prod(OracleConnection conn, int idprod)//Select
        {
            OracleParameter p_id = new OracleParameter();
            p_id.OracleDbType = OracleDbType.Int16;
            p_id.Value = idprod;

            OracleCommand cmd = new OracleCommand("get_prod2", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id);
            cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output ;

            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);

                conn.Dispose();

                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch(Exception ex)
            {
                return "ERROR al obtener el producto" + ex.Message;
            }

            //dataGridView.DataSource = data;


        }

        public string get_all_prod(OracleConnection conn)
        {
            OracleCommand cmd = new OracleCommand("get_AllProd", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            try
            {

                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);

                conn.Dispose();

                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "ERROR al obtener el producto" + ex.Message;
            }

            //dataGridView.DataSource = data;


        }

        public string update_prod(OracleConnection conn, int id, string cod, string nombre, string marca, string desc, double compra, double venta, string material)
        {
            OracleParameter p_id = new OracleParameter();
            p_id.OracleDbType = OracleDbType.Varchar2;
            p_id.Value = id;

            OracleParameter p_cod = new OracleParameter();
            p_cod.OracleDbType = OracleDbType.Varchar2;
            p_cod.Value = cod;

            OracleParameter p_nombre = new OracleParameter();
            p_nombre.OracleDbType = OracleDbType.Varchar2;
            p_nombre.Value = nombre;

            OracleParameter p_marca = new OracleParameter();
            p_marca.OracleDbType = OracleDbType.Varchar2;
            p_marca.Value = marca;

            OracleParameter p_desc = new OracleParameter();
            p_desc.OracleDbType = OracleDbType.Varchar2;
            p_desc.Value = desc;

            OracleParameter p_compra = new OracleParameter();
            p_compra.OracleDbType = OracleDbType.Double;
            p_compra.Value = compra;

            OracleParameter p_venta = new OracleParameter();
            p_venta.OracleDbType = OracleDbType.Double;
            p_venta.Value = venta;

            OracleParameter p_material = new OracleParameter();
            p_material.OracleDbType = OracleDbType.Varchar2;
            p_material.Value = material;

            OracleCommand cmd = new OracleCommand("update_prod", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id);
            cmd.Parameters.Add(p_cod);
            cmd.Parameters.Add(p_nombre);
            cmd.Parameters.Add(p_marca);
            cmd.Parameters.Add(p_desc);
            cmd.Parameters.Add(p_compra);
            cmd.Parameters.Add(p_venta);
            cmd.Parameters.Add(p_material);


            //return cmd.Parameters. .ToString();

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto actualizado";
            }
            catch
            {
                return "Error al actualizar el producto";
            }
        }

        public string delete_prod(OracleConnection conn, int id)
        {
            OracleParameter p_id = new OracleParameter();
            p_id.OracleDbType = OracleDbType.Varchar2;
            p_id.Value = id;

            OracleCommand cmd = new OracleCommand("delete_prod", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto eliminado";
            }
            catch
            {
                return "Error al eliminar el producto";
            }
        }
    }
}