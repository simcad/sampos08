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
    public class StockController : ApiController
    {
       

        [Route("api/Stock/search")]
        [HttpGet]
        public IEnumerable<Stock> SearchStocks(string searchText)
        {

            searchText = searchText ?? "";
             StockDataController _dc = new StockDataController();
            try
            {
                //DataSet  _cust = new DataSet ();

                var _stock = _dc.GetStockById(searchText).ToList();
                return _stock;
            }


            catch (Exception e)
            {


                string _my = samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }

        }

        [Route("api/stock/getbarcode")]
        [HttpGet]
        public string GetBarcode()
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

           // StockDataController _dc = new StockDataController();

          
                
            try
            {
                int bc = samposoapp.Utility.Utility.GetSequenceNumber("BC");
                string _barcode = bc.ToString("D8");
                return _barcode;
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling get barcode", e);
                return null;
            }



        }

        [Route("api/stock/detail/{id}/{barcode}")]
        [HttpGet]
        public List<StockModel> GetDetail(int id,string barcode)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);
            
            StockDataController _dc = new StockDataController();
            try
            {
                var _stock = _dc.GetStockId(id,barcode).ToList();
                return _stock;
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling GetDeatil - customer", e);
                return null;
            }



        }



        [Route("api/stock/brand/{id}")]
        [HttpGet]
        public IEnumerable<Brand> LoadBrand(string id)
        {
            //return db.Customers.FirstOrDefault(x => x.Id == Id);

            StockDataController _dc = new StockDataController();
            try
            {
                var _brand = _dc.LoadBrand(id).ToList();
                return _brand;
            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("calling Load brand  ", e);
                return null;
            }



        }

        [Route("api/Stock/new")]
        [HttpGet]
        public Stock NewStock()
        {
            return new Stock();
        }

        [Route("api/Stock/Save")]
        [HttpPost]
        public Stock SaveStock(Stock stock)
        {
            try
            {
                StockDataController _dc = new StockDataController();


                bool _ret = _dc.SaveStockById(stock);

                return stock;


            }
            catch (Exception e)
            {


                samposoapp.ErrorLog.ErrorLog.ccException("calling save", e);
                return null;
            }


        }




        //[Route("api/Stock/ByStockId/{Id}")]
        //public IEnumerable<Stock> GetStocks(int Id)
        //{
            
        //    StockDataController _dc = new StockDataController();

        //    try {
        //        var _stock = _dc.GetStockById(Id);
        //    return _stock;
        //    }
            
        //    catch (Exception e) {
        //        samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
        //        return null;
        //    }
            
            
            

        //}
    }
}
