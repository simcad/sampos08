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
    public class Transaction
    {
      
        public int transaction_id_1{get; set;}
        public string transaction_type{get; set;}
        public string transaction_id{get; set;}
        public int transaction_ref_no{get; set;}
        public string supplier_id{get; set;}
        public string transaction_code_ref{get; set;}
        public Nullable<System.DateTime> transaction_date { get; set; }
        public string stock_code{get; set;}
        public float transaction_quantity{get; set;}
        public float transaction_average_cost{get; set;}
        public float transaction_amount{get; set;}
        public string global_user_id{get; set;}
        public string transaction_update_date{get; set;}
        public string transaction_period{get; set;}
        public string company_id{get; set;}
        public string barcode{get; set;}

 
    


    }

    public class TransactionModel
    {
        public Transaction _transaction { get; set; }
        public List<Transaction> _Transaction { get; set; }

        public bool InsertTX_Stock()
        {
            bool _return;

            OleDbCommand _mycommand = new OleDbCommand();
           
            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            
            string  strSQL;
            //DataSet _ds = new DataSet();

            try 
            {

                 strSQL = "INSERT INTO [transaction] ( transaction_type, transaction_date ,  ";
                strSQL = strSQL + " transaction_amount, transaction_id, company_id, transaction_period,";
                strSQL = strSQL + " stock_code, transaction_average_cost,";
                strSQL = strSQL + " transaction_quantity,transaction_update_date,global_user_id, transaction_code_ref,barcode,supplier_id,transaction_ref_no) ";
                strSQL = strSQL + " Values (";
                strSQL = strSQL + "@transaction_type, @transaction_date, "; 
                strSQL = strSQL + "@transaction_amount, @transaction_id, @company_id, @transaction_period,";
                strSQL = strSQL + "@stock_code, @transaction_average_cost,";
                strSQL = strSQL + " @transaction_quantity,@transaction_update_date,@global_user_id, @transaction_code_ref,@barcode,@supplier_id,@transaction_ref_no) ";
           
            _mycommand.Parameters.Clear();
            _mycommand.Parameters.AddWithValue("@transaction_type", _transaction.transaction_type);
            _mycommand.Parameters.AddWithValue("@transaction_date", _transaction.transaction_date);
            _mycommand.Parameters.AddWithValue("@transaction_amount", _transaction.transaction_amount);
            _mycommand.Parameters.AddWithValue("@transaction_id", _transaction.transaction_id);
            _mycommand.Parameters.AddWithValue("@company_id", _transaction.company_id);
            _mycommand.Parameters.AddWithValue("@transaction_period", _transaction.transaction_period);
            _mycommand.Parameters.AddWithValue("@stock_code", _transaction.stock_code);
            _mycommand.Parameters.AddWithValue("@transaction_average_cost", _transaction.transaction_average_cost);
            _mycommand.Parameters.AddWithValue("@transaction_quantity", _transaction.transaction_quantity);
            _mycommand.Parameters.AddWithValue("@transaction_update_date", _transaction.transaction_update_date);
            _mycommand.Parameters.AddWithValue("@global_user_id", _transaction.global_user_id);
            _mycommand.Parameters.AddWithValue("@transaction_code_ref", _transaction.transaction_code_ref + "");
            _mycommand.Parameters.AddWithValue("@barcode", _transaction.barcode);
            _mycommand.Parameters.AddWithValue("@supplier_id", _transaction.supplier_id);
            _mycommand.Parameters.AddWithValue("@transaction_ref_no", _transaction.transaction_ref_no);

            

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();


                _return = true;

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("Transaction", e);
                _return = false;
                
            }
            return _return;
        }

    }
}