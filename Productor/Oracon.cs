using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Oracle.ManagedDataAccess.Client;

namespace Productor
{
    public class Oracon
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=EMPRESACAMARA;PASSWORD=Sistora1";

        public void OpenCon()
        {
            oc = new OracleConnection(oradb);
            oc.Open();
        }

        public OracleConnection GetCon()
        {
            return oc;
        }

        public OracleConnection Conn
        {
            get { return oc; }
        }

    }
}