using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactManager
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public Contact Get(int id)
        {
           return _contactDal.Get(x =>x.Id == id);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public void Remove(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
