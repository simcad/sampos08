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
    public class Commission
    {
        

        public string sales_commission_id { get; set; }
        public string sales_commission_desc { get; set; }
        public float sales_commission_charges { get; set; }
        public int? add { get; set; }
    }

    public class CommissionModel
    {
        public Commission _commission { get; set; }
        public List<Commission> _Commission { get; set; }
        
        #region insert

        public bool InsertCommission() 
        {
            
            string strSQL;

            try 
                {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into sales_commission (sales_commission_id, sales_commission_desc, sales_commission_charges) values (?,?,?) "; 


                if (string.IsNullOrEmpty(_commission.sales_commission_id))
                {
                    _mycommand.Parameters.AddWithValue("@commission_id", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@commission_id", _commission.sales_commission_id); }

                if (string.IsNullOrEmpty(_commission.sales_commission_desc))
                {
                    _mycommand.Parameters.AddWithValue("@commission_desc", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@commission_desc", _commission.sales_commission_desc); 
                }


                _mycommand.Parameters.AddWithValue("@commission_charges", float.Parse(_commission.sales_commission_charges.ToString()));
               
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e) {

                samposoapp.ErrorLog.ErrorLog.ccException("Insert sales commission", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateCommission()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                string _gid = _commission.sales_commission_id; // _group.group_id;
                strSQL = "Update sales_commission set sales_commission_desc=@commission_desc,sales_commission_charges=@commission_charges where sales_commission_id='" + _gid + "'";



                if (string.IsNullOrEmpty(_commission.sales_commission_desc))
                {
                    _mycommand.Parameters.AddWithValue("@commission_desc", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@commission_desc", _commission.sales_commission_desc);
                }

                _mycommand.Parameters.AddWithValue("@commission_charges", _commission.sales_commission_charges);

                //if (string.IsNullOrEmpty(_group.group_id))
                //{
                //    _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
                //}
                //else { _mycommand.Parameters.AddWithValue("@group_id", _group.group_id); }


                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update commission", e);
                return false;
            }
            return true;

        }
        #endregion end update
        
        
        #region delete
        public bool deleteCommission(string _commissionid) {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "delete from sales_commission where sales_commission_id='" + _commissionid + "'";

                

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete commission", e);
                return false;
            }
            return true;
        
        
        }

        #endregion end delete

        public void GetCommission(string id)
        {

            List<Commission> _gList = new List<Commission>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            _query = "";

            try
            {

                if (id.Length == 0)
                {
                    _query = "select * from sales_commission order by sales_commission_id";
                    



                }
                else
                {
                    _query = "select * from sales_commission where sales_commission_id ='" + id + "'";
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


               Commission g;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new Commission();
                    g.sales_commission_id= dr["sales_commission_id"].ToString();
                    g.sales_commission_desc = dr["sales_commission_desc"].ToString();
                    
                    g.sales_commission_charges = float.Parse(dr["sales_commission_charges"].ToString());
                    


                    _gList.Add(g);

                }

                _Commission = _gList.ToList();
                


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load sales commission", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }


    }
}