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
    public class StockDataController : Controller
    {
        // GET: StockData
        List<Stock> xlist = new List<Stock>();
        List<Brand> blist = new List<Brand>();

        public List<StockModel> GetStockId(int id, string barcode)
        {

            List<StockModel> _l = new List<StockModel>();
            try {
                StockModel _sm = new StockModel();
                _sm.GetStock(id,barcode);
                _l.Add(_sm);

            }
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccException("GetStockId - model", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                
            }


            return _l;
        }

        public IEnumerable<Stock> GetStockById(int id)
        {
            //List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            Stock s;
            s = new Stock();
            
            try
            {

                if (id==0)
                {
                    _query = "select top 5 * from stock order by barocode desc";//; where id < 50";
                }
                else
                {
                    _query = "select * from stock where idd =" + id;
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


               
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    
                    s.barcode = dr["barcode"].ToString();
                    s.company_id = dr["company_id"].ToString();
                    s.brand_id = dr["brand_id"].ToString();
                    s.stock_model = dr["stock_model"].ToString();
                    s.stock_size = dr["stock_size"].ToString();
                    s.stock_colour = dr["stock_colour"].ToString();
                    s.stock_desc = dr["stock_desc"].ToString();
                    s.group_id = dr["group_id"].ToString();
                    s.supplier_id = dr["supplier_id"].ToString();
                    s.stock_cost_code = dr["stock_cost_code"].ToString();
                    s.stock_average_price = float.Parse(dr["stock_average_price"].ToString());
                    s.stock_cost_price = float.Parse(dr["stock_cost_price"].ToString());
                    s.stock_sales_price = float.Parse(dr["stock_sales_price"].ToString());
                    s.stock_last_transfer_date = DateTime.Parse(dr["stock_last_transfer_date"].ToString());
                    s.stock_quantity_on_hand = float.Parse(dr["stock_quantity_on_hand"].ToString());
                    s.stock_max_discount = float.Parse(dr["stock_max_discount"].ToString());
                    s.stock_location_desc = dr["stock_location_desc"].ToString();
                    s.stock_location_section = dr["stock_location_section"].ToString();
                    s.stock_location_shelf = dr["stock_location_shelf"].ToString();
                    s.tax_rate = float.Parse(dr["tax_rate"].ToString());
                    s.tax_rate_id = int.Parse(dr["tax_rate_id"].ToString());
                    s.tax_yesno = int.Parse(dr["tax_yesno"].ToString());
                    s.tax_file_no = dr["tax_file_no"].ToString();
                    s.stock_GST_price = float.Parse(dr["stock_GST_price"].ToString());
                    s.stock_notes = dr["stock_notes"].ToString();
                    s.stock_margin = float.Parse(dr["stock_margin"].ToString());
                    s.stock_UOM = dr["stock_UOM"].ToString();
                    s.stock_flag = dr["stock_flag"].ToString();
                    s.stock_min = int.Parse(dr["stock_min"].ToString());
                    s.idd = int.Parse(dr["idd"].ToString());
                    s.order = int.Parse(dr["order"].ToString());
                    s.id = int.Parse(dr["id"].ToString());
                    if (dr["stock_exp_date"] == DBNull.Value) { s.stock_exp_date = null; }
                    else
                    {
                        s.stock_exp_date = DateTime.Parse(dr["stock_exp_date"].ToString());
                    }
                    
                    s.stock_max = int.Parse(dr["stock_max"].ToString());
                    s.stock_sales_price1 = float.Parse(dr["stock_sales_price1"].ToString());
                    s.stock_GST_price1 = float.Parse(dr["stock_GST_price1"].ToString());
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetCustomerById_int", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        public IEnumerable<Stock> GetStockById(string id)
        {
            //List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            
            

            try
            {

                if (id.Length == 0 || id=="0") {
                    _query = "select top 10 * from stock";//   = ''";
                }
                else
                {
                    _query = "select * from stock where stock_desc like '%" + id + "%' or stock_model like '%" + id + "%'" ;
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


                Stock s;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    s = new Stock();
                    s.barcode = dr["barcode"].ToString();
                    s.company_id = dr["company_id"].ToString();
                    s.brand_id = dr["brand_id"].ToString();
                    s.stock_model = dr["stock_model"].ToString();
                    s.stock_size = dr["stock_size"].ToString();
                    s.stock_colour = dr["stock_colour"].ToString();
                    s.stock_desc = dr["stock_desc"].ToString();
                    s.group_id = dr["group_id"].ToString();
                    s.supplier_id = dr["supplier_id"].ToString();
                    s.stock_cost_code = dr["stock_cost_code"].ToString();
                    s.stock_average_price = float.Parse(dr["stock_average_price"].ToString());
                    s.stock_cost_price = float.Parse(dr["stock_cost_price"].ToString());
                    s.stock_sales_price = float.Parse(dr["stock_sales_price"].ToString());
                    s.stock_last_transfer_date = DateTime.Parse(dr["stock_last_transfer_date"].ToString());
                    s.stock_quantity_on_hand = float.Parse(dr["stock_quantity_on_hand"].ToString());
                    s.stock_max_discount = float.Parse(dr["stock_max_discount"].ToString());
                    s.stock_location_desc = dr["stock_location_desc"].ToString();
                    s.stock_location_section = dr["stock_location_section"].ToString();
                    s.stock_location_shelf = dr["stock_location_shelf"].ToString();
                    s.tax_rate = float.Parse(dr["tax_rate"].ToString());
                    s.tax_rate_id = int.Parse(dr["tax_rate_id"].ToString());
                    s.tax_yesno = int.Parse(dr["tax_yesno"].ToString());
                    s.tax_file_no = dr["tax_file_no"].ToString();
                    s.stock_GST_price = float.Parse(dr["stock_GST_price"].ToString());
                    s.stock_notes = dr["stock_notes"].ToString();
                    s.stock_margin = float.Parse(dr["stock_margin"].ToString());
                    s.stock_UOM = dr["stock_UOM"].ToString();
                    s.stock_flag = dr["stock_flag"].ToString();
                    s.stock_min = int.Parse(dr["stock_min"].ToString());
                    s.idd = int.Parse(dr["idd"].ToString());
                    s.order = int.Parse(dr["order"].ToString());
                    s.id = int.Parse(dr["id"].ToString());
                    if (dr["stock_exp_date"] == DBNull.Value) { s.stock_exp_date = null; }
                    else
                    {
                        s.stock_exp_date = DateTime.Parse(dr["stock_exp_date"].ToString());
                    }
                    s.stock_max = int.Parse(dr["stock_max"].ToString());
                    s.stock_sales_price1 = float.Parse(dr["stock_sales_price1"].ToString());
                    s.stock_GST_price1 = float.Parse(dr["stock_GST_price1"].ToString());
                    xlist.Add(s);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetStockById_int", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        public IEnumerable<Brand> LoadBrand(string id)
        {
            //List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
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
                    _query = "select * from brand order by brand_id ";
                       //,[brand_desc]
                }
                else
                {
                    _query = "select * from brand order by brand_id ";
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


                Brand b;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    b = new Brand();
                     b.brand_id= dr["brand_id"].ToString();
                     b.brand_desc = dr["brand_desc"].ToString();
                    
                    b.id = int.Parse(dr["Id"].ToString());
                    
                    blist.Add(b);

                }

                return blist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetStockById_int", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                blist = null;


            }

            return blist;
        }
      

        #region save stock

        public bool SaveStockById(Stock _stock)
        {

            //List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
           // OleDbCommand _mycommand = new OleDbCommand();
          
           // OleDbDataAdapter _myadapter = new OleDbDataAdapter();
           
            //string _query;
            bool _ret = false;

            try
            {
                if (_stock.idd == 0)
                {


                    StockModel _sm = new StockModel();

                    _sm._mystock = _stock;
                    _ret = _sm.Insert_Stock();
                    if (_ret)
                    {

                        _sm.Insert_Transaction("N", "0", "NoQty" + _stock.stock_quantity_on_hand);
                    }

                    



                }
                else
                {

                    StockModel _sm = new StockModel();
                    _sm._mystock = _stock;
                    _ret = _sm.Update_Stock();

                    
                    


                }  


            }
            catch (SqlException e)
            {
                //   return _result;


                samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}