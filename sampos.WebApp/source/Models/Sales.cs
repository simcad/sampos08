using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// data acccess
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Angularjs.UIRouting.WebApp.Models
{
    public class Sale
    {


    public string stock_sales_id {get;set;} //String '10
    public string stock_receipt_no {get;set;}// String '10
    public string stock_flag {get;set;} //String //'1
    public string stock_sales_date {get;set;}// String //'Date
    public string stock_sales_type {get;set;}// String '2
    public string stock_reference {get;set;}// String '10
    public string customer_name {get;set;}// String '125
    public string customer_sex {get;set;} //String '1
    public string stock_sales_remark {get;set;}// String '40
    public Single stock_sales_total {get;set;}// Single
    public Single stock_sales_cash {get;set;}
    public Double stock_sales_creditcard {get;set;} 
    public String stock_sales_creditcard_type {get;set;} // '3
    public Single stock_sales_cheque {get;set;} 
    public Single stock_sales_balance {get;set;} //Single
    public string stock_sales_3 {get;set;} //String '3
    public string user_id {get;set;} //String '8
    public string commission_id {get;set;}// String '3
    public Single stock_sales_payment {get;set;} //Decimal 'String '1
    public string g_user_id {get;set;}// String '5
    public string stock_sales_period {get;set;}// String '6
    public long customer_id {get;set;} //Long
    public string stock_sales_time {get;set;} //String '8
    public Single tax_rate {get;set;} //Single
    public int tax_rate_id {get;set;} //Integer
    public bool tax_yesno {get;set;}//Boolean
    public string tax_file_no {get;set;}// String '100
    public Single stock_sales_withTax {get;set;} //Single
    public Single gst {get;set;}// Single
    public String purchase_order {get;set;}// String '20
    public long SalesId {get;set;} //Long
    public Single rounding {get;set;} //Single



        //public String stock_sales_id { get; set; }
        //public String stock_receipt_no { get; set; }
        //public String stock_flag { get; set; }
        //public String stock_sales_date { get; set; }
        //public String stock_sales_type { get; set; }
        //public String stock_reference { get; set; }
        //public String customer_name { get; set; }
        //public String customer_sex { get; set; }
        //public String stock_sales_remark { get; set; }
        //public Single stock_sales_total { get; set; }
        //public Single stock_sales_cash { get; set; }
        //public Single stock_sales_creditcard { get; set; }
        //public String stock_sales_creditcard_type { get; set; }
        //public Single stock_sales_cheque { get; set; }
        //public Single stock_sales_balance { get; set; }
        //public String stock_sales_3 { get; set; }
        //public String user_id { get; set; }
        //public String commission_id { get; set; }
        //public Single stock_sales_payment { get; set; }
        //public String g_user_id { get; set; }
        //public String stock_sales_period { get; set; }
        //public int customer_id { get; set; }
        //public String stock_sales_time { get; set; }
        //public String tax_rate { get; set; }
        //public int tax_rate_id { get; set; }
        //public int tax_yesno { get; set; }
        //public String tax_file_no { get; set; }
        //public Single stock_sales_withTax { get; set; }
        //public Single gst { get; set; }
        //public String purchase_order { get; set; }
        //public int sales_Id { get; set; }
        //public int roundingadj { get; set; }
        public int upsize_ts { get; set; }


    }

    public class SaleDetails
    {
        public String stock_sales_id { get; set; }
        public int stock_sales_detail_id { get; set; }
        public String stock_sales_code { get; set; }
        public Single stock_quantity { get; set; }
        public String barcode { get; set; }
        public String stock_sales_type { get; set; }
        public Single stock_sale_price { get; set; }
        public String group_id { get; set; }
        public String discount { get; set; }
        public String tax_rate { get; set; }
        public int tax_rate_id { get; set; }
        public int tax_yesno { get; set; }
        public String tax_file_no { get; set; }
        public String gst { get; set; }
        public int sales_id { get; set; }
        public int upsize_ts { get; set; }

    }


    public class SalesModel
    {
        public Sale _sale { get; set; }
        public List<Sale> _SaleList { get; set; }
    }
}