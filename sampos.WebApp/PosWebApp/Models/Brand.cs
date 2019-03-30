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
    public class BrandModel
    {
        public Brand _brand { get; set; }
        public List<Brand> _Brand { get; set; }

        public void GetBrand(int id) // drop down list
        {

            List<Brand> _bList = new List<Brand>();
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
                    _query = "select * from brand order by brand_id ";
                    //,[brand_desc]
                }
                else
                {
                    _query = "select * from brand where id= " + id ;
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
                    b.brand_id = dr["brand_id"].ToString();
                    b.brand_desc = dr["brand_desc"].ToString();

                    b.id = int.Parse(dr["Id"].ToString());

                    _bList.Add(b);

                }

                _Brand = _bList.ToList();
               // return _Brand;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load Brand", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
               // blist = null;


            }

           // return blist;
        }


        #region insert

        public bool InsertBrand()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "Insert into brand (brand_id, brand_desc) values (?,?) ";


                if (string.IsNullOrEmpty(_brand.brand_id))
                {
                    _mycommand.Parameters.AddWithValue("@brand_id", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@brand_id", _brand.brand_id); }

                if (string.IsNullOrEmpty(_brand.brand_desc))
                {
                    _mycommand.Parameters.AddWithValue("@brand_desc", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@brand_desc", _brand.brand_desc);
                }


               

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
        public bool UpdateBrand()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                //string _id = _brand.id;
                int _id = _brand.id;
                strSQL = "Update brand set brand_id=@brand_id,brand_desc=@brand_desc where id=" + _id + "";



                if (string.IsNullOrEmpty(_brand.brand_id))
                {
                    _mycommand.Parameters.AddWithValue("@brand_id", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@brand_id", _brand.brand_id);
                }


                if (string.IsNullOrEmpty(_brand.brand_desc))
                {
                    _mycommand.Parameters.AddWithValue("@brand_desc", DBNull.Value);
                }
                else
                {

                    _mycommand.Parameters.AddWithValue("@brand_desc", _brand.brand_desc);
                }

                



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
        public bool deleteBrand(int id)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                strSQL = "delete from brand where id=" + id + "";



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

    public class Brand
    {
        public string brand_id { get; set; }
        public string brand_desc { get; set; }
        public string brand_note1 { get; set; }
        public string brand_note2 { get; set; }
        public int id { get; set; }
        public float brand_max { get; set; }
        public float brand_min { get; set; }
        public float brand_max_wh { get; set; }
        public float brand_min_wh { get; set; }
        public float brand_min_ordered { get; set; }
        public string brand_sup_id { get; set; }



    }

}