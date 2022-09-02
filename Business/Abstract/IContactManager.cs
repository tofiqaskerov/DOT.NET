using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactManager 
    {
        List<Contact> GetAll(); 
        Contact Get(int id);
        void Update(Contact contact);
        void Add(Contact contact);
        void Remove(Contact contact);
    }
}
