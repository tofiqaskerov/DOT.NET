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
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public void Add(Projects project)
        {
            _projectDal.Add(project);
        }

        public void Remove(Projects project)
        {
            _projectDal.Delete(project);    
        }

        public Projects Get(int id)
        {
            return _projectDal.Get(x => x.Id == id);
        }

        public List<Projects> GetAllProjects()
        {
            return _projectDal.GetAllProjects();
        }

        public Projects GetProjectsByCategory(int id)
        {
            return _projectDal.GetProjectsByCategory(id);
        }

        public void Update(Projects project)
        {
            _projectDal.Update(project);
        }
    }
}
