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
    public class AboutManager : IAboutManager
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Add(about);
        }

        public About Get(int id)
        {
            return _aboutDal.Get(x =>x.Id ==id);
        }

        public About GetFirst()
        {
            return _aboutDal.GetFirst();
        }

        public void Remove(About about)
        {
            _aboutDal.Delete(about);
        }

        public void Update(About about)
        {
             _aboutDal.Update(about);
        }
    }
}
