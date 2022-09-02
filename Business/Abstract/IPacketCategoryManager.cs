using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPacketCategoryManager
    {
        List<PacketCategory> GetAll();
        void Add(PacketCategory packetCategory);
        void Update(PacketCategory packetCategory);
        void Remove(PacketCategory packetCategory); 
        PacketCategory Get(int id);
        
    }
}
