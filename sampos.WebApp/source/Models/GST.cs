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
    public class clsGST
    {
        public int ID{get; set;}
        public string GST{get; set;}
        public string GST_DESC{get; set;}
        public Nullable<System.DateTime> Gst_stDate { get; set; }
        public Nullable<System.DateTime> GST_endDate { get; set; }
        public string GST_code{get; set;}


    }

    public class GSTModel
    {
        public clsGST _gst { get; set; }
        public List<clsGST> _GST { get; set; }

        public void GetGST(string id)
        {

            List<clsGST> _gList = new List<clsGST>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {

                if (id.Length == 0)
                {
                    _query =  "SELECT id,GST & ' |(%)  ' & GST_code as GST FROM TBL_GST WHERE UCASE(GST_CODE) ='SR'  or ucase(GST_code) ='ZRL'";
                    _query = "SELECT *  FROM TBL_GST WHERE UCASE(GST_CODE) ='SR'  or ucase(GST_code) ='ZRL'"; 
                    //,[brand_desc]
                }
                else
                {
                    _query = "SELECT id,GST & ' |(%)  ' & GST_code as GST FROM TBL_GST WHERE UCASE(GST_CODE) ='SR'  or ucase(GST_code) ='ZRL'";
                    _query = "SELECT *  FROM TBL_GST WHERE UCASE(GST_CODE) ='SR'  or ucase(GST_code) ='ZRL'"; 
                }
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _query;
                _mycommand.ExecuteNonQuery();


                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);
                _mydatatable = _ds.Tables[0];


               clsGST g;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new clsGST();
                    g.ID = int.Parse(dr["ID"].ToString());
                    g.GST = dr["GST"].ToString();
                    g.GST_DESC = dr["GST_DESC"].ToString();
                    //g.Gst_stDate =DateTime.Parse(dr["Gst_stDate"].ToString());
                    //g.GST_endDate = DateTime.Parse(dr["GST_endDate"].ToString());
                    g.GST_code = dr["GST_code"].ToString();

                    


                    _gList.Add(g);

                }

                _GST = _gList.ToList();
                // return _Brand;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load GST", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }

    }
}