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

using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using samposoapp.ErrorLog;

namespace samposoapp.Controllers
{
    public class SaleController : ApiController
    {

        //[Route("api/Sale/mytest")]
        //[HttpGet]
        //public HttpResponseMessage Mytest(string id)
        //{
        //    return Request.CreateResponse<string>(HttpStatusCode.OK, id);
        //}

        [Route("api/Sale/searchsale")]
        
        [HttpGet]
        public List<SalesModel>Searchsale(string searchText)
        {

           searchText = searchText ?? "";
            
         
            try
            {
                

                SaleDataController _dc = new SaleDataController();
                var _sales = _dc.GetSale(searchText); 
                return _sales;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }
    }
}