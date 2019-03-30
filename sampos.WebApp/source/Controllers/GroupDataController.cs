using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;

using System.Net;
using Angularjs.UIRouting.WebApp.Models;
using System.Data.SqlClient;
using System.Data.OleDb;
//using samposoapp.Models;

namespace samposoapp.Controllers
{
    public class GroupDataController : Controller
    {
        

        // GET: GroupData
        List<Group> xlist = new List<Group>();

      


        //}
        public List<GroupModel> GetGroupId(string id)
        {

            List<GroupModel> _l = new List<GroupModel>();
            try {
                GroupModel _sm = new GroupModel();
                
                _sm.GetGroup(id);
                _l.Add(_sm);

            }
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccException("GetGroupId - model", e);
             

                
            }


            return _l;
        }

        
        //Search
        public IEnumerable<Group> GetSGroupById(string id)
        {
        
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
                    _query = "select * from b_group";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from b_group where group_desc like '%" + id + "%'" ;
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


                Group s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new Group();
                    s.group_id = dr["group_id"].ToString();
                    s.group_desc = dr["group_desc"].ToString();
                    s.group_max = int.Parse(dr["group_max"].ToString());
                    s.group_min = int.Parse(dr["group_max"].ToString());
                    s.group_Servcie = bool.Parse(dr["group_Servcie"].ToString());
                   
                   
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetSGroupById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        #region delete group
        public bool DeleteGroupById(string _groupid) 
        {

            bool _ret = false;
            try {
                bool _check = samposoapp.Utility.Utility.CheckGroupInStock(_groupid);
                if (_check)
                {
                    GroupModel _gm = new GroupModel();
                    _ret = _gm.deleteGroup(_groupid);
                }
                else { _ret = false; }
            
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteGroupById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save group

        public bool SaveGroupById(Group _group)
        {

            bool _ret = false;

            try
            {
                if (_group.group_max ==1)
                {


                    
                    GroupModel _gm = new GroupModel();

                    _gm._group = _group;
                    _gm.InsertGroup();
            
                }
                else
                {

                    GroupModel _gm = new GroupModel();
                    _gm._group = _group;
                    _ret = _gm.UpdateGroup();


                }  


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteGroupById", e);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}