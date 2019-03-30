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
using samposoapp.db;

namespace  samposoapp.Utility
{
    public partial class Utility
    {
        public static bool CheckSupplierInStock(int _id) 
        {

            bool _ret = false;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";
            _sql = "SELECT count(*) as csupplier from stock inner join suppliers on stock.supplier_id=suppliers.supplier_id ";
            _sql = _sql + "where suppliers.sid=" + _id + "";



            try
            {

                OleDbConnection _conn = new OleDbConnection();

                DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["csupplier"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }

            }
            catch (Exception e)
            {
                _ret = false; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check supplier in stock", e);
            }
            return _ret;

        
        
        
        
        
        
        }


        //select count(commission_id) from stock_sales where commission_id ='a2'

        public static bool CheckCommissionInSale(string _id)
        {
            bool _ret = false;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";

            _sql = "select count(commission_id) as cc from stock_sales where commission_id ='" + _id + "'";


            try
            {

                OleDbConnection _conn = new OleDbConnection();

                DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["cc"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }

            }
            catch (Exception e)
            {
                _ret = false; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check commission in sales", e);
            }
            return _ret;

        }

        public static bool CheckCreditCardInSale(string _id)
        {
            bool _ret = false;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";

            _sql = "select count(card_type) as cc from payment where card_type ='" + _id + "'";


            try
            {

                OleDbConnection _conn = new OleDbConnection();

                DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["cc"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }

            }
            catch (Exception e)
            {
                _ret = false; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check commission in sales", e);
            }
            return _ret;

        }

        public static bool CheckBrandInStock(int _id)
        {
            bool _ret = false;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";
            _sql = "SELECT count(*) as cbrand from stock inner join brand on stock.brand_id=brand.brand_id ";          
            _sql =_sql + "where brand.id=" + _id + "";



            try
            {

                OleDbConnection _conn = new OleDbConnection();

                DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["cbrand"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }

            }
            catch (Exception e)
            {
                _ret = false; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check brand in stock", e);
            }
            return _ret;

        }
        public static bool CheckGroupInStock(string _groupid) 
        {
            bool _ret = false;
              
            OleDbCommand _mycommand = new OleDbCommand();
            
            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";
            _sql = "SELECT count(*) as cgroup from stock where group_id='" + _groupid + "'";
            

            
            try
            {

             OleDbConnection _conn = new OleDbConnection();
             
             DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["cgroup"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }
                
             }
            catch (Exception e){
                _ret = false; ; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check gruop id in stock", e);
            }
            return _ret;
        
        }

        // message
        public static bool CheckMessageInSale(int _id)
        {
            bool _ret = false;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";

            _sql = "select count(commission_id) as cc from stock_sales where commission_id ='" + _id + "'";


            try
            {

                OleDbConnection _conn = new OleDbConnection();

                DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);

                int _counter = Convert.ToInt32(_ds.Tables[0].Rows[0]["cc"]);
                if (_counter == 0) { _ret = true; } else { _ret = false; }

            }
            catch (Exception e)
            {
                _ret = false; // can update 
                samposoapp.ErrorLog.ErrorLog.ccException("check commission in sales", e);
            }
            return _ret;

        }

        public static int GetSequenceNumber(string _type) {

            int _id = 0;
            OleDbCommand _mycommand = new OleDbCommand();
            

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _sql = "";
            _sql = "SELECT max(seq_number.sequence_number) as cu FROM seq_number";
            _sql = _sql +  " where seq_number.sequence_number_type='" + _type + "'";

            //_sql = "SELECT max(Id) as cu FROM customer";
            try
            {

             OleDbConnection _conn = new OleDbConnection();
             
             DataSet _ds = new DataSet();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);
                
                int Contract_id = Convert.ToInt32(_ds.Tables[0].Rows[0]["cu"]);
                _id = Contract_id + 1;
                // upate the 
                _sql = "Update seq_number set sequence_number =" + _id + " where seq_number.sequence_number_type='" + _type + "'";
                _mycommand.CommandText = _sql;
                _mycommand.ExecuteNonQuery();
             }
            catch (Exception e){
                samposoapp.ErrorLog.ErrorLog.ccException("get sequence id", e);
            }
            return _id;
        }
    }
}