using Angularjs.UIRouting.WebApp.DataAccessLayer;
using Angularjs.UIRouting.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using samposoapp.Controllers;
namespace Angularjs.UIRouting.WebApp.Controllers
{
    public class ContactController : ApiController
    {
        DataContext db = new DataContext();
        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return db.Contacts;
        }

        public Contact Get(int id)
        {
            return db.Contacts.FirstOrDefault(x => x.ContactId == id);
        }

        [Route("api/Contact/ByCustomerId/{Id}")]
        public IEnumerable<Customer_detail> GetCustomerContacts(int Id)
        {
            CustomerDataController _dc = new CustomerDataController();

            try {
            var _customer_detail = _dc.GetCustomerDetailById(Id);
                return _customer_detail;
            }
            
            catch (Exception e) {
                samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);
                return null;
            }
            
            
            

        }
    }
}
