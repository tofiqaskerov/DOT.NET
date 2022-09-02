using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class TeamDal : EfEntityRepositoryBase<Team, AppDbContext>, ITeamDal
    {
        public Team GetTeam(int id)
        {
            using var _context = new AppDbContext();    
            var team = _context.Teams.Include(x =>x.Roles).FirstOrDefault(t =>t.Id == id);
            return team;
        }

        public List<Team> GetTeams()
        {
            using var _context = new AppDbContext();
            var teams = _context.Teams.Include(x => x.Roles).ToList();
            return teams;
        }
    }
}
