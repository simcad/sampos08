using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
// data acccess
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Angularjs.UIRouting.WebApp.Models
{
    public class Company
    {
        public String company_id{get; set;}
        public String company_name{get; set;}
        public String company_name1{get; set;}
        public String company_address{get; set;}
        public String company_district{get; set;}
        public String company_city{get; set;}
        public String company_postcode{get; set;}
        public String company_state{get; set;}
        public String company_country{get; set;}
        public String company_phone{get; set;}
        public String company_fax{get; set;}
        public String company_start_operating_month{get; set;}
        public String company_end_operating_month{get; set;}
        public String company_currency_symbol{get; set;}
        public String company_currency_name{get; set;}
        public String company_registration{get; set;}
        public String company_access_code{get; set;}
        public String hd_space{get; set;}
        public String hd_freespace{get; set;}
        public String hd_date{get; set;}
        public String hd_rom{get; set;}
        public String company_password{get; set;}
      //  public Byte[] logo{get; set;}
        public String logo_f{get; set;}
        public String ABN{get; set;}
        public String GST_ID{get; set;}
        public Nullable<System.DateTime> GST_register_date{get; set;}


    }

    #region company model

    public class CompanyModel
    {
        public Company _company { get; set; }
        public List<Company> _Company { get; set; }
        // list combo box 
        // show the supplier details
        public void GetCompany(string id) 
        {

            List<Company> _sList = new List<Company>();


            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {

                if (id == "")
                {
                    _query = "select * from Company  ";
                    //,[brand_desc]
                }
                else
                {
                    _query = "select * from Company where company_id ='" + id + "'";
                        
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


                Company c;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    c = new Company();
                    c.company_id = dr["company_id"].ToString();
                    c.company_name = dr["company_name"].ToString();
                    c.company_name1 = dr["company_name1"].ToString();
                    c.company_address = dr["company_address"].ToString();
                    c.company_district = dr["company_district"].ToString();
                    c.company_city = dr["company_city"].ToString();
                    c.company_postcode = dr["company_postcode"].ToString();
                    c.company_state = dr["company_state"].ToString();
                    c.company_country = dr["company_country"].ToString();
                    c.company_phone = dr["company_phone"].ToString();
                    c.company_fax = dr["company_fax"].ToString();
                    c.company_start_operating_month = dr["company_start_operating_month"].ToString();
                    c.company_end_operating_month = dr["company_end_operating_month"].ToString();
                    c.company_currency_symbol = dr["company_currency_symbol"].ToString();
                    c.company_currency_name = dr["company_currency_name"].ToString();
                    c.company_registration = dr["company_registration"].ToString();
                    c.company_access_code = dr["company_access_code"].ToString();
                    c.hd_space = dr["hd_space"].ToString();
                    
                    if (dr["GST_register_date"] == DBNull.Value) { c.GST_register_date = null; }
                    else
                    {
                        
                        c.GST_register_date = DateTime.Parse(dr["GST_register_date"].ToString());
                    }


                    _sList.Add(c);

                }

                _Company = _sList.ToList();
                // return _Company;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load company", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }



       // #region insert

        //public bool InsertSupplier()
        //{

        //    string strSQL;

        //    try
        //    {
        //        OleDbCommand _mycommand = new OleDbCommand();

        //        OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                
        //        strSQL = "Insert into suppliers";
        //    strSQL = strSQL + "(supplier_id, supplier_name,";
        //    strSQL = strSQL + "supplier_address, supplier_add2,";
        //    strSQL = strSQL + "supplier_add3, supplier_city,";
        //    strSQL = strSQL + "supplier_postcode, supplier_state,";
        //    strSQL = strSQL + "supplier_district, supplier_country,";
        //    strSQL = strSQL + "supplier_phone, supplier_fax,";
        //    strSQL = strSQL + "supplier_contact_mobile, supplier_contact,";
        //    strSQL = strSQL + "supplier_email, taxABN,supplier_note)";
        //    strSQL = strSQL + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //    #region parameter
        //    if (string.IsNullOrEmpty(_supplier.supplier_id))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_id", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_id", _supplier.supplier_id);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_name))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_name", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_name", _supplier.supplier_name);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_address))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_address", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_address", _supplier.supplier_address);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_add2))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_add2", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_add2", _supplier.supplier_add2);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_add3))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_add3", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_add3", _supplier.supplier_add3);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_district))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_district", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_district", _supplier.supplier_district);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_city))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_city", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_city", _supplier.supplier_city);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_postcode))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_postcode", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_postcode", _supplier.supplier_postcode);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_state))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_state", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_state", _supplier.supplier_state);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_country))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_country", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_country", _supplier.supplier_country);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_phone))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_phone", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_phone", _supplier.supplier_phone);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_fax))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_fax", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_fax", _supplier.supplier_fax);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_contact_mobile))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", _supplier.supplier_contact_mobile);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_contact))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_contact", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_contact", _supplier.supplier_contact);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_email))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_email", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_email", _supplier.supplier_email);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.supplier_note))
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_note", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@supplier_note", _supplier.supplier_note);
        //    }
        //    if (string.IsNullOrEmpty(_supplier.taxABN))
        //    {
        //        _mycommand.Parameters.AddWithValue("@taxABN", DBNull.Value);
        //    }
        //    else
        //    {
        //        _mycommand.Parameters.AddWithValue("@taxABN", _supplier.taxABN);
        //    }

        //    #endregion







        //    OleDbConnection _conn = new OleDbConnection();
        //        _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
        //        _mycommand.Connection = _conn;
        //        _mycommand.CommandType = CommandType.Text;
        //        _mycommand.CommandText = strSQL;
        //        _mycommand.ExecuteNonQuery();

        //    }
        //    catch (Exception e)
        //    {

        //        samposoapp.ErrorLog.ErrorLog.ccException("Insert brand", e);
        //        return false;
        //    }
        //    return true;
        //}
       // #endregion end insert

        #region update
        public bool UpdateCompany()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                //string _id = _brand.id;
                string  _id = _company.company_id;
                //strSQL = "Update brand set brand_id=@brand_id,brand_desc=@brand_desc where id=" + _id + "";
                
               
            strSQL = " UPDATE company SET ";

            strSQL = strSQL + "company.company_name=@company_name,";
            strSQL = strSQL + "company.company_name1=@company_name1,";
            strSQL = strSQL + "company.company_address=@company_address,";
            strSQL = strSQL + "company.company_district =@company_district,";
            strSQL = strSQL + "company.company_city =@company_city,";
            

            strSQL = strSQL + "company_postcode =@company_postcode,";
            strSQL = strSQL + "company.company_state =@company_state,";
            strSQL = strSQL + "company.company_country =@company_country,";
          
              
            
            strSQL = strSQL + "company.company_phone =@company_phone,";
            strSQL = strSQL + "company.company_fax =@company_fax,";
            strSQL = strSQL + "company.company_start_operating_month =@company_start_operating_month,";
            strSQL = strSQL + "company.company_end_operating_month =@company_end_operating_month,";
            strSQL = strSQL + "company.company_currency_symbol =@company_currency_symbol,";
            strSQL = strSQL + "company.company_currency_name =@company_currency_name,";
               
            strSQL = strSQL + "company.company_registration =@company_registration,";
            strSQL = strSQL + "company.company_access_code =@company_access_code,";
            strSQL = strSQL + "company.company_password =@company_password,";
            strSQL = strSQL + "company.logo_f=@logo_f,";
            strSQL = strSQL + "company.GST_ID =@GST_ID,";
            
           strSQL = strSQL + "company.GST_register_date =@GST_register_date ";
            

           
           
               
            strSQL = strSQL + " where company_id='" + _id + "'";



            #region parameter
            #region id
            //if (string.IsNullOrEmpty(_company.company_id))
            //{
            //    _mycommand.Parameters.AddWithValue("@company_id", DBNull.Value);
            //}
            //else
            //{
            //    _mycommand.Parameters.AddWithValue("@company_id", _company.company_id);
            //}

            #endregion id

            if (string.IsNullOrEmpty(_company.company_name))
            {
                _mycommand.Parameters.AddWithValue("@company_name", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_name", _company.company_name);
            }

            if (string.IsNullOrEmpty(_company.company_name1))
            {
                _mycommand.Parameters.AddWithValue("@company_name1", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_name1", _company.company_name1);
            }
            if (string.IsNullOrEmpty(_company.company_address))
            {
                _mycommand.Parameters.AddWithValue("@company_address", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_address", _company.company_address);
            }




            if (string.IsNullOrEmpty(_company.company_district))
            {
                _mycommand.Parameters.AddWithValue("@company_district", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_district", _company.company_district);
            }

            if (string.IsNullOrEmpty(_company.company_city))
            {
                _mycommand.Parameters.AddWithValue("@company_city", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_city", _company.company_city);
            }


            if (string.IsNullOrEmpty(_company.company_postcode))
            {
                _mycommand.Parameters.AddWithValue("@company_postcode", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@company_postcode", _company.company_postcode);
            }

           
        if (string.IsNullOrEmpty(_company.company_state))
        {
            _mycommand.Parameters.AddWithValue("@company_state", DBNull.Value);
        }
        else
        {
            _mycommand.Parameters.AddWithValue("@company_state", _company.company_state);
        }


        if (string.IsNullOrEmpty(_company.company_country))
        {
            _mycommand.Parameters.AddWithValue("@company_country", DBNull.Value);
        }
        else
        {
            _mycommand.Parameters.AddWithValue("@company_country", _company.company_country);
        }

        
if (string.IsNullOrEmpty(_company.company_phone))
{
   _mycommand.Parameters.AddWithValue("@company_phone", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_phone", _company.company_phone);
}

if (string.IsNullOrEmpty(_company.company_fax))
{
   _mycommand.Parameters.AddWithValue("@company_fax", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_fax", _company.company_fax);
}

if (string.IsNullOrEmpty(_company.company_start_operating_month))
{
   _mycommand.Parameters.AddWithValue("@company_start_operating_month", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_start_operating_month", _company.company_start_operating_month);
}
if (string.IsNullOrEmpty(_company.company_end_operating_month))
{
   _mycommand.Parameters.AddWithValue("@company_end_operating_month", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_end_operating_month", _company.company_end_operating_month);
}

if (string.IsNullOrEmpty(_company.company_currency_symbol))
{
   _mycommand.Parameters.AddWithValue("@company_currency_symbol", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_currency_symbol", _company.company_currency_symbol);
}

if (string.IsNullOrEmpty(_company.company_currency_name))
{
   _mycommand.Parameters.AddWithValue("@company_currency_name", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_currency_name", _company.company_currency_name);
}
                
if (string.IsNullOrEmpty(_company.company_registration))
{
   _mycommand.Parameters.AddWithValue("@company_registration", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_registration", _company.company_registration);
}

if (string.IsNullOrEmpty(_company.company_access_code))
{
   _mycommand.Parameters.AddWithValue("@company_access_code", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_access_code", _company.company_access_code);
}
#region skip
//if (string.IsNullOrEmpty(_company.hd_space))
//{
//    _mycommand.Parameters.AddWithValue("@hd_space", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@hd_space", _company.hd_space);
//}
//if (string.IsNullOrEmpty(_company.hd_freespace))
//{
//    _mycommand.Parameters.AddWithValue("@hd_freespace", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@hd_freespace", _company.hd_freespace);
//}
//if (string.IsNullOrEmpty(_company.hd_date))
//{
//    _mycommand.Parameters.AddWithValue("@hd_date", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@hd_date", _company.hd_date);
//}
//if (string.IsNullOrEmpty(_company.hd_rom))
//{
//    _mycommand.Parameters.AddWithValue("@hd_rom", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@hd_rom", _company.hd_rom);
//}
//if (_company.logo ==null)
//{
//    _mycommand.Parameters.AddWithValue("@logo", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@logo", _company.logo);
//}
        
#endregion skip


if (string.IsNullOrEmpty(_company.company_password))
{
   _mycommand.Parameters.AddWithValue("@company_password", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@company_password", _company.company_password);
}

if (string.IsNullOrEmpty(_company.logo_f))
{
   _mycommand.Parameters.AddWithValue("@logo_f", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@logo_f", _company.logo_f);
}

//if (string.IsNullOrEmpty(_company.ABN))
//{
//    _mycommand.Parameters.AddWithValue("@ABN", DBNull.Value);
//}
//else
//{
//    _mycommand.Parameters.AddWithValue("@ABN", _company.ABN);
//}
if (string.IsNullOrEmpty(_company.GST_ID))
{
   _mycommand.Parameters.AddWithValue("@GST_ID", DBNull.Value);
}
else
{
   _mycommand.Parameters.AddWithValue("@GST_ID", _company.GST_ID);
}


        if (_company.GST_register_date==null)
        {
            _mycommand.Parameters.AddWithValue("@GST_register_date", DBNull.Value);
        }
        else
        {
                string _tmp;
                _tmp = _company.GST_register_date.Value.ToString("MMddyyyy");// _mystock.stock_last_transfer_date.Value.ToString("mmddyyyy");

                
                DateTime _tmpdate = DateTime.ParseExact(_tmp, "MMddyyyy", null);

                

                _mycommand.Parameters.AddWithValue("@GST_register_date", _tmpdate);
        }


            #endregion






OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update brand", e);
                return false;
            }
            return true;

        }
        #endregion end update


        #region delete
        //public bool deleteSupplier(int id)
        //{


        //    string strSQL;

        //    try
        //    {
        //        OleDbCommand _mycommand = new OleDbCommand();

        //        OleDbDataAdapter _myadapter = new OleDbDataAdapter();
        //        strSQL = "delete from suppliers where sid=" + id + "";



        //        OleDbConnection _conn = new OleDbConnection();
        //        _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
        //        _mycommand.Connection = _conn;
        //        _mycommand.CommandType = CommandType.Text;
        //        _mycommand.CommandText = strSQL;
        //        _mycommand.ExecuteNonQuery();

        //    }
        //    catch (Exception e)
        //    {

        //        samposoapp.ErrorLog.ErrorLog.ccException("Delete brand", e);
        //        return false;
        //    }
        //    return true;


        //}

        #endregion end delete


    }

    #endregion
}