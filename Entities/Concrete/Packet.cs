using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Packet : IEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int PacketCategoryId { get; set; }
        public PacketCategory PacketCategory { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Description_1 { get; set; }
        public string Description_2 { get; set; }
    }
}
