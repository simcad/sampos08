using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Angularjs.UIRouting.WebApp.Models
{
    public class Customer
    {
        //[Key]
        //public int CustomerId { get; set; }
        //[Required]
        //public string FullName { get; set; }
        //[Required]
        //public string Address { get; set; }
        //[Required]
        //public string City { get; set; }
        //[Required]
        //public string ZipCode { get; set; }
        //[Required]
        //public string Country { get; set; }
        //public string Image { get; set; }


            public int customer_id { get; set; }
            public string name { get; set; }
            public string company_Name { get; set; }
            public string ic_no { get; set; }
            public Nullable<System.DateTime> last_visit_date { get; set; }
            public string address { get; set; }
            public string district { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
            public string country { get; set; }
            public string race_id { get; set; }
            public string sex { get; set; }
            public Nullable<System.DateTime> birth_date { get; set; }
            public Nullable<int> occupation_id { get; set; }
            public string h_phone { get; set; }
            public string b_phone { get; set; }
            public string m_phone { get; set; }
            public string income_range_id { get; set; }
            public string c_note { get; set; }
            public string taxABN { get; set; }
            public string e_mail { get; set; }
            public string company_id { get; set; }
            public Nullable<float> c_index { get; set; }
            public Nullable<int> c_type { get; set; }
            public string dl_add1 { get; set; }
            public string dl_city { get; set; }
            public string dl_postcode { get; set; }
            public string dl_state { get; set; }
            public int Id { get; set; }
         
       
    }
    

    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }

    public class Customer_detail
    {

        public int customer_detail_id { get; set; }  // key
        public int customer_id { get; set; }   // required
        public DateTime customer_detail_date { get; set; }
        public string sales_type { get; set; }
        public string reference { get; set; }
        public string rx_r_sp { get; set; }
        public string rx_r_cy { get; set; }
        public string rx_r_ax { get; set; }
        public string rx_r_va { get; set; }
        public string rx_l_sp { get; set; }
        public string rx_l_cy { get; set; }
        public string rx_l_ax { get; set; }
        public string rx_l_va { get; set; }
        public string dist_r_sp { get; set; }
        public string dist_r_cy { get; set; }
        public string dist_r_ax { get; set; }
        public string dist_r_va { get; set; }
        public string dist_l_sp { get; set; }
        public string dist_l_cy { get; set; }
        public string dist_l_ax { get; set; }
        public string dist_l_va { get; set; }
        public string reading_r_sp { get; set; }
        public string reading_r_cy { get; set; }
        public string reading_r_ax { get; set; }
        public string reading_r_va { get; set; }
        public string reading_l_sp { get; set; }
        public string reading_l_cy { get; set; }
        public string reading_l_ax { get; set; }
        public string reading_l_va { get; set; }
        public string kreading_r_h { get; set; }
        public string kreading_r_v { get; set; }
        public string kreading_l_h { get; set; }
        public string kreading_l_v { get; set; }
        public string s_frame { get; set; }
        public string lense { get; set; }
        public string pd_cd { get; set; }
        public string pd_hg { get; set; }
        public string sg_hg { get; set; }
        public string pd_cd_R { get; set; }
        public string pd_hg_R { get; set; }
        public string sg_hg_R { get; set; }
        public string fee { get; set; }
        public string dist_r_add { get; set; }
        public string dist_l_add { get; set; }
        public string rx_r_add { get; set; }
        public string rx_l_add { get; set; }
        public string remark_1 { get; set; }
        public string remark_2 { get; set; }
        public string basecurve { get; set; }
        public string basecurve_R { get; set; }
        public string power { get; set; }
        public string sp_text1 { get; set; }
        public string sp_text2 { get; set; }
        public string fee_l { get; set; }
        public string fee_cl { get; set; }
        public string C_BC_R { get; set; }
        public string C_DIA_R { get; set; }
        public string C_SPH_R { get; set; }
        public string C_CYL_R { get; set; }
        public string C_AXL_R { get; set; }
        public string C_ADD_R { get; set; }
        public string C_BC_L { get; set; }
        public string C_DIA_L { get; set; }
        public string C_SPH_L { get; set; }
        public string C_CYL_L { get; set; }
        public string C_AXL_L { get; set; }
        public string C_ADD_L { get; set; }
        public string kreading_r_mm { get; set; }
        public string kreading_l_mm { get; set; }
        public string kreading_r_diopter { get; set; }
        public string kreading_l_diopter { get; set; }
        public string rx_r_PrismDist { get; set; }
        public string rx_l_PrismDist { get; set; }
        public string dist_r_PrismDist { get; set; }
        public string dist_l_PrismDist { get; set; }
        public string upsize_ts { get; set; }

    }
}