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
    public class CompanyDataController : Controller
    {
        

        // GET: GroupData
        List<Company> xlist = new List<Company>();

      
        public List<CompanyModel> GetCompanyId(string id)
        {

            List<CompanyModel> _l = new List<CompanyModel>();
            try {
                CompanyModel _sm = new CompanyModel();
                
                
                _sm.GetCompany(id);
                _l.Add(_sm);
                return _l;

            }
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccException("GetCompanyId - model", e);
                return _l;
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                
            }


            
        }

        
        //Search
        public IEnumerable<Company> GetSCompanyById(string id)
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
                    _query = "select * from Company";// where group_desc  = ''";
                }
                else
                {
                    _query = "select * from Company where Company_Id like '%" + id + "%'" + "or company_name like '%" + id + "%'";

                       
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
                    c.hd_freespace = dr["hd_freespace"].ToString();
                    c.hd_date = dr["hd_date"].ToString();
                    c.hd_rom = dr["hd_rom"].ToString();
                    c.company_password = dr["company_password"].ToString();
                   // c.logo = dr["logo"].ToString();
                    c.logo_f = dr["logo_f"].ToString();
                    c.ABN = dr["ABN"].ToString();
                    c.GST_ID = dr["GST_ID"].ToString();

                    //c.GST_register_date =DateTime.Parse(dr["GST_register_date"].ToString());

                   
                    xlist.Add(c);

                }

                return xlist;


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("GetS Company ById", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                xlist = null;


            }

            return xlist;
        }


        #region delete group
        public bool DeleteGroupById(string _groupid) 
        {

            bool _ret = false;
            try {
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

        public bool SaveCompanyById(Company _company)
        {

            bool _ret = false;

            try
            {
                if (_company.company_id =="")
                {


                    
                    CompanyModel _gm = new CompanyModel();

                    _gm._company = _company;
                   // _gm.InsertGroup();
                    
            
                }
                else
                {

                    CompanyModel _gm = new CompanyModel();
                    _gm._company = _company;
                    _ret = _gm.UpdateCompany();


                }  


            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("DeleteGroupById", e);
                _ret = false;
                


            }

            return _ret;

            

        }


        #endregion


        //ene of controller
    }
}