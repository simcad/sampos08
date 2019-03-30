using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.Mvc;

using System.Data;

using System.Net;
using Angularjs.UIRouting.WebApp.Models;
using System.Data.SqlClient;
using System.Data.OleDb;
//namespace sampos.WebApp.Controllers

namespace samposoapp.Controllers
{
    public class SaleDataController : Controller
    {

        List<Sale> xlist = new List<Sale>();


       
            #region insert

            public bool InsertSale()
            {

                // string strSQL;

                //try 
                //    {
                //    OleDbCommand _mycommand = new OleDbCommand();

                //    OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                //    strSQL = "Insert into b_group (group_id, group_desc, group_Service) values (?,?,?) "; 


                //    if (string.IsNullOrEmpty(_group.group_id))
                //    {
                //        _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
                //    }
                //    else { _mycommand.Parameters.AddWithValue("@group_id", _group.group_id); }

                //    if (string.IsNullOrEmpty(_group.group_desc))
                //    {
                //        _mycommand.Parameters.AddWithValue("@group_desc", DBNull.Value);
                //    }
                //    else
                //    {

                //        _mycommand.Parameters.AddWithValue("@group_desc", _group.group_desc); 
                //    }


                //    _mycommand.Parameters.AddWithValue("@group_service", bool.Parse(_group.group_Servcie.ToString()));

                //    OleDbConnection _conn = new OleDbConnection();
                //    _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                //    _mycommand.Connection = _conn;
                //    _mycommand.CommandType = CommandType.Text;
                //    _mycommand.CommandText = strSQL;
                //    _mycommand.ExecuteNonQuery();

                //}
                //catch (Exception e) {

                //    samposoapp.ErrorLog.ErrorLog.ccException("Insert sale", e);
                //    return false;
                //}
                return true;
            }
            #endregion end insert

            #region update
            public bool UpdateSale()
            {
                string strSQL;

                try
                {
                    //OleDbCommand _mycommand = new OleDbCommand();

                    //OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                    //string _gid = _group.group_id;
                    //strSQL = "Update b_group set group_desc=@group_desc,group_servcie=@group_service where group_id='"  + _gid + "'" ;



                    //if (string.IsNullOrEmpty(_group.group_desc))
                    //{
                    //    _mycommand.Parameters.AddWithValue("@group_desc", DBNull.Value);
                    //}
                    //else
                    //{

                    //    _mycommand.Parameters.AddWithValue("@group_desc", _group.group_desc);
                    //}

                    //_mycommand.Parameters.AddWithValue("@group_service", _group.group_Servcie);

                    //if (string.IsNullOrEmpty(_group.group_id))
                    //{
                    //    _mycommand.Parameters.AddWithValue("@group_id", DBNull.Value);
                    //}
                    //else { _mycommand.Parameters.AddWithValue("@group_id", _group.group_id); }


                    //OleDbConnection _conn = new OleDbConnection();
                    //_conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                    //_mycommand.Connection = _conn;
                    //_mycommand.CommandType = CommandType.Text;
                    //_mycommand.CommandText = strSQL;
                    //_mycommand.ExecuteNonQuery();

                }
                catch (Exception e)
                {

                    samposoapp.ErrorLog.ErrorLog.ccException("Update group", e);
                    return false;
                }
                return true;

            }
            #endregion end update


            #region delete
            public bool deletesale(string _saleid)
            {


                string strSQL;

                try
                {
                    OleDbCommand _mycommand = new OleDbCommand();

                    OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                    strSQL = "delete from b_group where group_id='" + _saleid + "'";



                    OleDbConnection _conn = new OleDbConnection();
                    _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                    _mycommand.Connection = _conn;
                    _mycommand.CommandType = CommandType.Text;
                    _mycommand.CommandText = strSQL;
                    _mycommand.ExecuteNonQuery();

                }
                catch (Exception e)
                {

                    samposoapp.ErrorLog.ErrorLog.ccException("Delete group", e);
                    return false;
                }
                return true;


            }

            #endregion end delete

