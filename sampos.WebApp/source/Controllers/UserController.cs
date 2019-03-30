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
    public class UserController : ApiController
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

        [Route("api/user/searchuser")]
        [HttpGet]
        public IEnumerable<User> SearchUsers(string searchText)
        {

            searchText = searchText ?? "";
            UserDataController _dc = new UserDataController();
           
            try
            {
                //DataSet  _cust = new DataSet ();
                var _commission = _dc.GetUserById_str(searchText).ToList();
                
                return _commission;

                //var _user = _dc.u
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }


        [Route("api/user/userdetail/{id}")]
        [HttpGet]
        public List<UserModel> GetDetail(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

            UserDataController _dc = new UserDataController();

            try
            {

                var _user = _dc.GetUserId(id).ToList();
                return _user;

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - Commmission", e);
                return null;
            }



        }



        
        [Route("api/user/newuser")]
        [HttpGet]
        public User NewStock()
        {
            return new User();
        }

        [Route("api/user/Save")]
        [HttpPost]
        public User SaveUser(User _user)
        {
            try
            {


                UserDataController _gc = new UserDataController();
              //  bool _ret = _dc.SaveStockById(_group);
                _gc.SaveUserById(_user);

                return _user;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save user", e);
                return null;
            }


        }


        // delete
        [Route("api/User/deleteuser/{id}")]
        [HttpPost]
        public void DeleteUser(string Id)
        {
            
            UserDataController _gc = new UserDataController();
            bool _ret = _gc.DeleteUserById(Id);
                


        }
    }
}
