using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public int RolesId { get; set; }
        public Roles Roles { get; set; }

    }
}
