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
    public class SysMessage
    {

        public int m_id { get; set; }
        public string m_msg { get; set; }

        
        //public int? add { get; set; }
    }

    public class SysMessageModel
    {
        public SysMessage _message { get; set; }
        public List<SysMessage> _Message { get; set; }
        
        #region insert

        public bool InsertSysmessage()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into g_msg ( m_msg) values (?) ";

                //m_id,m_msg FROM g_msg
                if (string.IsNullOrEmpty(_message.m_msg))
                {
                    _mycommand.Parameters.AddWithValue("@m_msg", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@m_msg", _message.m_msg); }

               


              

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Insert receipt message", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateMessage()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                int _gid = _message.m_id; // _group.group_id;
                strSQL = "Update  g_msg set m_msg=@msg where m_id=" + _gid + "";



                if (string.IsNullOrEmpty(_message.m_msg))
                {
                    _mycommand.Parameters.AddWithValue("@msg", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@msg", _message.m_msg);
                }

                

               
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update sale receipt", e);
                return false;
            }
            return true;

        }
        #endregion end update
        
        
        #region delete
        public bool deleteMessage(int _id)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
               

                strSQL = "delete from g_msg where m_id=" + _id;

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

        public void GetSystemMessage(int id)
        {

            List<SysMessage> _gList = new List<SysMessage>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            _query = "";

            try
            {

                if (id == 0)
                {
                    //_query = "select * from sales_commission order by sales_commission_id";
                    _query = "SELECT m_id,m_msg FROM g_msg order by  m_msg";



                }
                else
                {
                    //_query = "select * from sales_commission where sales_commission_id ='" + id + "'";

                    _query = "SELECT m_id,m_msg FROM g_msg where m_id=" + id ;
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

                SysMessage g;
               
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new SysMessage();
                    g.m_id = int.Parse(dr["m_id"].ToString());
                    g.m_msg = dr["m_msg"].ToString();
                    
                    
                    


                    _gList.Add(g);

                }
                // js must refer to this or set to data
                _Message = _gList.ToList();
                //_Commission = _gList.ToList();
                


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load System  messages", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }


    }
}