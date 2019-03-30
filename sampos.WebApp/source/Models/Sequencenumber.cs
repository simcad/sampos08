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

    
    public class Sequencenumber
    {

        //SELECT        sequence_number_type, sequence_number
//FROM            seq_number
        public string sequence_number_type {get;set;}
        public double sequence_number{get;set;}
        public int add { get; set; }
        public string sequence_desc
        {

            
            get
            {
                string _s="";
                
                switch (this.sequence_number_type)
                
                {
                    case "BC":
                        _s="Barcode number";
                        break;
                    case "S1":
                        _s = "Sale invoice number";
                        break;
                    case "OR":
                        _s = "Receipt number";
                        break;
                    case "CU":
                        _s = "Customer Id";
                        break;
                    case "DO":
                        _s = "Deliver Order";
                        break;
                    default:
                        _s = "System sequence number do not edit";
                        break;
                }
                return _s;
            } 


        }

        
        //public int? add { get; set; }
    }

    public class SequencenumberModel
    {
        public Sequencenumber _sequencenumber { get; set; }
        public List<Sequencenumber> _Sequencenumber { get; set; }
        
        #region insert

        public bool InsertSequencenumber()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into seq_number (sequence_number_type,sequence_number) values (?,?) ";




                if (string.IsNullOrEmpty(_sequencenumber.sequence_number_type))
                {
                    _mycommand.Parameters.AddWithValue("@sequence_number_type", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@sequence_number_type", _sequencenumber.sequence_number_type); }



                _mycommand.Parameters.AddWithValue("@sequence_number", _sequencenumber.sequence_number);

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

                samposoapp.ErrorLog.ErrorLog.ccException("Insert sequency number", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateSequencenumber()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                string _sequence_number_type = _sequencenumber.sequence_number_type.ToString(); // _group.group_id;
                strSQL = "Update  seq_number set sequence_number=@sequence_number ";

                strSQL += " where sequence_number_type='" + _sequence_number_type + "'";

                
                _mycommand.Parameters.AddWithValue("@sequence_number", _sequencenumber.sequence_number);

                
               
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update sequence number", e);
                return false;
            }
            return true;

        }
        #endregion end update
        
        
        #region delete
        public bool deleteSequencenumber(string _id)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
               
                
                strSQL = "delete from seq_number where sequence_numbe_type='" + _id + "'";

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete sequence number", e);
                return false;
            }
            return true;


        }

        #endregion end delete

        public void GetSequenceNumber(string id)
        {

            List<Sequencenumber> _gList = new List<Sequencenumber>();
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
                    
                    //_query = "SELECT sequence_number_type ,[sequence_number]  FROM seq_number";
                    _query = "select  *  FROM seq_number";

                }
                else
                {
                    
                    _query = "SELECT *  FROM seq_number where sequence_number_type='" + id + "'"; 
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

                Sequencenumber g;
               
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new Sequencenumber();
                 
                    g.sequence_number_type = dr["sequence_number_type"].ToString();
                    g.sequence_number = double.Parse(dr["sequence_number"].ToString());
                    //g.sequence_desc = dr["sequence_desc"].ToString();
                    //g.sequence_desc


                    _gList.Add(g);

                }
                // js must refer to this or set to data
                
                _Sequencenumber = _gList.ToList();
                //_Commission = _gList.ToList();
                


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load sequence number", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }


    }
}