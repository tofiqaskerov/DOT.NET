using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ServicesDal : Core.DataAccess.EntityFramework.EfEntityRepositoryBase<Services, AppDbContext>, IServicesDal
    {
        public Services GetByIdWithCategory(int id)
        {
            using var _context = new AppDbContext();
            return _context.Services.Include(x => x.Category).FirstOrDefault(x=>x.Id == id);
        }

        public List<Services> GetServices()
        {
            using var _context = new AppDbContext();
            return _context.Services.Include(x => x.Category).ToList();
        }
    }
}
