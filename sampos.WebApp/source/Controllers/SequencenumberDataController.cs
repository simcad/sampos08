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
    public class SequencenumberDataController : Controller
    {


        // GET: GroupData
        List<Sequencenumber> xlist = new List<Sequencenumber>();




        //}
        public List<SequencenumberModel> GetSequencenumberId(string id)
        {

            List<SequencenumberModel> _l = new List<SequencenumberModel>();
            try
            {
                SequencenumberModel _sm = new SequencenumberModel();


                _sm.GetSequenceNumber(id);
                
                _l.Add(_sm);

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetSequencenumberId - model", e);



            }


            return _l;
        }


        //Search
        public IEnumerable<Sequencenumber> GetSequencenumberById(string id)
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
                   
                    _query = "SELECT top 20 * from seq_number ";
                    //_query += "credit_card_charges_comm, c_file_name FROM  credit_card_charges order by credit_card_id";

                }
                else
                {

                    _query = "SELECT top 20 * from seq_number where sequence_number like '%" + id + "%'"; 
                     
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


         
                Sequencenumber s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    

                    

                    s = new Sequencenumber();
                    s.sequence_number_type = dr["sequence_number_type"].ToString();
                    s.sequence_number = int.Parse(dr["sequence_number"].ToString());
                    
                    

                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetSSequenceById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;
                return xlist;

            }


        }


        #region delete credit card
        public bool DeleteSequencenumberById(string _mid)
        {

            bool _ret = false;
            try
            {
                //bool _check = samposoapp.Utility.Utility.CheckCreditCardInSale(_mid);

                //cant delete sequence 
                bool _check = false;
                if (_check)
                {
                   

                    

                    SequencenumberModel _mm = new SequencenumberModel();
                    _ret = _mm.deleteSequencenumber(_mid);
                }
                else { _ret = false; }

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteSequencenumberById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save message

        public bool SaveSequenceNumberById(Sequencenumber _mcc)
        {

            bool _ret = false;

            try
            {
                if (_mcc.add==1)
                {


                    SequencenumberModel _mm = new SequencenumberModel();

                    _mm._sequencenumber = _mcc;
                    _mm.InsertSequencenumber();
                    

                }
                else
                {

                    SequencenumberModel _mm = new SequencenumberModel();

                    _mm._sequencenumber = _mcc;

                    _mm.UpdateSequencenumber();


                }


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("SaveSequencenumberById", e);
                _ret = false;



            }

            return _ret;



        }


        #endregion


        //ene of controller
    }
}
