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
    public class CreditcardDataController : Controller
    {


        // GET: GroupData
        List<Creditcard> xlist = new List<Creditcard>();




        //}
        public List<CreditcardModel> GetCreditcardId(string id)
        {

            List<CreditcardModel> _l = new List<CreditcardModel>();
            try
            {
                CreditcardModel _sm = new CreditcardModel();


                
                _sm.GetCreditcardCharges(id);
                _l.Add(_sm);

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetCommissionId - model", e);



            }


            return _l;
        }


        //Search
        public IEnumerable<Creditcard> GetCreditcardById(string id)
        {

            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {
                if (id=="^")
                //if (id.Length == 0)
                {
                   // _query = "select * from sales_commission";// where group_desc  = ''";
                    //_query = "SELECT m_id,m_msg FROM g_msg order by  m_msg";
                    _query = "SELECT top 20 credit_card_id, credit_card_charges_desc,";
                    _query += "credit_card_charges_comm, c_file_name FROM  credit_card_charges order by credit_card_id";

                }
                else
                {
                   
                     _query="SELECT  credit_card_id, credit_card_charges_desc,";
                     _query += "credit_card_charges_comm, c_file_name FROM  credit_card_charges where credit_card_charges_desc like '%" + id + "%'";
                    //_query = "SELECT m_id,m_msg FROM g_msg where m_msg like  '%" + id + "%'";
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



                Creditcard s;
                foreach (DataRow dr in _mydatatable.Rows)
                {





                    s = new Creditcard();
                    s.credit_card_id = dr["credit_card_id"].ToString();
                    s.credit_card_charges_desc = dr["credit_card_charges_desc"].ToString();
                    s.credit_card_charges_comm = double.Parse(dr["credit_card_charges_comm"].ToString());
                    s.c_file_name = dr["c_file_name"].ToString();
                    
                    


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


        #region delete credit card
        public bool DeleteCreditcardById(string _mid)
        {

            bool _ret = false;
            try
            {
                bool _check = samposoapp.Utility.Utility.CheckCreditCardInSale(_mid);
                if (_check)
                {
                   

                    CreditcardModel _mm = new CreditcardModel();


                    _ret = _mm.deleteCreditcard(_mid);
                }
                else { _ret = false; }

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteCreditById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save message

        public bool SaveCreditcardById(Creditcard _mcc)
        {

            bool _ret = false;

            try
            {
                if (_mcc.add==1)
                {


                    
                    CreditcardModel _mm = new CreditcardModel();
                    _mm._creditcardchareges = _mcc;
                    _mm.InsertCreditcard();

                }
                else
                {

                  
                    //SysMessageModel _mm = new SysMessageModel();
                    //_mm._message = _msg;

                    //_ret = _mm.UpdateMessage();
                    CreditcardModel _mm = new CreditcardModel();
                    _mm._creditcardchareges = _mcc;
                    _mm.UpdateCreditcard();


                }


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("SaveCreditcardById", e);
                _ret = false;



            }

            return _ret;



        }


        #endregion


        //ene of controller
    }
}
