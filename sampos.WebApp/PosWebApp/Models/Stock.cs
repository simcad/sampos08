using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;


namespace Angularjs.UIRouting.WebApp.Models
{


    public class StockModel
    {

        public List<Stock> _Stock { get; set; }
        public List<Brand> _Brand { get; set; }
        public List<Supplier> _Supplier { get; set; }
        public List<Group> _Group { get; set; }
        public List<clsGST> _GST { get; set; }
        public List<clsBase> _Base { get; set; }
        List<Stock> xlist = new List<Stock>();  // treat this as list
        public Stock _mystock { get; set; }
        public Transaction _objtx { get; set; }

        public void GetBrand(int _id) 
        {
            try 
            {

                BrandModel _bm = new BrandModel();
                _bm.GetBrand(0);
                _Brand= _bm._Brand;

            }


            catch (Exception e) 
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetBrand", e);
            }
        }

        public void GetGroup(string _id)
        {
            try
            {

                GroupModel  _gm = new GroupModel();
                _gm.GetGroup("");
                _Group = _gm._Group;

            }


            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("GetBrand", e);
            }
        }

        

        
        public void GetStock(int _id, string _barcode)
        {
            //List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();

            BrandModel _bm = new BrandModel();
            _bm.GetBrand(0);
            _Brand = _bm._Brand;

             GroupModel  _gm = new GroupModel();
             _gm.GetGroup("");
             _Group = _gm._Group;

             SupplierModel _sm = new SupplierModel();
             _sm.GetSupplier(0); // id = get the whole list
             _Supplier = _sm._Supplier;

             GSTModel _gstm = new GSTModel();
             _gstm.GetGST("");
             _GST = _gstm._GST;

            //OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            //OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            Stock s;
            s = new Stock();

            try
            {

                if (_id == 0)
                {
                    _query = "select * from stock where barocode='" + _barcode + "'";//; where id < 50";
                }
                else
                {
                    _query = "select * from stock where idd =" + _id;
                }
                _mydatatable=samposoapp.db.SqlDatabaseUtility.ExecuteQueryString(_query);

              

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
                    //_Stock.Add(s);

                }

                _Stock = xlist.ToList();
            }
            // return xlist;
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("GetCustomerById_int", e);
            }

        }


        #region insert
        // =====================
        public bool Insert_Stock()
        {
            bool _return;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string strSQL;

            strSQL = " INSERT INTO stock (barcode,company_id,brand_id,stock_model,stock_size,stock_colour,stock_desc,group_id,supplier_id,stock_cost_code,stock_average_price,stock_cost_price,stock_sales_price,stock_last_transfer_date,stock_quantity_on_hand,stock_max_discount,stock_location_desc,stock_location_section,stock_location_shelf,tax_rate,tax_rate_id,tax_yesno,tax_file_no,stock_GST_price,stock_notes,stock_margin,stock_UOM,stock_flag,stock_min,[order],id,stock_exp_date,stock_max,stock_sales_price1,stock_GST_price1)";
            //strSQL = strSQL + "Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            strSQL = strSQL + " Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
 
            

        if (string.IsNullOrEmpty(_mystock.barcode))
        {
            _mycommand.Parameters.AddWithValue("@barcode", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@barcode", _mystock.barcode); }

        if (string.IsNullOrEmpty(_mystock.company_id))
        {
            _mycommand.Parameters.AddWithValue("@company_id", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@company_id", _mystock.company_id); }

        if (string.IsNullOrEmpty(_mystock.brand_id))
        {
            _mycommand.Parameters.AddWithValue("@brand_id", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@brand_id", _mystock.brand_id); }

        if (string.IsNullOrEmpty(_mystock.stock_model))
        {
            _mycommand.Parameters.AddWithValue("@stock_model", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_model", _mystock.stock_model); }

        if (string.IsNullOrEmpty(_mystock.stock_size))
        {
            _mycommand.Parameters.AddWithValue("@stock_size", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_size", _mystock.stock_size); }

        if (string.IsNullOrEmpty(_mystock.stock_colour))
        {
            _mycommand.Parameters.AddWithValue("@stock_colour", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_colour", _mystock.stock_colour); }

        if (string.IsNullOrEmpty(_mystock.stock_desc))
        {
            _mycommand.Parameters.AddWithValue("@stock_desc", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_desc", _mystock.stock_desc); }

        

        if (string.IsNullOrEmpty(_mystock.group_id))
        {
            _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@group_id", _mystock.group_id); }

        if (string.IsNullOrEmpty(_mystock.supplier_id))
        {
            _mycommand.Parameters.AddWithValue("@supplier_id", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@supplier_id", _mystock.supplier_id); }

        if (string.IsNullOrEmpty(_mystock.stock_cost_code))
        {
            _mycommand.Parameters.AddWithValue("@stock_cost_code", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_cost_code", _mystock.stock_cost_code); }

            
        //if (_mystock.stock_average_price == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_average_price", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_average_price", _mystock.stock_average_price); }

        _mycommand.Parameters.AddWithValue("@stock_average_price", _mystock.stock_average_price);
        _mycommand.Parameters.AddWithValue("@stock_cost_price", _mystock.stock_cost_price);

        _mycommand.Parameters.AddWithValue("@stock_sales_price", _mystock.stock_sales_price);

        //if (_mystock.stock_cost_price == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_cost_price", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_cost_price", _mystock.stock_cost_price); }


            
        //if (_mystock.stock_sales_price == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_sales_price", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_sales_price", _mystock.stock_sales_price); }

        if (_mystock.stock_last_transfer_date == null)
        {
            _mycommand.Parameters.AddWithValue("@stock_last_transfer_date", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_last_transfer_date", _mystock.stock_last_transfer_date); }



        //if (_mystock.stock_quantity_on_hand == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", _mystock.stock_quantity_on_hand); }

        _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", _mystock.stock_quantity_on_hand);
        _mycommand.Parameters.AddWithValue("@stock_max_discount", _mystock.stock_max_discount);


        //if (_mystock.stock_max_discount == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_max_discount", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_max_discount", _mystock.stock_max_discount); }

        if (string.IsNullOrEmpty(_mystock.stock_location_desc))
        {
            _mycommand.Parameters.AddWithValue("@stock_location_desc", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_location_desc", _mystock.stock_location_desc); }

        if (string.IsNullOrEmpty(_mystock.stock_location_section))
        {
            _mycommand.Parameters.AddWithValue("@stock_location_section", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_location_section", _mystock.stock_location_section); }

        if (string.IsNullOrEmpty(_mystock.stock_location_shelf))
        {
            _mycommand.Parameters.AddWithValue("@stock_location_shelf", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_location_shelf", _mystock.stock_location_shelf); }


             _mycommand.Parameters.AddWithValue("@tax_rate", _mystock.tax_rate); 
            _mycommand.Parameters.AddWithValue("@tax_rate_id", _mystock.tax_rate_id); 

        //if (_mystock.tax_rate== null)
        //{
        //    _mycommand.Parameters.AddWithValue("@tax_rate", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@tax_rate", _mystock.tax_rate); }

        //if (_mystock.tax_rate_id == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@tax_rate_id", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@tax_rate_id", _mystock.tax_rate_id); }

        //if (_mystock.tax_yesno == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@tax_yesno", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@tax_yesno", _mystock.tax_yesno); }

        _mycommand.Parameters.AddWithValue("@tax_yesno", _mystock.tax_yesno);

        if (string.IsNullOrEmpty(_mystock.tax_file_no))
        {
            _mycommand.Parameters.AddWithValue("@tax_file_no", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@tax_file_no", _mystock.tax_file_no); }

        //if (_mystock.stock_GST_price == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_GST_price", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_GST_price", _mystock.stock_GST_price); }



             _mycommand.Parameters.AddWithValue("@stock_GST_price", _mystock.stock_GST_price); 
            

        if (string.IsNullOrEmpty(_mystock.stock_notes))
        {
            _mycommand.Parameters.AddWithValue("@stock_notes", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_notes", _mystock.stock_notes); }
         
        //if (_mystock.stock_margin == null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_margin", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_margin", _mystock.stock_margin); }

             _mycommand.Parameters.AddWithValue("@stock_margin", _mystock.stock_margin); 

        if (string.IsNullOrEmpty(_mystock.stock_UOM))
        {
            _mycommand.Parameters.AddWithValue("@stock_UOM", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_UOM", _mystock.stock_UOM); }

        if (string.IsNullOrEmpty(_mystock.stock_flag))
        {
            _mycommand.Parameters.AddWithValue("@stock_flag", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_flag", _mystock.stock_flag); }

        //if (_mystock.stock_min==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_min", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_min", _mystock.stock_min); }

        _mycommand.Parameters.AddWithValue("@stock_min", _mystock.stock_min); 

        //if (_mystock.idd==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@idd", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@idd", _mystock.idd); }

        //if (_mystock.order ==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@order", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@order", _mystock.order); }

             _mycommand.Parameters.AddWithValue("@order", _mystock.order); 

        //if (_mystock.id==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@id", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@id", _mystock.id); }

        _mycommand.Parameters.AddWithValue("@id", _mystock.id);

        if (_mystock.stock_exp_date==null)
        {
            _mycommand.Parameters.AddWithValue("@stock_exp_date", DBNull.Value);
        }
        else { _mycommand.Parameters.AddWithValue("@stock_exp_date", _mystock.stock_exp_date); }

        //if (_mystock.stock_max==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_max", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_max", _mystock.stock_max); }

        _mycommand.Parameters.AddWithValue("@stock_max", _mystock.stock_max);
        _mycommand.Parameters.AddWithValue("@stock_sales_price1", _mystock.stock_sales_price1);
        _mycommand.Parameters.AddWithValue("@stock_GST_price1", _mystock.stock_GST_price1); 

        //if (_mystock.stock_sales_price1==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_sales_price1", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_sales_price1", _mystock.stock_sales_price1); }

        //if (_mystock.stock_GST_price1 ==null)
        //{
        //    _mycommand.Parameters.AddWithValue("@stock_GST_price1", DBNull.Value);
        //}
        //else { _mycommand.Parameters.AddWithValue("@stock_GST_price1", _mystock.stock_GST_price1); }

       


            //DataSet _ds = new DataSet();

            try
            {
                // sql statment here
               


                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();


                _return = true;

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("Insert Stock", e);
                _return = false;

            }
            return _return;
        }


        //====================
        #endregion insert

        #region update
        public bool Update_Stock()
        {
            bool _return;

            OleDbCommand _mycommand = new OleDbCommand();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string strSQL;
            int? _stockId;
            _stockId = _mystock.idd;
            strSQL = "Update stock set ";
            strSQL = strSQL + " barcode=@barcode, company_id=@company_id, brand_id=@brand_id, stock_model=@stock_model,stock_size=@stock_size,";
            strSQL = strSQL + "stock_colour=@stock_colour,stock_desc=@stock_desc,group_id=@group_id,supplier_id=@supplier_id,stock_cost_code=@stock_cost_code,";
            strSQL = strSQL + "stock_average_price=@stock_average_price,stock_cost_price=@stock_cost_price,stock_sales_price=@stock_sales_price,";
            strSQL = strSQL + "stock_last_transfer_date=@stock_last_transfer_date,";
            strSQL = strSQL + "stock_quantity_on_hand=@stock_quantity_on_hand,";
            strSQL = strSQL + "stock_max_discount=@stock_max_discount,";//stock_location_desc=@stock_location_desc,";
           // strSQL = strSQL + "stock_location_section=@stock_location_section,stock_location_shelf=@stock_location_shelf,";
            strSQL = strSQL + "tax_rate=@tax_rate,tax_rate_id=@tax_rate_id,tax_yesno=@tax_yesno,";
            strSQL = strSQL + "tax_file_no=@tax_file_no,stock_GST_price=@stock_GST_price,stock_notes=@stock_notes,";
            strSQL = strSQL + "stock_margin=@stock_margin,stock_UOM=@stock_UOM,";
            //stock_flag=@stock_flag,
            strSQL = strSQL + "stock_min=@stock_min,";
            strSQL = strSQL + "[order]=@order,stock_exp_date=@stock_exp_date,stock_max=@stock_max,stock_sales_price1=@stock_sales_price1,";
            strSQL = strSQL + "stock_GST_price1=@stock_GST_price1";
            strSQL = strSQL + " where idd =" + _stockId;  
            if (string.IsNullOrEmpty(_mystock.barcode))
            {
                _mycommand.Parameters.AddWithValue("@barcode", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@barcode", _mystock.barcode); }

            if (string.IsNullOrEmpty(_mystock.company_id))
            {
                _mycommand.Parameters.AddWithValue("@company_id", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@company_id", _mystock.company_id); }

            if (string.IsNullOrEmpty(_mystock.brand_id))
            {
                _mycommand.Parameters.AddWithValue("@brand_id", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@brand_id", _mystock.brand_id); }

            if (string.IsNullOrEmpty(_mystock.stock_model))
            {
                _mycommand.Parameters.AddWithValue("@stock_model", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_model", _mystock.stock_model); }

            if (string.IsNullOrEmpty(_mystock.stock_size))
            {
                _mycommand.Parameters.AddWithValue("@stock_size", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_size", _mystock.stock_size); }

            if (string.IsNullOrEmpty(_mystock.stock_colour))
            {
                _mycommand.Parameters.AddWithValue("@stock_colour", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_colour", _mystock.stock_colour); }

            if (string.IsNullOrEmpty(_mystock.stock_desc))
            {
                _mycommand.Parameters.AddWithValue("@stock_desc", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_desc", _mystock.stock_desc); }



            if (string.IsNullOrEmpty(_mystock.group_id))
            {
                _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@group_id", _mystock.group_id); }

            if (string.IsNullOrEmpty(_mystock.supplier_id))
            {
                _mycommand.Parameters.AddWithValue("@supplier_id", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@supplier_id", _mystock.supplier_id); }

            if (string.IsNullOrEmpty(_mystock.stock_cost_code))
            {
                _mycommand.Parameters.AddWithValue("@stock_cost_code", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_cost_code", _mystock.stock_cost_code); }


            _mycommand.Parameters.AddWithValue("@stock_average_price", _mystock.stock_average_price);
            _mycommand.Parameters.AddWithValue("@stock_cost_price", _mystock.stock_cost_price);
            _mycommand.Parameters.AddWithValue("@stock_sales_price", _mystock.stock_sales_price);

            //if (_mystock.stock_average_price == 0.0)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_average_price", 0);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_average_price", _mystock.stock_average_price); }

            //if (_mystock.stock_cost_price == 0)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_cost_price", 0);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_cost_price", _mystock.stock_cost_price); }



            //if (_mystock.stock_sales_price == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_sales_price", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_sales_price", _mystock.stock_sales_price); }


            
            if (_mystock.stock_last_transfer_date == null)
            {
                _mycommand.Parameters.AddWithValue("@stock_last_transfer_date", DBNull.Value);
            }
            else
            {
                string _tmp;
                _tmp = _mystock.stock_last_transfer_date.Value.ToString("MMddyyyy");// _mystock.stock_last_transfer_date.Value.ToString("mmddyyyy");

                //datetime _tmpdate = convert.todatetime(_tmp);
                DateTime _tmpdate = DateTime.ParseExact(_tmp, "MMddyyyy", null);

                _mycommand.Parameters.AddWithValue("@stock_last_transfer_date", _tmpdate);

            }

            //numberic
            _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", _mystock.stock_quantity_on_hand);
            _mycommand.Parameters.AddWithValue("@stock_max_discount", _mystock.stock_max_discount);



            //if (_mystock.stock_quantity_on_hand == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_quantity_on_hand", _mystock.stock_quantity_on_hand); }




            //if (_mystock.stock_max_discount == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_max_discount", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_max_discount", _mystock.stock_max_discount); }

            //if (string.IsNullOrEmpty(_mystock.stock_location_desc))
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_location_desc", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_location_desc", _mystock.stock_location_desc); }

            //if (string.IsNullOrEmpty(_mystock.stock_location_section))
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_location_section", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_location_section", _mystock.stock_location_section); }

            //if (string.IsNullOrEmpty(_mystock.stock_location_shelf))
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_location_shelf", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_location_shelf", _mystock.stock_location_shelf); }




            //if (_mystock.tax_rate == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@tax_rate", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@tax_rate", _mystock.tax_rate); }


            _mycommand.Parameters.AddWithValue("@tax_rate", _mystock.tax_rate);
            //if (_mystock.tax_rate_id == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@tax_rate_id", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@tax_rate_id", _mystock.tax_rate_id); }

            _mycommand.Parameters.AddWithValue("@tax_rate_id", _mystock.tax_rate_id);

            //if (_mystock.tax_yesno == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@tax_yesno", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@tax_yesno", _mystock.tax_yesno); }


            _mycommand.Parameters.AddWithValue("@tax_yesno", _mystock.tax_yesno);

            if (string.IsNullOrEmpty(_mystock.tax_file_no))
            {
                _mycommand.Parameters.AddWithValue("@tax_file_no", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@tax_file_no", _mystock.tax_file_no); }

            //if (_mystock.stock_GST_price == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_GST_price", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_GST_price", _mystock.stock_GST_price); }

            _mycommand.Parameters.AddWithValue("@stock_GST_price", _mystock.stock_GST_price); 

            if (string.IsNullOrEmpty(_mystock.stock_notes))
            {
                _mycommand.Parameters.AddWithValue("@stock_notes", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_notes", _mystock.stock_notes); }

            //if (_mystock.stock_margin == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_margin", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_margin", _mystock.stock_margin); }

            _mycommand.Parameters.AddWithValue("@stock_margin", _mystock.stock_margin); 

            if (string.IsNullOrEmpty(_mystock.stock_UOM))
            {
                _mycommand.Parameters.AddWithValue("@stock_UOM", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_UOM", _mystock.stock_UOM); }

            //if (string.IsNullOrEmpty(_mystock.stock_flag))
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_flag", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_flag", _mystock.stock_flag); }

            //if (_mystock.stock_min == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_min", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_min", _mystock.stock_min); }

            _mycommand.Parameters.AddWithValue("@stock_min", _mystock.stock_min);

            //if (_mystock.idd==null)
            //{
            //    _mycommand.Parameters.AddWithValue("@idd", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@idd", _mystock.idd); }

            //if (_mystock.order == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@order", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@order", _mystock.order); }

            _mycommand.Parameters.AddWithValue("@order", _mystock.order);

            //if (_mystock.id == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@id", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@id", _mystock.id); }

            if (_mystock.stock_exp_date == null)
            {
                _mycommand.Parameters.AddWithValue("@stock_exp_date", DBNull.Value);
            }
            else { _mycommand.Parameters.AddWithValue("@stock_exp_date", _mystock.stock_exp_date); }

            //if (_mystock.stock_max == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_max", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_max", _mystock.stock_max); }



            //if (_mystock.stock_sales_price1 == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_sales_price1", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_sales_price1", _mystock.stock_sales_price1); }

            //if (_mystock.stock_GST_price1 == null)
            //{
            //    _mycommand.Parameters.AddWithValue("@stock_GST_price1", DBNull.Value);
            //}
            //else { _mycommand.Parameters.AddWithValue("@stock_GST_price1", _mystock.stock_GST_price1); }

            _mycommand.Parameters.AddWithValue("@stock_max", _mystock.stock_max); 
            _mycommand.Parameters.AddWithValue("@stock_sales_price1", _mystock.stock_sales_price1);
            _mycommand.Parameters.AddWithValue("@stock_GST_price1", _mystock.stock_GST_price1);
            


            //DataSet _ds = new DataSet();

            try
            {
                // sql statment here



                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();


                _return = true;

            }
            catch (Exception e)
            {
                samposoapp.ErrorLog.ErrorLog.ccException("Insert Stock", e);
                _return = false;

            }
            return _return;
        }

        #endregion



        #region Transaction
        //public bool Insert_Transaction(string _type (N,S,R,0 string _transactionid (S1,string _coderef (or/qtyno:)
        public bool Insert_Transaction(string _type, string _transactionid,string _coderef)
        {
        
            //TransactionModel _tx._transaction = new TransactionModel();
            TransactionModel _tx = new TransactionModel();

            _objtx = new Transaction();
            _tx._transaction = _objtx;

            try {

                BaseModel _bm = new BaseModel();
                 _bm.GetBASE();
                string _guser = _bm._BASE[0].globalUser;
                string _companyid = _bm._BASE[0].Company_Id;
                DateTime _today = DateTime.Now;
               
               

                _tx._transaction.barcode = _mystock.barcode;
                _tx._transaction.stock_code = _mystock.stock_desc; //' .stock_description
                _tx._transaction.transaction_type = _type;// "N";
                _tx._transaction.company_id = _companyid;  //me.MyClassIssue. Me.Company_idTextBox.Text
                //'_tx._transaction.transaction_period = Format(Now, "yyyymm")
                _tx._transaction.transaction_id = _transactionid;//_mystock.idd.ToString();// '.Stock_receive_id ' _mystockIssueDetails.stock_issue_id 'Me.MyClassIssue.stock_issue_id  ' Me.Stock_adjustment_idTextBox.Text
                _tx._transaction.transaction_date = _mystock.stock_last_transfer_date;// Now ' "" & Format(Now, "dd/mm/yyyy") & ""
                _tx._transaction.transaction_quantity = _mystock.stock_quantity_on_hand; //' .stock_receive_quantity
                _tx._transaction.transaction_code_ref = _coderef;// "NoQty" + _mystock.stock_quantity_on_hand;// ' _mystock.In.stock_receive_sequen_no '  Me.Stock_adjustment_remarkTextBox.Text"
                _tx._transaction.transaction_amount = _mystock.stock_quantity_on_hand * _mystock.stock_cost_price;
                _tx._transaction.transaction_average_cost = _mystock.stock_cost_price;
                _tx._transaction.transaction_update_date =  _today.ToString("ddMMyyyy");
                _tx._transaction.supplier_id = _mystock.supplier_id;
                _tx._transaction.global_user_id = _companyid; //_guser;
                _tx._transaction.transaction_period = _today.ToString("yyyyMM");
                _tx._transaction.transaction_ref_no = 0;//' _mystockIn.Stock_receive_reference
                
                _tx.InsertTX_Stock();
                return true;
               // txdb.InsertTX_Stock(_tx._transaction);
            }
            catch(Exception e)
            {
                 samposoapp.ErrorLog.ErrorLog.ccException("Insert Transaction", e);
                return false;
            }
        
        }


        #endregion transaction




    } //model



    public class Stock
    {
        
        public string barcode { get; set; }
        public string company_id { get; set; }
        public string brand_id { get; set; }
        public string stock_model { get; set; }
        public string stock_size { get; set; }
        public string stock_colour { get; set; }
        public string stock_desc { get; set; }
        public string group_id { get; set; }
        public string supplier_id { get; set; }
        public string stock_cost_code { get; set; }
        public float stock_average_price { get; set; }
        public float stock_cost_price { get; set; }
        public float stock_sales_price { get; set; }
        public Nullable<System.DateTime> stock_last_transfer_date { get; set; }
        public float stock_quantity_on_hand { get; set; }
        public float stock_max_discount { get; set; }
        public string stock_location_desc { get; set; }
        public string stock_location_section { get; set; }
        public string stock_location_shelf { get; set; }
        public float tax_rate { get; set; }
        public int tax_rate_id { get; set; }
        public int tax_yesno { get; set; }
        public string tax_file_no { get; set; }
        public float stock_GST_price { get; set; }
        public string stock_notes { get; set; }
        public float stock_margin { get; set; }
        public string stock_UOM { get; set; }
        public string stock_flag { get; set; }
        public int stock_min { get; set; }
        public int idd { get; set; }
        public int order { get; set; }
        public int id { get; set; }
        public Nullable<System.DateTime> stock_exp_date { get; set; }
        public int stock_max { get; set; }
        public float stock_sales_price1 { get; set; }
        public float stock_GST_price1 { get; set; }

        public List<Brand> _Brand { get; set; }
        public List<Supplier> _Supplier { get; set; }
        public List<Group> _Group { get; set; }
        public List<clsGST> _GST { get; set; }
        
        //public Stock()
        //{
            
        //    BrandModel _bm = new BrandModel();
        //    _bm.GetBrand("");
        //    _Brand = _bm._Brand;

        //    GroupModel _gm = new GroupModel();
        //    _gm.GetGroup("");
        //    _Group = _gm._Group;

        //    SupplierModel _sm = new SupplierModel();
        //    _sm.GetSupplier("");
        //    _Supplier = _sm._Supplier;

        //    GSTModel _gstm = new GSTModel();
        //    _gstm.GetGST("");
        //    _GST = _gstm._GST;

    
        //}
    }
}