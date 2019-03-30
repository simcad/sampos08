using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class SysMessageDataController : Controller
    {


        // GET: GroupData
        List<SysMessage> xlist = new List<SysMessage>();




        //}
        public List<SysMessageModel> GetSysmessageId(int id)
        {

            List<SysMessageModel> _l = new List<SysMessageModel>();
            try
            {
                SysMessageModel _sm = new SysMessageModel();


                _sm.GetSystemMessage(id);
                _l.Add(_sm);

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetCommissionId - model", e);



            }


            return _l;
        }


        //Search
        public IEnumerable<SysMessage> GetSSysmesageById(string id)
        {

            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {
                if (id =="^")
                //if (id.Length == 0)
                {
                   // _query = "select * from sales_commission";// where group_desc  = ''";
                    _query = "SELECT m_id,m_msg FROM g_msg order by  m_msg";

                }
                else
                {
                   // _query = "select * from sales_commission where sales_commission_desc like '%" + id + "%'";
                    _query = "SELECT m_id,m_msg FROM g_msg where m_msg like  '%" + id + "%'";
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


         
                SysMessage s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new SysMessage();

                    s.m_id = int.Parse(dr["m_id"].ToString());
                    s.m_msg = dr["m_msg"].ToString();

                    


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
        public bool DeleteMessageById(int _mid)
        {

            bool _ret = false;
            try
            {
                bool _check = true; //samposoapp.Utility.Utility.CheckMessageInSale(_mid);
                if (_check)
                {
                   

                    SysMessageModel _mm = new SysMessageModel();
                   _ret = _mm.deleteMessage(_mid);
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


        #region save message

        public bool SaveMessageById(SysMessage _msg)
        {

            bool _ret = false;

            try
            {
                if (_msg.m_id == 0)
                {



                 
                    SysMessageModel _mm = new SysMessageModel();
                    _mm._message = _msg;
                    _mm.InsertSysmessage();

                }
                else
                {

                  
                    SysMessageModel _mm = new SysMessageModel();
                    _mm._message = _msg;

                    _ret = _mm.UpdateMessage();



                }


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("SaveMessageById", e);
                _ret = false;



            }

            return _ret;



        }


        #endregion


        //ene of controller
    }
}