            public List<SalesModel>GetSale(string id)
            {
                List<SalesModel> _saleModel = new List<SalesModel>();
                List<Sale> _SaleList = new List<Sale>();
                OleDbCommand _mycommand = new OleDbCommand();
                DataTable _mydatatable = new DataTable();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                _mydatatable = null;
                string _query;
                DataSet _ds = new DataSet();
                _query = "";

                try
                {

                    if (id.Length == 0)
                    {
                        //_query = "select top 20 * from stock_sales where stock_receipt_no like '%" + strStock_receipt_no + "%' order by stock_sales_id desc";
                        _query = "select top 20 * from stock_sales order by stock_sales_id desc";
                    }
                    else
                    {
                        _query = "select * from stock_sales where stock_sales_id like '" + id + "%'  order by stock_sales_id desc ";
                    _query = "select top 20 * from stock_sales order by stock_sales_id desc";
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


                    Sale oSales;
                    foreach (DataRow dr in _mydatatable.Rows)
                    {


                        oSales = new Sale();


                        oSales.stock_sales_id = dr["stock_sales_id"].ToString();
                        oSales.stock_receipt_no = dr["stock_receipt_no"].ToString();

                        //oSales.stock_flag = dr("stock_flag").ToString();

                        if ((dr["stock_flag"] == DBNull.Value))
                        {

                            oSales.stock_flag = "";
                        }
                        else
                        {

                            oSales.stock_flag = dr["stock_flag"].ToString();
                        }



                        if (dr["stock_sales_date"] == DBNull.Value)
                        {

                            oSales.stock_sales_date = null;
                        }
                        else
                        {

                            // oSales.stock_sales_date = dr("stock_sales_date").ToString();
                            oSales.stock_sales_date = DateTime.Parse(dr["stock_sales_date"].ToString()).ToString();

                        }


                        if (dr["stock_reference"] == DBNull.Value)
                        {
                            oSales.stock_reference = "";
                        }
                        else
                        {

                            oSales.stock_reference = dr["stock_reference"].ToString();
                        }

                        //oSales.customer_name = dr("customer_name").ToString & ""
                        oSales.customer_name = dr["customer_name"].ToString();

                        if (dr["stock_sales_total"] == DBNull.Value)
                        {
                            oSales.stock_sales_total = (float)0.0;

                        }


                        else
                        {
                            oSales.stock_sales_total = float.Parse(dr["stock_sales_total"].ToString());
                        }

                        if (dr["stock_sales_cash"] == DBNull.Value)
                        {
                            //If IsDBNull(dr("stock_sales_cash")) Then
                            oSales.stock_sales_cash = (float)0.0;
                        }
                        else
                        {
                            oSales.stock_sales_cash = float.Parse(dr["stock_sales_cash"].ToString());
                        }



                        //If IsDBNull(dr("stock_sales_creditcard")) Then
                        //    oSales.stock_sales_creditcard = 0.0
                        //Else
                        //    oSales.stock_sales_creditcard = dr("stock_sales_creditcard")
                        //End If

                        if (dr["stock_sales_creditcard"] == DBNull.Value)
                        {
                            oSales.stock_sales_creditcard = float.Parse(("0.0"));
                        }
                        else
                        {

                            oSales.stock_sales_creditcard = float.Parse(dr["stock_sales_creditcard"].ToString());
                        }



                        oSales.stock_sales_creditcard_type = dr["stock_sales_creditcard_type"].ToString();
                        //dr("stock_sales_creditcard_type").ToString & ""

                        // oSales.user_id = dr["user_id"].ToString();

                        if (dr["stock_sales_cheque"] == DBNull.Value)
                        {
                            oSales.stock_sales_cheque = float.Parse(("0.0"));
                        }
                        else
                        {

                            oSales.stock_sales_cheque = float.Parse(dr["stock_sales_cheque"].ToString());
                        }


                        if (dr["stock_sales_balance"] == DBNull.Value)
                        {
                            oSales.stock_sales_balance = float.Parse(("0.0"));
                        }
                        else
                        {

                            oSales.stock_sales_balance = float.Parse(dr["stock_sales_balance"].ToString());
                        }

                        //If IsDBNull(dr("stock_sales_payment")) Then
                        //    oSales.stock_sales_payment = 0.0
                        //Else
                        //    oSales.stock_sales_payment = dr("stock_sales_payment")
                        //End If

                        if (dr["stock_sales_payment"] == DBNull.Value)
                        {

                            oSales.stock_sales_payment = float.Parse(("0.0"));
                        }
                        else
                        {

                            oSales.stock_sales_payment = float.Parse(dr["stock_sales_payment"].ToString());
                        }


                        oSales.user_id = dr["user_id"].ToString();
                        oSales.commission_id = dr["commission_id"].ToString();

                        oSales.g_user_id = dr["g_user_id"].ToString();

                        oSales.stock_sales_period = dr["stock_sales_period"].ToString();


                        if (dr["customer_id"] == DBNull.Value)
                        {

                            oSales.customer_id = 0;
                        }

                        //    oSales.customer_id = 0
                        else
                        {

                            oSales.customer_id = long.Parse(dr["customer_id"].ToString());
                        }


                        oSales.stock_sales_time = dr["stock_sales_time"].ToString();
                        if (dr["Sales_Id"] == DBNull.Value)
                        {


                        }
                        else
                        {
                            oSales.SalesId = long.Parse(dr["Sales_Id"].ToString());
                        }




                        if (dr["roundingadj"] == DBNull.Value)
                        {

                            oSales.rounding = float.Parse(Math.Round((double)0.0000, 2).ToString());

                        }
                        else
                        {

                        var _tmp =dr["roundingadj"];
                            //oSales.rounding = float.Parse(Math.Round((double)dr["roundingadj"], 2).ToString());

                        }



                        _SaleList.Add(oSales);




                    }

                    // _Group = _gList.ToList();



                }
                catch (SqlException e)
                {
                    //   return _result;

                    samposoapp.ErrorLog.ErrorLog.ccException("Load group", e);
                    //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                    _mydatatable = null;
                    // blist = null;


                }

                return _saleModel;

            }


       

        //}
        //public List<GroupModel> GetGroupId(string id)
        //{

        //    List<GroupModel> _l = new List<GroupModel>();
        //    try {
        //        GroupModel _sm = new GroupModel();

        //        _sm.GetGroup(id);
        //        _l.Add(_sm);

        //    }
        //    catch (Exception e) {
        //        samposoapp.ErrorLog.ErrorLog.ccException("GetGroupId - model", e);



        //    }


        //    return _l;
        //}


        //Search
        //public IEnumerable<Group> GetSGroupById(string id)
        //{

        //    OleDbCommand _mycommand = new OleDbCommand();
        //    DataTable _mydatatable = new DataTable();

        //    OleDbDataAdapter _myadapter = new OleDbDataAdapter();
        //    _mydatatable = null;
        //    string _query;
        //    DataSet _ds = new DataSet();



        //    try
        //    {

        //        if (id.Length == 0)
        //        {
        //            _query = "select * from b_group";// where group_desc  = ''";
        //        }
        //        else
        //        {
        //            _query = "select * from b_group where group_desc like '%" + id + "%'" ;
        //        }
        //        OleDbConnection _conn = new OleDbConnection();
        //        _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
        //        _mycommand.Connection = _conn;
        //        _mycommand.CommandType = CommandType.Text;
        //        _mycommand.CommandText = _query;
        //        _mycommand.ExecuteNonQuery();


        //        _myadapter.SelectCommand = _mycommand;
        //        _myadapter.Fill(_ds);
        //        _mydatatable = _ds.Tables[0];


        //        Group s;
        //        foreach (DataRow dr in _mydatatable.Rows)
        //        {

        //            s = new Group();
        //            s.group_id = dr["group_id"].ToString();
        //            s.group_desc = dr["group_desc"].ToString();
        //            s.group_max = int.Parse(dr["group_max"].ToString());
        //            s.group_min = int.Parse(dr["group_max"].ToString());
        //            s.group_Servcie = bool.Parse(dr["group_Servcie"].ToString());


        //            xlist.Add(s);

        //        }

        //        return xlist;


        //    }
        //    catch (SqlException e)
        //    {
        //        //   return _result;

        //        samposoapp.ErrorLog.ErrorLog.ccException("GetSGroupById", e);
        //        //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

        //        _mydatatable = null;
        //        xlist = null;


        //    }

        //    return xlist;
        //}


        #region delete group
        public bool DeleteSaleById(string _groupid)
        {

            bool _ret = false;
            try
            {
                bool _check = samposoapp.Utility.Utility.CheckGroupInStock(_groupid);
                if (_check)
                {
                    GroupModel _gm = new GroupModel();
                    _ret = _gm.deleteGroup(_groupid);
                }
                else { _ret = false; }

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteGroupById", e);
                _ret = false;

            }
            return _ret;
        }

        #endregion delete


        #region save group

        public bool SaveSaleById(Sale _sale)
        {

            bool _ret = false;

            try
            {
                //if (_group.group_max == 1)
                //{



                //    GroupModel _gm = new GroupModel();

                //    _gm._group = _group;
                //    _gm.InsertGroup();

                //}
                //else
                //{

                //    GroupModel _gm = new GroupModel();
                //    _gm._group = _group;
                //    _ret = _gm.UpdateGroup();


                //}


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteGroupById", e);
                _ret = false;



            }

            return _ret;



        }


    }
    #endregion

}
