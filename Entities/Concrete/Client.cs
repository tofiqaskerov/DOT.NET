﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
    }
}
