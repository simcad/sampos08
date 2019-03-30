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
    public class Group
    {
        public string group_id { get; set; }
        public string group_desc { get; set; }
        public int group_min { get; set; }
        public int group_max { get; set; }
        public bool group_Servcie { get; set; }


    }

    public class GroupModel
    {
        public Group _group { get; set; }
        public List<Group> _Group { get; set; }
        
        #region insert

        public bool InsertGroup() 
        {
            
            string strSQL;

            try 
                {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into b_group (group_id, group_desc, group_Service) values (?,?,?) "; 


                if (string.IsNullOrEmpty(_group.group_id))
                {
                    _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@group_id", _group.group_id); }

                if (string.IsNullOrEmpty(_group.group_desc))
                {
                    _mycommand.Parameters.AddWithValue("@group_desc", DBNull.Value);
                }
                else
                {
                    
                    _mycommand.Parameters.AddWithValue("@group_desc", _group.group_desc); 
                }

                             
                _mycommand.Parameters.AddWithValue("@group_service", bool.Parse(_group.group_Servcie.ToString()));
               
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e) {

                samposoapp.ErrorLog.ErrorLog.ccException("Insert group", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateGroup()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                string _gid = _group.group_id;
                strSQL = "Update b_group set group_desc=@group_desc,group_servcie=@group_service where group_id='"  + _gid + "'" ;



                if (string.IsNullOrEmpty(_group.group_desc))
                {
                    _mycommand.Parameters.AddWithValue("@group_desc", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@group_desc", _group.group_desc);
                }

                _mycommand.Parameters.AddWithValue("@group_service", _group.group_Servcie);

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

                samposoapp.ErrorLog.ErrorLog.ccException("Update group", e);
                return false;
            }
            return true;

        }
        #endregion end update
        
        
        #region delete
        public bool deleteGroup(string _groupid) {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "delete from b_group where group_id='" + _groupid + "'";

                

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete group", e);
                return false;
            }
            return true;
        
        
        }

        #endregion end delete

        public void GetGroup(string id)
        {

            List<Group> _gList = new List<Group>();
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
                    _query = "select * from b_group order by group_id ";
                }
                else
                {
                    _query = "select * from b_group where group_id ='" + id + "'";
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


               Group g;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new Group();
                    g.group_id = dr["group_id"].ToString();
                    g.group_desc = dr["group_desc"].ToString();
                    g.group_max = int.Parse(dr["group_max"].ToString());
                    g.group_min = int.Parse(dr["group_min"].ToString());
                    g.group_Servcie = bool.Parse(dr["group_Servcie"].ToString());
                    


                    _gList.Add(g);

                }

                _Group = _gList.ToList();
                


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load group", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }


    }
}