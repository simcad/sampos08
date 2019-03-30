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
    public class SupplierDataController : Controller
    {
        

        // GET: GroupData
        List<Supplier> xlist = new List<Supplier>();

        //public IEnumerable<Stock> SearchGroupById(string id)
        //{

        //    return null;


        //}
        public List<SupplierModel> GetSupplier(int id)
        {

            List<SupplierModel> _l = new List<SupplierModel>();
            try
            {
                SupplierModel _sm = new SupplierModel();

                _sm.GetSupplier(id);
                _l.Add(_sm);

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetStockId - model", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);


            }


            return _l;
        }

        
        //Search
        public IEnumerable<Supplier> SearchSupplierById(string id)
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
                    _query = "select top 10 * from suppliers";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from suppliers where supplier_name like '%" + id + "%'" ;
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


                Supplier s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new Supplier();
                    s.sid = int.Parse(dr["sid"].ToString());
                    s.supplier_id = dr["supplier_id"].ToString();
                    s.supplier_name = dr["supplier_name"].ToString();
                    
                   
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Search supplier ById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        #region delete brand
        public bool DeleteSupplierById(int id) 
        {

            bool _ret = false;
            try {
                bool _check = samposoapp.Utility.Utility.CheckSupplierInStock(id);
                if (_check)
                {
                    SupplierModel _gm = new SupplierModel();
                    _ret = _gm.deleteSupplier(id);
                }
                else { _ret = false; }
            
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteSupplierById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save Supplier

        public bool SaveSupplierById(Supplier _supplier)
        {

            bool _ret = false;

            try
            {
                if (_supplier.sid ==0)
                {


                    
                    SupplierModel _gm = new SupplierModel();

                    _gm._supplier = _supplier;
                    _gm.InsertSupplier();
            
                }
                else
                {

                    SupplierModel _gm = new SupplierModel();

                    _gm._supplier = _supplier;
                    _ret = _gm.UpdateSupplier();


                }  


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteBrandById", e);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}