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
    public class Supplier
    {
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_address { get; set; }
        public string supplier_add2 { get; set; }
        public string supplier_add3 { get; set; }
        public string supplier_district { get; set; }
        public string supplier_city { get; set; }
        public string supplier_postcode { get; set; }
        public string supplier_state { get; set; }
        public string supplier_country { get; set; }
        public string supplier_phone { get; set; }
        public string supplier_fax { get; set; }
        public string supplier_contact_mobile { get; set; }
        public string supplier_contact { get; set; }
        public string supplier_email { get; set; }
        public string supplier_note { get; set; }
        public string taxABN { get; set; }
        public int sid { get; set; }

    }

    #region supplier model

    public class SupplierModel
    {
        public Supplier _supplier { get; set; }
        public List<Supplier> _Supplier { get; set; }
        // list combo box 
        // show the supplier details
        public void GetSupplier(int id) 
        {

            List<Supplier> _sList = new List<Supplier>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();



            try
            {

                if (id == 0)
                {
                    _query = "select * from suppliers order by supplier_name ";
                    //,[brand_desc]
                }
                else
                {
                    _query = "select * from suppliers where sid =" + id ;
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


                Supplier b;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    b = new Supplier();
                    b.supplier_id = dr["supplier_id"].ToString();
                    b.supplier_name = dr["supplier_name"].ToString();
                    b.supplier_address = dr["supplier_address"].ToString();
                    b.supplier_add2 = dr["supplier_add2"].ToString();
                    b.supplier_add3 = dr["supplier_add3"].ToString();
                    b.supplier_district = dr["supplier_district"].ToString();
                    b.supplier_city = dr["supplier_city"].ToString();
                    b.supplier_postcode = dr["supplier_postcode"].ToString();
                    b.supplier_state = dr["supplier_state"].ToString();
                    b.supplier_country = dr["supplier_country"].ToString();
                    b.supplier_phone = dr["supplier_phone"].ToString();
                    b.supplier_fax = dr["supplier_fax"].ToString();
                    b.supplier_contact_mobile = dr["supplier_contact_mobile"].ToString();
                    b.supplier_contact = dr["supplier_contact"].ToString();
                    b.supplier_email = dr["supplier_email"].ToString();
                    b.supplier_note = dr["supplier_note"].ToString();
                    b.taxABN = dr["taxABN"].ToString();
                    b.sid = int.Parse(dr["sid"].ToString());




                    _sList.Add(b);

                }

                _Supplier = _sList.ToList();
                // return _Brand;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load Supplier", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }



        #region insert

        public bool InsertSupplier()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                
                strSQL = "Insert into suppliers";
            strSQL = strSQL + "(supplier_id, supplier_name,";
            strSQL = strSQL + "supplier_address, supplier_add2,";
            strSQL = strSQL + "supplier_add3, supplier_city,";
            strSQL = strSQL + "supplier_postcode, supplier_state,";
            strSQL = strSQL + "supplier_district, supplier_country,";
            strSQL = strSQL + "supplier_phone, supplier_fax,";
            strSQL = strSQL + "supplier_contact_mobile, supplier_contact,";
            strSQL = strSQL + "supplier_email, taxABN,supplier_note)";
            strSQL = strSQL + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            #region parameter
            if (string.IsNullOrEmpty(_supplier.supplier_id))
            {
                _mycommand.Parameters.AddWithValue("@supplier_id", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_id", _supplier.supplier_id);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_name))
            {
                _mycommand.Parameters.AddWithValue("@supplier_name", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_name", _supplier.supplier_name);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_address))
            {
                _mycommand.Parameters.AddWithValue("@supplier_address", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_address", _supplier.supplier_address);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_add2))
            {
                _mycommand.Parameters.AddWithValue("@supplier_add2", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_add2", _supplier.supplier_add2);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_add3))
            {
                _mycommand.Parameters.AddWithValue("@supplier_add3", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_add3", _supplier.supplier_add3);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_district))
            {
                _mycommand.Parameters.AddWithValue("@supplier_district", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_district", _supplier.supplier_district);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_city))
            {
                _mycommand.Parameters.AddWithValue("@supplier_city", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_city", _supplier.supplier_city);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_postcode))
            {
                _mycommand.Parameters.AddWithValue("@supplier_postcode", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_postcode", _supplier.supplier_postcode);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_state))
            {
                _mycommand.Parameters.AddWithValue("@supplier_state", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_state", _supplier.supplier_state);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_country))
            {
                _mycommand.Parameters.AddWithValue("@supplier_country", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_country", _supplier.supplier_country);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_phone))
            {
                _mycommand.Parameters.AddWithValue("@supplier_phone", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_phone", _supplier.supplier_phone);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_fax))
            {
                _mycommand.Parameters.AddWithValue("@supplier_fax", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_fax", _supplier.supplier_fax);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_contact_mobile))
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", _supplier.supplier_contact_mobile);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_contact))
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact", _supplier.supplier_contact);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_email))
            {
                _mycommand.Parameters.AddWithValue("@supplier_email", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_email", _supplier.supplier_email);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_note))
            {
                _mycommand.Parameters.AddWithValue("@supplier_note", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_note", _supplier.supplier_note);
            }
            if (string.IsNullOrEmpty(_supplier.taxABN))
            {
                _mycommand.Parameters.AddWithValue("@taxABN", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@taxABN", _supplier.taxABN);
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

                samposoapp.ErrorLog.ErrorLog.ccException("Insert brand", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateSupplier()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                //string _id = _brand.id;
                int _id = _supplier.sid;
                //strSQL = "Update brand set brand_id=@brand_id,brand_desc=@brand_desc where id=" + _id + "";
                
                 strSQL = "Update suppliers set";
            strSQL = strSQL + " Supplier_ID = @supplier_id, ";
            strSQL = strSQL + " Supplier_name=@supplier_name, ";
            strSQL = strSQL + " Supplier_address = @supplier_address,";
            strSQL = strSQL + " Supplier_add2 =@supplier_add2,";
            strSQL = strSQL + " Supplier_add3 =@supplier_add3,";
            strSQL = strSQL + " Supplier_city =@supplier_city,";
            strSQL = strSQL + " Supplier_postcode = @supplier_postcode,";
            strSQL = strSQL + " Supplier_state =@supplier_state,";
            strSQL = strSQL + " Supplier_district = @supplier_district,";
            strSQL = strSQL + " Supplier_country = @supplier_country,";
            strSQL = strSQL + " Supplier_phone =  @supplier_phone,";
            strSQL = strSQL + " Supplier_fax = @supplier_fax,";
            strSQL = strSQL + " Supplier_contact_mobile = @supplier_contact_mobile,";
            strSQL = strSQL + " Supplier_contact = @supplier_contact,";
            strSQL = strSQL + " Supplier_email = @supplier_email, ";
            strSQL = strSQL + " taxABN = @taxABN ,";
            strSQL = strSQL + " Supplier_note = @supplier_note ";
            strSQL = strSQL + " where SID =" + _id;

            #region parameter
            if (string.IsNullOrEmpty(_supplier.supplier_id))
            {
                _mycommand.Parameters.AddWithValue("@supplier_id", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_id", _supplier.supplier_id);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_name))
            {
                _mycommand.Parameters.AddWithValue("@supplier_name", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_name", _supplier.supplier_name);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_address))
            {
                _mycommand.Parameters.AddWithValue("@supplier_address", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_address", _supplier.supplier_address);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_add2))
            {
                _mycommand.Parameters.AddWithValue("@supplier_add2", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_add2", _supplier.supplier_add2);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_add3))
            {
                _mycommand.Parameters.AddWithValue("@supplier_add3", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_add3", _supplier.supplier_add3);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_district))
            {
                _mycommand.Parameters.AddWithValue("@supplier_district", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_district", _supplier.supplier_district);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_city))
            {
                _mycommand.Parameters.AddWithValue("@supplier_city", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_city", _supplier.supplier_city);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_postcode))
            {
                _mycommand.Parameters.AddWithValue("@supplier_postcode", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_postcode", _supplier.supplier_postcode);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_state))
            {
                _mycommand.Parameters.AddWithValue("@supplier_state", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_state", _supplier.supplier_state);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_country))
            {
                _mycommand.Parameters.AddWithValue("@supplier_country", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_country", _supplier.supplier_country);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_phone))
            {
                _mycommand.Parameters.AddWithValue("@supplier_phone", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_phone", _supplier.supplier_phone);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_fax))
            {
                _mycommand.Parameters.AddWithValue("@supplier_fax", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_fax", _supplier.supplier_fax);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_contact_mobile))
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact_mobile", _supplier.supplier_contact_mobile);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_contact))
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_contact", _supplier.supplier_contact);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_email))
            {
                _mycommand.Parameters.AddWithValue("@supplier_email", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_email", _supplier.supplier_email);
            }
            if (string.IsNullOrEmpty(_supplier.supplier_note))
            {
                _mycommand.Parameters.AddWithValue("@supplier_note", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@supplier_note", _supplier.supplier_note);
            }
            if (string.IsNullOrEmpty(_supplier.taxABN))
            {
                _mycommand.Parameters.AddWithValue("@taxABN", DBNull.Value);
            }
            else
            {
                _mycommand.Parameters.AddWithValue("@taxABN", _supplier.taxABN);
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
        public bool deleteSupplier(int id)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "delete from suppliers where sid=" + id + "";



                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete brand", e);
                return false;
            }
            return true;


        }

        #endregion end delete


    }

    #endregion
}