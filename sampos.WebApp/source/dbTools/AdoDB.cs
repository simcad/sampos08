using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Web;
namespace samposoapp.db
{


    public class SqlDatabaseUtility
    {


        public static string DB_SERVER { get; set; }
        public static string DB_ACCESS { get; set; }


        
        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }  
        public static string DStoJSon(string _dsname) { 
        
        DataSet dataSet = new DataSet(_dsname);
        dataSet.Namespace = "NetFrameWork";
        DataTable table = new DataTable();
        DataColumn idColumn = new DataColumn("id", typeof(int));
        idColumn.AutoIncrement = true;
 
        DataColumn itemColumn = new DataColumn("item");
        table.Columns.Add(idColumn);
        table.Columns.Add(itemColumn);
        dataSet.Tables.Add(table);

        for (int i = 0; i < 2; i++)
        {
            DataRow newRow = table.NewRow();
            newRow["item"] = "item " + i;
            table.Rows.Add(newRow);
        }

        dataSet.AcceptChanges();

        string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
        return json;
        //Console.WriteLine(json);
        
        }
        public static OleDbConnection GetConnection_db()
        {

            string _dbpath_file = ConfigurationManager.AppSettings["DatabasePath"];

            //string _dbpath = HttpContext.Current.Server.MapPath("~\\App_Data\\sam_2003.mdb");

            string _dbpath = HttpContext.Current.Server.MapPath(_dbpath_file);
            try {
                
                //string _dbpath = "C:\\Users\\Peter\\Documents\\simcad_projects\\samposoapp\\samposoapp\\App_Data\\samposdb.mdb;";
               
                // string _dbpath = "C:\\Users\\Peter\\Documents\\simcad_projects\\samposoapp\\samposoapp\\App_Data\\sam_2003.mdb;";
                string _cstr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _dbpath + "; Jet OLEDB:Database Password=amsp38;";
                OleDbConnection conn = new OleDbConnection(_cstr);

                //samposoapp.ErrorLog.ErrorLog.ccLog(_cstr);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();

                }
                
                return conn;

            }
            catch(Exception e){
                string errmsg = e.Message + " dbpath:" + _dbpath;

                //samposoapp.ErrorLog.ErrorLog.ccLog(errmsg);
                samposoapp.ErrorLog.ErrorLog.ccException("calling GetConnection_db", e);

                return null;
            }
            // ODBC -- Standard Security


            



        }
        public static SqlConnection GetConnection(string connectionName="ChildCheckDB")
        {
            string cnstr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection cn = new SqlConnection(cnstr);
            
            
            cn.Open();

            return cn;
        }
        public static string getdbname(string connectionName = "ChildCheckDB")
        {

           
            string cnstr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            
            SqlConnection cn = new SqlConnection(cnstr);
            DB_SERVER = cn.Database.ToString();
            
            return DB_SERVER;

        }


       public static DataTable ExecuteQueryString(string _sql)
       {
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            
            DataSet _ds = new DataSet();
        
            try
            {

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();


                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);
                _mydatatable = _ds.Tables[0];
                return _mydatatable;

            }
           catch (Exception e) {

               samposoapp.ErrorLog.ErrorLog.ccException("GetCustomerById_int", e);
               return null;
           
           }
       }


        /*
         *   sql statement
         * 
         */
        public static SqlDataReader ExecuteQueryString(
            //string connectionName = "ChildCheckDB",
            string sql,
            Dictionary<string, SqlParameter> procParameters)
        {
            // open a database connection
            SqlConnection cn = GetConnection();

            // create a SQL command to execute the stored procedure
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            // assign parameters passed in to the command
            foreach (var procParameter in procParameters)
            {
                cmd.Parameters.Add(procParameter.Value);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }


        /*
         * 
         * 
         */

        //public static SqlDataReader ExecuteMyReader(
        //    //string connectionName = "ChildCheckDB",
        //    string storedProcName,
        //    Dictionary<string, SqlParameter> procParameters)
        //{
        //    SqlDataReader _rc;
        //    using (SqlConnection cn = GetConnection())
        //    {
        //        // create a SQL command to execute the stored procedure
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = storedProcName;
                

        //        // assign parameters passed in to the command
        //        foreach (var procParameter in procParameters)
        //        {
        //            cmd.Parameters.Add(procParameter.Value);
        //        }
        //        _rc = cmd.ExecuteReader();
        //      //  _rc.Read();

        //        //try
        //        //{
        //        //    // This will fail if its not the last one, as the type signatures won't match the result set
        //        //    // its ok for it to fail as such...
        //        //    //_Return = ((IObjectContextAdapter)this)
        //        //      //  .ObjectContext
        //        //        //.Translate<T>(_rc).ToList();
        //        //    adoResult _r = new adoResult();
        //        //    //_r.UserCode = Int32.Parse(_rc["UserCode"].ToString());
                    
                        
        //        //    //_r.Message = _rc["Message"].ToString();
        //        //    _r.UserCode = Int32.Parse(_rc[0].ToString());
        //        //    //_r.Message = _rc[6].ToString();

                        
        //        //}
        //        //catch (Exception e) {

        //        //    Console.WriteLine(String.Format("{0}", e.Message ));
        //        //    ;
        //        //}

        //        while (_rc.Read())
        //        {
        //            try
        //            {
        //                // This will fail if its not the last one, as the type signatures won't match the result set
        //                adoResult _r = new adoResult();
        //                //_r.UserCode = Int32.Parse(_rc["UserCode"].ToString());
        //                _r.UserCode = Int32.Parse(_rc[0].ToString());
        //                //_r.UserCode = _rc.GetValue(0);
        //                Console.WriteLine(String.Format("{0}", _rc.GetValue(0)));
                        
        //                //_r.Message = _rc[6].ToString();
        //                //_r.Message = _rc["Message"].ToString();
        //            }
        //            catch(Exception e) {

        //                Console.WriteLine(String.Format("{0}", e.Message));
        //                ;
        //            }

        //            //_Count++;
        //        }


        //        //_rc = cmd.ExecuteNonQuery();


        //    }
        //    return _rc;

        //}
        /*
         *   Stored procedure call
         * 
         */
        public static SqlDataReader ExecuteQuery(
            //string connectionName = "ChildCheckDB",
            string storedProcName,
            Dictionary<string, SqlParameter> procParameters )
        {
            // open a database connection
            SqlConnection cn = GetConnection();

            // create a SQL command to execute the stored procedure
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcName;

            // assign parameters passed in to the command
            foreach (var procParameter in procParameters)
            {
                cmd.Parameters.Add(procParameter.Value);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteCommand(
            //string connectionName = "ChildCheckDB",
            string storedProcName,
            Dictionary<string, SqlParameter> procParameters
        )
        {
            int rc;

            using (SqlConnection cn = GetConnection())
            {
                // create a SQL command to execute the stored procedure
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcName;
                
 
                // assign parameters passed in to the command
                foreach (var procParameter in procParameters)
                {
                    cmd.Parameters.Add(procParameter.Value);
                }
                
                rc = cmd.ExecuteNonQuery();
            }

            return rc;
        }
    }


    //public partial class ADODB
    //{
        
        
    //    public SqlConnection conn{get;set;}

    //    public SqlConnection OpenConnection(ref string errMsg)
    //    {
    //        SqlConnection conn;
    //        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChildCheckDB"].ConnectionString);
    //       // connstr = ConfigurationManager.ConnectionStrings["ChildCheckDB"].ConnectionString;

    //        return conn;
    //    }

    
    //}
    public partial class adoResult {

        public int UserCode { get; set; }
        public int Number { get; set; }
        public int Severity { get; set; }
        public int State { get; set; }
        public string ProcedureName { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
    
    }
}
