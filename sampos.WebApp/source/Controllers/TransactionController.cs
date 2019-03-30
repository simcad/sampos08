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
{
    public class TransactionController : ApiController
    {
         
        [Route("api/Customer/search")]
        [HttpGet]
        public IEnumerable<Customer> SearchCustomers(string searchText)
        {
            
            searchText = searchText ?? "";
            CustomerDataController _dc = new CustomerDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _cust = _dc.GetCustomerById(searchText).ToList();
                return _cust;
            }
            
            
                catch(Exception e){
                    

                //string _my =samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                samposoapp.ErrorLog.ErrorLog.ccException("calling search", e);
                return null;
            }
            
        }


        [Route("api/Customer/detail/{id}")]
        [HttpGet]
        public List <Customer> GetDetail(int id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);
            CustomerDataController _dc = new CustomerDataController();
            try {
                var _cust = _dc.GetCustomerById(id).ToList();
                return _cust;
            }
            catch (Exception e) {
                
                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }
            

            
        }

        [Route("api/Customer/new")]
        [HttpGet]
        public Customer NewCustomer()
        {
            return new Customer();
        }
        [Route("api/Customer/delete/{id}")]
        [HttpPost]
        public void DeleteCustomer(int Id)
        {
           // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
           // db.Customers.Remove(customer);
            //db.SaveChanges();
            CustomerDataController _dc = new CustomerDataController();
            bool _ret = _dc.DeleteCustomerById(Id);


        }

        [Route("api/Customer/Save")]
        [HttpPost]
        public Customer SaveCustomer(Customer customer)
        {
            try {
                CustomerDataController _dc = new CustomerDataController();
                    
                    bool _ret = _dc.SaveCustomerById(customer);
                   
                    return customer;
                
                
            }
            catch (Exception e) {

                
                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null; 
            }

            
        }

       
    }
}
