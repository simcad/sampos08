using Angularjs.UIRouting.WebApp.DataAccessLayer;



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
//using Angularjs.UIRouting.WebApp.DataAccessLayer;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using samposoapp.ErrorLog;



namespace samposoapp.Controllers

//namespace Angularjs.UIRouting.WebApp.Controllers
{
    public class GroupController : ApiController
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

        [Route("api/Group/searchgroup")]
        [HttpGet]
        public IEnumerable<Group> SearchGroups(string searchText)
        {

            searchText = searchText ?? "";
             GroupDataController _dc = new GroupDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _group = _dc.GetSGroupById(searchText).ToList();
                
                return _group;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }

        
        [Route("api/group/groupdetail/{id}")]
        [HttpGet]
        public List<GroupModel> GetDetail(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);
            
            GroupDataController _dc = new GroupDataController();

            try
            {
                var _group = _dc.GetGroupId(id).ToList();//          .GetStockId(id).ToList();
                return _group;
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }



        
        [Route("api/Group/newgroup")]
        [HttpGet]
        public Group NewStock()
        {
            return new Group();
        }

        [Route("api/Group/Save")]
        [HttpPost]
        public Group SaveGroup(Group _group)
        {
            try
            {
                
                GroupDataController _gc = new GroupDataController();

              //  bool _ret = _dc.SaveStockById(_group);
                _gc.SaveGroupById(_group);
                return _group;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Group/deletegroup/{id}")]
        [HttpPost]
        public void DeleteGroup(string Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
            GroupDataController _gc = new GroupDataController();
            bool _ret = _gc.DeleteGroupById(Id);


        }
    }
}
