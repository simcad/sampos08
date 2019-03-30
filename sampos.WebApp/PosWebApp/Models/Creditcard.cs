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

    //credit_card_charges
    public class Creditcard
    {


       // public int m_id { get; set; }
        //public string m_msg { get; set; }
        public string credit_card_id {get;set;}
        public string credit_card_charges_desc{get;set;}
        public double credit_card_charges_comm{get;set;}
        public string c_file_name {get;set;}
        public int add { get; set; }  

        
        //public int? add { get; set; }
    }

    public class CreditcardModel
    {
        public Creditcard _creditcardchareges { get; set; }
        public List<Creditcard> _Creditcardcharges { get; set; }
        
        #region insert

        public bool InsertCreditcard()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into credit_card_charges (credit_card_id,credit_card_charges_desc,credit_card_charges_comm) values (?,?,?) ";


                
                
                
                if (string.IsNullOrEmpty(_creditcardchareges.credit_card_id))
                {
                    _mycommand.Parameters.AddWithValue("@credit_card_id", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@credit_card_id", _creditcardchareges.credit_card_id); }




                
                
                if (string.IsNullOrEmpty(_creditcardchareges.credit_card_charges_desc))
                {
                    _mycommand.Parameters.AddWithValue("@credit_card_charges_desc", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@credit_card_charges_desc", _creditcardchareges.credit_card_charges_desc); }



                _mycommand.Parameters.AddWithValue("@credit_card_charges_comm", _creditcardchareges.credit_card_charges_comm);

                //if (string.IsNullOrEmpty(_creditcardchareges.c_file_name))
                //{
                //    _mycommand.Parameters.AddWithValue("@c_file_name", DBNull.Value);
                //}
                //else { _mycommand.Parameters.AddWithValue("@c_file_name", _creditcardchareges.c_file_name); }

               


              

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Insert credit card charges", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateCreditcard()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                string   _credit_card_id = _creditcardchareges.credit_card_id.ToString(); // _group.group_id;
                strSQL = "Update  credit_card_charges set credit_card_charges_desc=@credit_card_charges_desc, ";
                strSQL += " credit_card_charges_comm=@credit_card_charges_comm"; 
                strSQL+= " where credit_card_id='" + _credit_card_id  + "'";

                //_mycommand.Parameters.AddWithValue("@credit_card_id", _creditcardchareges.credit_card_id);

                if (string.IsNullOrEmpty(_creditcardchareges.credit_card_charges_desc))
                {
                    _mycommand.Parameters.AddWithValue("@credit_card_charges_desc", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@credit_card_charges_desc", _creditcardchareges.credit_card_charges_desc); }

                _mycommand.Parameters.AddWithValue("@credit_card_charges_comm", _creditcardchareges.credit_card_charges_comm);

                if (string.IsNullOrEmpty(_creditcardchareges.c_file_name))
                {
                    _mycommand.Parameters.AddWithValue("@c_file_name", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@c_file_name", _creditcardchareges.c_file_name); }

               

                

               
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update credit card", e);
                return false;
            }
            return true;

        }
        #endregion end update
        
        
        #region delete
        public bool deleteCreditcard(string _id)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
               
                //_query = "SELECT  credit_card_id, credit_card_charges_desc,";
                    //_query += "credit_card_charges_comm, c_file_name FROM  credit_card_charge
                strSQL = "delete from credit_card_charges where credit_card_id='" + _id + "'";

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete message", e);
                return false;
            }
            return true;


        }

        #endregion end delete

        public void GetCreditcardCharges(string id)
        {

            List<Creditcard> _gList = new List<Creditcard>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            _query = "";

            try
            {

                if (id == "")
                {
                    //_query = "select * from sales_commission order by sales_commission_id";
                    
                    _query = "SELECT  credit_card_id, credit_card_charges_desc,";
                    _query += "credit_card_charges_comm, c_file_name FROM  credit_card_charges";



                }
                else
                {
                    //_query = "select * from sales_commission where sales_commission_id ='" + id + "'";
                    //credit_card_id
                    
                    _query = "SELECT  credit_card_id, credit_card_charges_desc,";
                    _query += "credit_card_charges_comm, c_file_name FROM  credit_card_charges where credit_card_id='" + id + "'";
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

                Creditcard g;
               
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new Creditcard();
                    g.credit_card_id = dr["credit_card_id"].ToString();
                    g.credit_card_charges_desc = dr["credit_card_charges_desc"].ToString();
                    g.credit_card_charges_comm = double.Parse(dr["credit_card_charges_comm"].ToString());
                    g.c_file_name = dr["c_file_name"].ToString();
                    
                    
                    


                    _gList.Add(g);

                }
                // js must refer to this or set to data
                _Creditcardcharges = _gList.ToList();
                //_Commission = _gList.ToList();
                


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load credit charges", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }


    }
}