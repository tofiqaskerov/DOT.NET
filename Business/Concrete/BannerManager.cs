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
    public class BannerManager : IBannerManager
    {
        private readonly IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void Add(Banner banner)
        {
            _bannerDal.Add(banner); 
        }

        public Banner Get(int id)
        {
            return _bannerDal.Get(x =>x.Id ==id);
        }

        public Banner GetFirst()
        {
            return _bannerDal.GetFirst();
        }

        public void Remove(Banner banner)
        {
            _bannerDal.Delete(banner);
        }

        public void Update(Banner banner)
        {
            _bannerDal.Update(banner);
        }
    }
}
