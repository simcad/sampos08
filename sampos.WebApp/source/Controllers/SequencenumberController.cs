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
    public class SequencenumberController : ApiController
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

        [Route("api/Sequencenumber/searchseq/{searchText}")]
        [HttpGet]
        public IEnumerable<Sequencenumber> Search(string searchText)
        {

            searchText = searchText ?? "";
            
            SequencenumberDataController _dc = new SequencenumberDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _sequencenumber = _dc.GetSequencenumberById(searchText).ToList();


                return _sequencenumber;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }


        [Route("api/Sequencenumber/detail/{id}")]
        [HttpGet]
        public List<SequencenumberModel> GetDetail(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

           // BrandDataController _dc = new BrandDataController();
            SequencenumberDataController _dc = new SequencenumberDataController();
            try
            {

                // call integer version return a list
                var _sequencenumber = _dc.GetSequencenumberId(id);
                return _sequencenumber;

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }




        [Route("api/Sequencenumber/New")]
        [HttpGet]
        public Sequencenumber Newcreditcard()
        {

            Sequencenumber _newcreditcard = new Sequencenumber();
            _newcreditcard.add = 1;
            return _newcreditcard;
            //return new Creditcard();
        }

        [Route("api/Sequencenumber/Save")]
        [HttpPost]
        public Sequencenumber SaveCreditcard(Sequencenumber _sequencenumber)  //does not matter the function name as long as the router is correct
        {
            try
            {


                SequencenumberDataController _gc = new SequencenumberDataController();

                //  bool _ret = _dc.SaveStockById(_brand);
               // _gc.SaveBrandById(_brand);

                bool _ret = _gc.SaveSequenceNumberById(_sequencenumber);
                return _sequencenumber;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Creditcard/deletecreditcard/{id}")]
        [HttpPost]
        public void Deletecreditcard(string Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
           
            
            SequencenumberDataController _cc = new SequencenumberDataController();
            bool _ret = _cc.DeleteSequencenumberById(Id);

           // bool _ret = _gc.DeleteBrandById(Id);


        }
    }
}
