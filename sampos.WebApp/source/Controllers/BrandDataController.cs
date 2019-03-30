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
    public class BrandDataController : Controller
    {
        

        // GET: GroupData
        List<Brand> xlist = new List<Brand>();

        //public IEnumerable<Stock> SearchGroupById(string id)
        //{

        //    return null;


        //}
        public List<BrandModel> GetBrand(int id)
        {

            List<BrandModel> _l = new List<BrandModel>();
            try
            {
                BrandModel _sm = new BrandModel();

                _sm.GetBrand(id);
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
        public IEnumerable<Brand> GetSBrandById(string id)
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
                    _query = "select * from brand";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from brand where brand_desc like '%" + id + "%'" ;
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


                Brand s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new Brand();
                    s.brand_id = dr["brand_id"].ToString();
                    s.brand_desc = dr["brand_desc"].ToString();
                    s.id = int.Parse(dr["id"].ToString());
                   
                   
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetBrandById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        #region delete brand
        public bool DeleteBrandById(int id) 
        {

            bool _ret = false;
            try {
                bool _check = samposoapp.Utility.Utility.CheckBrandInStock(id);
                if (_check)
                {
                    BrandModel _gm = new BrandModel();
                    _ret = _gm.deleteBrand(id);
                }
                else { _ret = false; }
            
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteBrandById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save brand

        public bool SaveBrandById(Brand _brand)
        {

            bool _ret = false;

            try
            {
                if (_brand.id ==0)
                {


                    
                    BrandModel _gm = new BrandModel();

                    _gm._brand = _brand;
                    _gm.InsertBrand();
            
                }
                else
                {

                    BrandModel _gm = new BrandModel();

                    _gm._brand = _brand;
                    _ret = _gm.UpdateBrand();


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