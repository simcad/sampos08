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
    public class CommissionController : ApiController
    {
        //DataContext db = new DataContext();
        // GET: api/Contact
        //public IEnumerable<Contact> Get()
        //{
        //    return db.Contacts;
        //}

        //public Contact Get(int id)
        //{
        //    return db.Contacts.FirstOrDefault(x => x.ContactId == id);
        //}

        [Route("api/commission/searchcommission")]
        [HttpGet]
        public IEnumerable<Commission> SearchCommissions(string searchText)
        {

            searchText = searchText ?? "";
            CommmissionDataController _dc = new CommmissionDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _commission = _dc.GetSCommissionById(searchText).ToList();
                
                return _commission;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }


        [Route("api/commission/commissiondetail/{id}")]
        [HttpGet]
        public List<CommissionModel> GetDetail(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

            CommmissionDataController _dc = new CommmissionDataController();

            try
            {

                var _commission = _dc.GetCommissionId(id).ToList();
                return _commission;

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - Commmission", e);
                return null;
            }



        }



        
        [Route("api/Commission/newcommission")]
        [HttpGet]
        public Commission NewStock()
        {
            return new Commission();
        }

        [Route("api/Commission/Save")]
        [HttpPost]
        public Commission SaveCommission(Commission _commission)
        {
            try
            {
                
                
                CommmissionDataController _gc = new CommmissionDataController();
              //  bool _ret = _dc.SaveStockById(_group);
                
                _gc.SaveCommissionById(_commission);
                return _commission;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save commission", e);
                return null;
            }


        }


        // delete
        [Route("api/Commission/deletecommission/{id}")]
        [HttpPost]
        public void DeleteCommission(string Id)
        {
            
            CommmissionDataController _gc = new CommmissionDataController();
            bool _ret = _gc.DeleteCommissionById(Id);
                


        }
    }
}
