using JopOffers.Models;
using JopOffers.Models.Data;
using JopOffers.Models.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
// 200 -> Success 
// 404 -> not found 
// 400 -> validation  
// 500 ->internal Server error
//postman to test api   

namespace JopOffers.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly AppDbContext db;
        public ContactsController( IUnitOfWork _context, AppDbContext db)
        {
            this._context = _context;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Contact> GetContact()
        {

            return _context.Contacts.GetAllData();
            
        }
        [HttpGet("{id}")]
        public Contact Find(int id)
        {
            return _context.Contacts.GetDataById(id);
        }

        [HttpPost]
        public void Save(Contact c)
        {
            _context.Contacts.Add(c);

        }
        [HttpPut]
        public void Edit(Contact c)
        {
            _context.Contacts.Update(c);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var x= db.Contacts.Find(id);
            _context.Contacts.Delete(x);
        }
    }
}
