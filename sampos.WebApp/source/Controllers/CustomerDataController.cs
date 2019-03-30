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
    public class CustomerDataController : Controller
    {
        // GET: CustomerData
        List<Customer> xlist = new List<Customer>();
        List<Customer_detail> dlist = new List<Customer_detail>();

        public IEnumerable<Customer_detail> GetCustomerDetailById(int id)
        {
            List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            Customer_detail p;
            p = new Customer_detail();
            
            try
            {

                if (id == 0)
                {
                    _query = "select * from customer_detail where customer_id=" + id;//; where id < 50";
                }
                else
                {
                    _query = "select * from customer_detail where customer_id="  + id;
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
                _ds.Tables[0].TableName = "customer_detail";


                foreach (DataRow dr in _mydatatable.Rows)
                {


                    


                    p.customer_detail_id = int.Parse(dr["customer_detail_id"].ToString());
                    p.customer_id = int.Parse(dr["customer_id"].ToString());
                    p.customer_detail_date = DateTime.Parse(dr["customer_detail_date"].ToString());
                    p.sales_type = dr["sales_type"].ToString();
                    p.reference = dr["reference"].ToString();
                    p.rx_r_sp = dr["rx_r_sp"].ToString();
                    p.rx_r_cy = dr["rx_r_cy"].ToString();
                    p.rx_r_ax = dr["rx_r_ax"].ToString();
                    p.rx_r_va = dr["rx_r_va"].ToString();
                    p.rx_l_sp = dr["rx_l_sp"].ToString();
                    p.rx_l_cy = dr["rx_l_cy"].ToString();
                    p.rx_l_ax = dr["rx_l_ax"].ToString();
                    p.rx_l_va = dr["rx_l_va"].ToString();
                    p.dist_r_sp = dr["dist_r_sp"].ToString();
                    p.dist_r_cy = dr["dist_r_cy"].ToString();
                    p.dist_r_ax = dr["dist_r_ax"].ToString();
                    p.dist_r_va = dr["dist_r_va"].ToString();
                    p.dist_l_sp = dr["dist_l_sp"].ToString();
                    p.dist_l_cy = dr["dist_l_cy"].ToString();
                    p.dist_l_ax = dr["dist_l_ax"].ToString();
                    p.dist_l_va = dr["dist_l_va"].ToString();
                    p.reading_r_sp = dr["reading_r_sp"].ToString();
                    p.reading_r_cy = dr["reading_r_cy"].ToString();
                    p.reading_r_ax = dr["reading_r_ax"].ToString();
                    p.reading_r_va = dr["reading_r_va"].ToString();
                    p.reading_l_sp = dr["reading_l_sp"].ToString();
                    p.reading_l_cy = dr["reading_l_cy"].ToString();
                    p.reading_l_ax = dr["reading_l_ax"].ToString();
                    p.reading_l_va = dr["reading_l_va"].ToString();
                    p.kreading_r_h = dr["kreading_r_h"].ToString();
                    p.kreading_r_v = dr["kreading_r_v"].ToString();
                    p.kreading_l_h = dr["kreading_l_h"].ToString();
                    p.kreading_l_v = dr["kreading_l_v"].ToString();
                    p.s_frame = dr["s_frame"].ToString();
                    p.lense = dr["lense"].ToString();
                    p.pd_cd = dr["pd_cd"].ToString();
                    p.pd_hg = dr["pd_hg"].ToString();
                    p.sg_hg = dr["sg_hg"].ToString();
                    p.pd_cd_R = dr["pd_cd_R"].ToString();
                    p.pd_hg_R = dr["pd_hg_R"].ToString();
                    p.sg_hg_R = dr["sg_hg_R"].ToString();
                    p.fee = dr["fee"].ToString();
                    p.dist_r_add = dr["dist_r_add"].ToString();
                    p.dist_l_add = dr["dist_l_add"].ToString();
                    p.rx_r_add = dr["rx_r_add"].ToString();
                    p.rx_l_add = dr["rx_l_add"].ToString();
                    p.remark_1 = dr["remark_1"].ToString();
                    p.remark_2 = dr["remark_2"].ToString();
                    p.basecurve = dr["basecurve"].ToString();
                    p.basecurve_R = dr["basecurve_R"].ToString();
                    p.power = dr["power"].ToString();
                    p.sp_text1 = dr["sp_text1"].ToString();
                    p.sp_text2 = dr["sp_text2"].ToString();
                    p.fee_l = dr["fee_l"].ToString();
                    p.fee_cl = dr["fee_cl"].ToString();
                    p.C_BC_R = dr["C_BC_R"].ToString();
                    p.C_DIA_R = dr["C_DIA_R"].ToString();
                    p.C_SPH_R = dr["C_SPH_R"].ToString();
                    p.C_CYL_R = dr["C_CYL_R"].ToString();
                    p.C_AXL_R = dr["C_AXL_R"].ToString();
                    p.C_ADD_R = dr["C_ADD_R"].ToString();
                    p.C_BC_L = dr["C_BC_L"].ToString();
                    p.C_DIA_L = dr["C_DIA_L"].ToString();
                    p.C_SPH_L = dr["C_SPH_L"].ToString();
                    p.C_CYL_L = dr["C_CYL_L"].ToString();
                    p.C_AXL_L = dr["C_AXL_L"].ToString();
                    p.C_ADD_L = dr["C_ADD_L"].ToString();
                    p.kreading_r_mm = dr["kreading_r_mm"].ToString();
                    p.kreading_l_mm = dr["kreading_l_mm"].ToString();
                    p.kreading_r_diopter = dr["kreading_r_diopter"].ToString();
                    p.kreading_l_diopter = dr["kreading_l_diopter"].ToString();
                    p.rx_r_PrismDist = dr["rx_r_PrismDist"].ToString();
                    p.rx_l_PrismDist = dr["rx_l_PrismDist"].ToString();
                    p.dist_r_PrismDist = dr["dist_r_PrismDist"].ToString();
                    p.dist_l_PrismDist = dr["dist_l_PrismDist"].ToString();
                   // p.upsize_ts = dr["upsize_ts"].ToString();

                    dlist.Add(p);


                }

                return dlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetCustomerDetailById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                dlist = null;


            }

            return dlist;
        }

        public IEnumerable<Customer> GetCustomerById(int id)
        {
            List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            Customer x;
            x = new Customer();
            
            try
            {

                if (id==0)
                {
                    _query = "select top 20 * from customer order by Id desc";//; where id < 50";
                }
                else
                {
                    _query = "select * from customer where customer_id =" + id;
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
                   
                    
                    x.Id = int.Parse(dr["Id"].ToString());
                    x.customer_id = int.Parse(dr["customer_id"].ToString());
                    x.name = dr["name"].ToString();
                    x.address = dr["address"].ToString();
                    x.district = dr["district"].ToString();
                    x.state = dr["state"].ToString();
                    x.city = dr["city"].ToString();
                    x.postcode = dr["postcode"].ToString();
                    x.country = dr["country"].ToString();
                    x.m_phone = dr["m_phone"].ToString();
                    x.ic_no = dr["ic_no"].ToString();
                    x.sex = dr["sex"].ToString();
                    x.e_mail = dr["e_mail"].ToString();

                    xlist.Add(x);

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

        public IList<Customer> GetCustomerById( string id )
        {

            List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand1;// = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
          
            try
            {

                if (string.IsNullOrEmpty(id)) {
                    _query = "select top 5 * from customer where id>0 ";
                }
                else
                {
                    _query = "select * from customer where name like '%" + id + "%'";
                }
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                 _mycommand1 = new OleDbCommand(_query,_conn);
                //_mycommand.Connection = _conn;
                
                
                //_mycommand.CommandType = CommandType.Text;
                //_mycommand.CommandText = _query;
                _mycommand1.ExecuteNonQuery();
                
                    
                    _myadapter.SelectCommand = _mycommand1;
                    _myadapter.Fill(_ds);
                    _mydatatable = _ds.Tables[0];
                    _mydatatable.TableName = "Customer";

                   
                Customer x;
                foreach(DataRow dr in _mydatatable.Rows)
                {
                    x = new Customer();
                    
                    x.Id = int.Parse(dr["Id"].ToString());
                    x.name = dr["name"].ToString();
                    x.address = dr["address"].ToString();
                    x.district = dr["district"].ToString();
                    x.state=  dr["state"].ToString();
                    x.city = dr["city"].ToString();
                    x.postcode =dr["postcode"].ToString();
                    x.country=  dr["country"].ToString();
                    x.m_phone = dr["m_phone"].ToString();
                    x.ic_no= dr["ic_no"].ToString();
                    x.sex =  dr["sex"].ToString();
                    x.e_mail= dr["e_mail"].ToString();
                    x.customer_id = int.Parse(dr["customer_id"].ToString());
                    xlist.Add(x);

                }


            }
            catch (SqlException e)
            {
                //   return _result;

                
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message + "open");
                samposoapp.ErrorLog.ErrorLog.ccException("GetCustomerById_string", e);
                _mydatatable = null;
                xlist =null;


            }


            return xlist;

        }

        #region Delete customer
        public bool DeleteCustomerById(int _id){

            bool _return = false;
            OleDbCommand _mycommand = new OleDbCommand();
            OleDbDataAdapter _myadapter = new OleDbDataAdapter();

            string _query;
            _query = "delete from customer where Id=@Id";
            try {

                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;

                _mycommand.Parameters.AddWithValue("@Id", _id);
                _mycommand.CommandText = _query;

                _mycommand.ExecuteNonQuery();
                _return = true;
            }
            catch(Exception e){
                string _msg = _query + " calling delete function";
                     
                samposoapp.ErrorLog.ErrorLog.ccException(_msg, e);
                 _return= false;
            
            }
            return _return;

        }
        #endregion


        #region save customer

        public bool SaveCustomerById(Customer _customer)
        {

            List<Customer> _result = new List<Customer>();
            //OleDbCommand _mycommand = new OleDbCommand();
            OleDbCommand _mycommand = new OleDbCommand();
            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
           
            string _query;
            
            
            try
            {
                int _customerid = samposoapp.Utility.Utility.GetSequenceNumber("CU");
                if (_customer.Id == 0)
                {
                
                //_query = "INSERT INTO customer (Username, Password) VALUES (@Username,@Password)";
                _query = "insert into customer([name],[address],[district],[postcode],[city],[state],[e_mail],[sex],[m_phone],[c_note],[ic_no],[customer_id]) values (?,?,?,?,?,?,?,?,?,?,?,?)";
                _mycommand.CommandText = _query;
                _mycommand.Parameters.AddWithValue("@name", _customer.name);

                if (string.IsNullOrEmpty(_customer.address))
                {
                    _mycommand.Parameters.AddWithValue("@address", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@address", _customer.address); }


                if (string.IsNullOrEmpty(_customer.district))
                {

                    _mycommand.Parameters.AddWithValue("@district", DBNull.Value);
                }
                else {
                    _mycommand.Parameters.AddWithValue("@district", _customer.district); }

                if (string.IsNullOrEmpty(_customer.postcode))
                {

                    _mycommand.Parameters.AddWithValue("@postcode", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@postcode", _customer.postcode);
                }


                    if (string.IsNullOrEmpty(_customer.city))
                    {

                        _mycommand.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        _mycommand.Parameters.AddWithValue("@city", _customer.postcode);
                    }

                    if (string.IsNullOrEmpty(_customer.state))
                {
                    _mycommand.Parameters.AddWithValue("@state", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@state", _customer.state);

                }

                

                //if (string.IsNullOrEmpty(_customer.country))
                //{
                //    _mycommand.Parameters.AddWithValue("@country", DBNull.Value);
                //}
                //else { _mycommand.Parameters.AddWithValue("@country", _customer.country); }

                if (string.IsNullOrEmpty(_customer.e_mail))
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", DBNull.Value);

                }

                else { _mycommand.Parameters.AddWithValue("@e_mail", _customer.e_mail); }


                //

                // 
                if (string.IsNullOrEmpty(_customer.sex))
                {

                    _mycommand.Parameters.AddWithValue("@sex", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@sex", _customer.sex);
                }



                if (string.IsNullOrEmpty(_customer.m_phone))
                {

                    _mycommand.Parameters.AddWithValue("@m_phone", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@m_phone", _customer.m_phone); }

                if (string.IsNullOrEmpty(_customer.ic_no))
                { 
                    _mycommand.Parameters.AddWithValue("@ic_no", DBNull.Value); }
                else {
                    _mycommand.Parameters.AddWithValue("@ic_no", _customer.ic_no); }

                // 


                if (string.IsNullOrEmpty(_customer.c_note))
                {

                    _mycommand.Parameters.AddWithValue("@c_note", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@c_note", _customer.c_note); }


                _mycommand.Parameters.AddWithValue("@customer_id", _customerid);

                _customer.customer_id = _customerid;

                
                
                }
                else
                
                {


                    _query = @"UPDATE customer 
                    set name=@name,
                        address=@address,
                        district =@district,
                        postcode =@postcode,
                        state =@state,
                        city =@city,
                        country =@country,
                        e_mail=@e_mail,
                        sex=@sex,
                        m_phone =@m_phone,
                        c_note=@c_note,
                        ic_no=@ic_no where Id=@id";

                    
                 _mycommand.Parameters.AddWithValue("@name", _customer.name);
                if(string.IsNullOrEmpty(_customer.address)){
                    _mycommand.Parameters.AddWithValue("@address", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@address", _customer.address); }
                if (string.IsNullOrEmpty(_customer.district))
                {
                    
                    _mycommand.Parameters.AddWithValue("@district", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@district", _customer.district); }

                if (string.IsNullOrEmpty(_customer.postcode)){
                    
                    _mycommand.Parameters.AddWithValue("@postcode", DBNull.Value);
                }
                else{
                    _mycommand.Parameters.AddWithValue("@postcode", _customer.postcode);
                }
                if (string.IsNullOrEmpty(_customer.state))
                { 
                    _mycommand.Parameters.AddWithValue("@state", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@state", _customer.state);
                    
                }
                if (string.IsNullOrEmpty(_customer.city))
                    {
                        _mycommand.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        _mycommand.Parameters.AddWithValue("@city", _customer.city);

                    }

                if (string.IsNullOrEmpty(_customer.country))
                {
                    _mycommand.Parameters.AddWithValue("@country", DBNull.Value);
                }
                else {  _mycommand.Parameters.AddWithValue("@country",_customer.country);}

                if (string.IsNullOrEmpty(_customer.e_mail))
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", DBNull.Value);

                }
                else { _mycommand.Parameters.AddWithValue("@e_mail", _customer.e_mail); }


                //
             
               // 
                if (string.IsNullOrEmpty(_customer.sex))
                {

                    _mycommand.Parameters.AddWithValue("@sex", DBNull.Value);
                }else{
                    _mycommand.Parameters.AddWithValue("@sex", _customer.sex);
                }


               
                if (string.IsNullOrEmpty(_customer.m_phone))
                {

                    _mycommand.Parameters.AddWithValue("@m_phone", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@m_phone", _customer.m_phone); }

                if (string.IsNullOrEmpty(_customer.ic_no))
                { _mycommand.Parameters.AddWithValue("@ic_no", DBNull.Value); }
                else { _mycommand.Parameters.AddWithValue("@ic_no", _customer.ic_no); }

              // 


                if (string.IsNullOrEmpty(_customer.c_note))
                {

                    _mycommand.Parameters.AddWithValue("@c_note", DBNull.Value);
                }
                else { _mycommand.Parameters.AddWithValue("@c_note", _customer.c_note); }
                
                _mycommand.Parameters.AddWithValue("@id", _customer.Id);
                
                }


                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _query;
                _mycommand.ExecuteNonQuery();


                return true;


                


            }
            catch (SqlException e)
            {
                //   return _result;


                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);

                return false;


            }


            

        }


        #endregion


        //ene of controller
    }
}