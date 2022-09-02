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
    public class ProjectDal : EfEntityRepositoryBase<Projects, AppDbContext>, IProjectDal
    {
        public List<Projects> GetAllProjects()
        {
            using var _context = new AppDbContext();
            return _context.Projects.Include(x =>x.Category).ToList();

        }

        public Projects GetProjectsByCategory(int id)
        {
            using var _context = new AppDbContext();
            var project = _context.Projects.Include(x =>x.Category).FirstOrDefault(x => x.Id == id);
            return project;
        }
    }
}
