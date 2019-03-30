using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// data acccess
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Angularjs.UIRouting.WebApp.Models
{
    public class clsBase
    {
        public int ID{get; set;}
        public string Company{get; set;}
        public string Company_Id{get; set;}
        public string globalUser { get; set; }
        public string salepersonId { get; set; }

    }

    public class BaseModel
    {
        public clsBase _base { get; set; }
        public List<clsBase> _BASE { get; set; }

        public void GetBASE()
        {

            List<clsBase> _gList = new List<clsBase>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {

                
                
                _query = "Select top 1 * from company"; 
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _query;
                _mycommand.ExecuteNonQuery();


                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);
                _mydatatable = _ds.Tables[0];

                
                
               clsBase g;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new clsBase();
                    g.Company_Id = dr["company_id"].ToString();
                    g.globalUser =dr["company_name"].ToString().Substring(0,5);
                    
                    //g.Gst_stDate =DateTime.Parse(dr["Gst_stDate"].ToString());
                    //g.GST_endDate = DateTime.Parse(dr["GST_endDate"].ToString());
                    

                    


                    _gList.Add(g);

                }

                _BASE = _gList.ToList();
                // return _Brand;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load company", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }

    }
}