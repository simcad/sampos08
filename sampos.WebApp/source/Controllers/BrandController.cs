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
    public class BrandController : ApiController
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

        [Route("api/Brand/searchbrand")]
        [HttpGet]
        public IEnumerable<Brand> SearchBrands(string searchText)
        {

            searchText = searchText ?? "";
             BrandDataController _dc = new BrandDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _brand = _dc.GetSBrandById(searchText).ToList();
                
                return _brand;
                //return null;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }

        
        [Route("api/brand/branddetail/{id}")]
        [HttpGet]
        public List<BrandModel> GetDetail(int id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);
            
            BrandDataController _dc = new BrandDataController();

            try
            {
                
                var _brand = _dc.GetBrand(id).ToList();// GetBrandById(id).ToList();//          .GetStockId(id).ToList();
                return _brand;
                
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }



        
        [Route("api/Brand/newbrand")]
        [HttpGet]
        public Brand NewStock()
        {
            return new Brand();
        }

        [Route("api/Brand/Save")]
        [HttpPost]
        public Brand SaveBrand(Brand _brand)
        {
            try
            {
                
                BrandDataController _gc = new BrandDataController();

              //  bool _ret = _dc.SaveStockById(_brand);
                _gc.SaveBrandById(_brand);
                return _brand;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Brand/deletebrand/{id}")]
        [HttpPost]
        public void DeleteBrand(int Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
            BrandDataController _gc = new BrandDataController();
            bool _ret = _gc.DeleteBrandById(Id);


        }
    }
}
