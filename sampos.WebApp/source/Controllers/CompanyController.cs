using Angularjs.UIRouting.WebApp.DataAccessLayer;
//using Angularjs.UIRouting.WebApp.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using samposoapp.Controllers;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Entity;
using System.Linq;
//using System.Web.Mvc;
using System.Web;
//using samposoapp.Models;
//using AngularJSWithMVC.Models;
using Angularjs.UIRouting.WebApp.Models;
using Angularjs.UIRouting.WebApp.DataAccessLayer;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using samposoapp.ErrorLog;



namespace samposoapp.Controllers

//namespace Angularjs.UIRouting.WebApp.Controllers
{
    public class CompanyController : ApiController
    {
        

        [Route("api/Company/searchcompany")]
        [HttpGet]
        public IEnumerable<Company> SearchCompanys(string searchText)
        {

            searchText = searchText ?? "";
             CompanyDataController _dc = new CompanyDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _company = _dc.GetSCompanyById(searchText).ToList();
                
                return _company;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }

        
        [Route("api/company/companydetail/{id}")]
        [HttpGet]
        public List<CompanyModel> GetDetail(string id)
        {
            

            CompanyDataController _dc = new CompanyDataController();

            try
            {
                var _company = _dc.GetCompanyId(id).ToList();//          .GetStockId(id).ToList();
                return _company;
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }



        
        [Route("api/Company/newcompany")]
        [HttpGet]
        public Company NewCompany()
        {
            return new Company();
        }

        [Route("api/Company/Save")]
        [HttpPost]
        public Company SaveCompany(Company _company)
        {
            try
            {

                CompanyDataController _gc = new CompanyDataController();

              //  bool _ret = _dc.SaveStockById(_group);
                
                _gc.SaveCompanyById(_company);
                return _company;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Company/deletecompany/{id}")]
        [HttpPost]
        public void DeleteCompany(string Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
            CompanyDataController _gc = new CompanyDataController();
           // bool _ret = _gc.DeleteGroupById(Id);


        }
    }
}
