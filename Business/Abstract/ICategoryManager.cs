using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        List<Category> GetAll();
        void Remove(Category category);
        void Add(Category category);
        Category Get(int id);
        void Update(Category category);
    }
}
