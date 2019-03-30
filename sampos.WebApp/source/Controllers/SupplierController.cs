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
    public class SupplierController : ApiController
    {
        // search function from main screen //

        [Route("api/Supplier/searchsupplier")]
        [HttpGet]
        public IEnumerable<Supplier> SearchSuppliers(string searchText)
        {

            searchText = searchText ?? "";
             SupplierDataController _dc = new SupplierDataController();
            try
            {
                //DataSet  _cust = new DataSet ();
                var _supplier = _dc.SearchSupplierById(searchText).ToList();
                
                return _supplier;
                
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }

        
        [Route("api/supplier/supplierdetail/{id}")]
        [HttpGet]
        public List<SupplierModel> GetDetail(int id)
        {
            
            
            SupplierDataController _dc = new SupplierDataController();

            try
            {
                
                var _supplier = _dc.GetSupplier(id).ToList();// GetBrandById(id).ToList();//          .GetStockId(id).ToList();
                return _supplier;
                
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - supplier", e);
                return null;
            }



        }



        
        [Route("api/Supplier/newsupplier")]
        [HttpGet]
        public Supplier NewStock()
        {
            return new Supplier();
        }

        [Route("api/Supplier/Save")]
        [HttpPost]
        public Supplier SaveBrand(Supplier _supplier)
        {
            try
            {
                
                SupplierDataController _gc = new SupplierDataController();

              //  bool _ret = _dc.SaveStockById(_supplier);
                _gc.SaveSupplierById(_supplier);
                return _supplier;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }


        // delete
        [Route("api/Supplier/deletesupplier/{id}")]
        [HttpPost]
        public void DeleteBrand(int Id)
        {
            // var customer = db.Customers.FirstOrDefault(x => x.CustomerId == Id);
            // db.Customers.Remove(customer);
            //db.SaveChanges();
            SupplierDataController _gc = new SupplierDataController();
            bool _ret = _gc.DeleteSupplierById(Id);


        }
    }
}
