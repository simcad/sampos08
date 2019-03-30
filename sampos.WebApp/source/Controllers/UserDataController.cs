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
    public class UserDataController : Controller
    {
        

        // GET: GroupData
        List<User> xlist = new List<User>();

      


        //}
        public List<UserModel>GetUserId(string id)
        {

            List<UserModel> _l = new List<UserModel>();
            try {
                UserModel _sm = new UserModel();
                
                
                _sm.GetUser(id);
                _l.Add(_sm);

            }
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccException("Getuserd - model", e);
             

                
            }


            return _l;
        }

        
        //Search
        public IEnumerable<User> GetUserById_str(string id)
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
                    _query = "select * from users";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from users where user_name like '%" + id + "%'";
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


                User s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new User();
                    s.user_id = dr["user_id"].ToString();
                    s.user_name= dr["user_name"].ToString();
                   // s.sales_commission_id = dr["sales_commission_id"].ToString();
                    //s.sales_commission_desc = dr["sales_commission_desc"].ToString();

                    //s.sales_commission_charges = float.Parse(dr["sales_commission_charges"].ToString());
                   
                   
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetSCommissionById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;
                return xlist;

            }

            
        }


        #region delete group
        public bool DeleteUserById(string _groupid) 
        {

            bool _ret = false;
            try {
                bool _check = samposoapp.Utility.Utility.CheckCommissionInSale(_groupid);
                if (_check)
                {
                    CommissionModel _gm = new CommissionModel();
                    _ret = _gm.deleteCommission(_groupid);
                }
                else { _ret = false; }
            
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteCommissionById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save group

        public bool SaveUserById(User _user)
        {

            bool _ret = false;

            try
            {
                if (_user.add ==1)
                {



                    UserModel _gm = new UserModel();

                    //_gm._commission = _commission;
                   /// _gm.InsertCommission();
            
                }
                else
                {

                    UserModel _gm = new UserModel();
                    _gm._user = _user;
                    _ret =  _gm.UpdateUser();


                }  


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteuserById", e);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}