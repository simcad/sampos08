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

//It handles incoming HTTP requests and send response back to the caller. 
//Web API controller is a class which can be created under the Controllers folder or any other folder
//under your project's root folder.
//


namespace samposoapp.Controllers

//namespace Angularjs.UIRouting.WebApp.Controllers
{
    public class CreditcardController : ApiController
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
        // please to the controller name (aka datamodel - SysmessageController

        [Route("api/Creditcard/searchcreditcard/{searchText}")]
        [HttpGet]
        public IEnumerable<Creditcard> SearchCreditcard(string searchText)
        {

            searchText = searchText ?? "";
            
            CreditcardDataController _dc = new CreditcardDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _creditcard = _dc.GetCreditcardById(searchText).ToList();


                return _creditcard;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }


        [Route("api/Creditcard/detail/{id}")]
        [HttpGet]
        public List<CreditcardModel> GetDetail(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

           // BrandDataController _dc = new BrandDataController();
            CreditcardDataController _dc = new CreditcardDataController();
            try
            {

                // call integer version return a list
                var _creditcard = _dc.GetCreditcardId(id);
                return _creditcard;

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }


      

        [Route("api/Creditcard/newcreditcard")]
        [HttpGet]
        public Creditcard Newcreditcard()
        {

            Creditcard _newcreditcard = new Creditcard();
            _newcreditcard.add = 1;
            return _newcreditcard;
            //return new Creditcard();
        }

        [Route("api/Creditcard/Save")]
        [HttpPost]
        public Creditcard SaveCreditcard(Creditcard _creditcard)  //does not matter the function name as long as the router is correct
        {
            try
            {

                
                CreditcardDataController _gc = new CreditcardDataController();

                //  bool _ret = _dc.SaveStockById(_brand);
               // _gc.SaveBrandById(_brand);

                bool _ret = _gc.SaveCreditcardById(_creditcard);
                return _creditcard;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Creditcard/delete/{id}")]                               
        //[Route("api/Creditcard/deletecreditcard/{id}")]
        [HttpPost]
        public void DeleteCreditcard(string Id)
        {
            
           
            
            CreditcardDataController _cc = new CreditcardDataController();
            bool _ret = _cc.DeleteCreditcardById(Id);

          

        }
    }
}
