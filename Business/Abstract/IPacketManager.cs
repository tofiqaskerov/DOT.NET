using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPacketManager
    {
        List<Packet> GetPackets();
        void Add(Packet packet);    
        Packet Get(int id);
        Packet GetByCategory(int id);
        void Remove(Packet packet);    
        void Update(Packet packet);
    }
}
