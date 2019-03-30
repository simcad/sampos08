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
    public class SysmessageController : ApiController
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

        [Route("api/Sysmessage/searchsysmessages/{searchText}")]
        [HttpGet]
        public IEnumerable<SysMessage> SearchSysmessage(string searchText)
        {

            searchText = searchText ?? "";
            
            SysMessageDataController _dc = new SysMessageDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _sysmessage = _dc.GetSSysmesageById(searchText).ToList();

                return _sysmessage;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }


        [Route("api/Sysmessage/detail/{id}")]
        [HttpGet]
        public List<SysMessageModel> GetDetail(int id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

           // BrandDataController _dc = new BrandDataController();
            SysMessageDataController _dc = new SysMessageDataController();
            try
            {
              

                var _sysmessage = _dc.GetSysmessageId(id);
                return _sysmessage;

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }


      

        [Route("api/Sysmessage/newsysmessage")]
        [HttpGet]
        public SysMessage Newsysmessage()
        {
            return new SysMessage();
        }

        [Route("api/Sysmessage/Save")]
        [HttpPost]
        public SysMessage SaveSysmessage(SysMessage _sysmessage)  //does not matter the function name as long as the router is correct
        {
            try
            {

                SysMessageDataController _gc = new SysMessageDataController();

                //  bool _ret = _dc.SaveStockById(_brand);
               // _gc.SaveBrandById(_brand);

                bool _ret = _gc.SaveMessageById(_sysmessage);
                return _sysmessage;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }

        
        // delete
        [Route("api/Sysmessage/deletesysmessage/{id}")]
        [HttpPost]
        public void Deletemessage(int Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
           
            SysMessageDataController _gc = new SysMessageDataController();


            bool _ret = _gc.DeleteMessageById(Id);


        }
    }
}
