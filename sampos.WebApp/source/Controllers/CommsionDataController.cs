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
    public class CommmissionDataController : Controller
    {
        

        // GET: GroupData
        List<Commission> xlist = new List<Commission>();

      


        //}
        public List<CommissionModel> GetCommissionId(string id)
        {

            List<CommissionModel> _l = new List<CommissionModel>();
            try {
                CommissionModel _sm = new CommissionModel();
                
                
                _sm.GetCommission(id);
                _l.Add(_sm);

            }
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccException("GetCommissionId - model", e);
             

                
            }


            return _l;
        }

        
        //Search
        public IEnumerable<Commission> GetSCommissionById(string id)
        {
        
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {

                if (id.Length == 0 || id=="0")
                {
                    _query = "select * from sales_commission";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from sales_commission where sales_commission_desc like '%" + id + "%'";
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


                Commission s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new Commission();

                    s.sales_commission_id = dr["sales_commission_id"].ToString();
                    s.sales_commission_desc = dr["sales_commission_desc"].ToString();

                    s.sales_commission_charges = float.Parse(dr["sales_commission_charges"].ToString());
                   
                   
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
        public bool DeleteCommissionById(string _groupid) 
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

        public bool SaveCommissionById(Commission _commission)
        {

            bool _ret = false;

            try
            {
                if (_commission.add ==1)
                {


                    
                    CommissionModel _gm = new CommissionModel();

                    _gm._commission = _commission;
                    _gm.InsertCommission();
            
                }
                else
                {

                    CommissionModel _gm = new CommissionModel();
                    _gm._commission = _commission;
                    _ret = _gm.UpdateCommission();


                }  


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteCommissionById", e);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}