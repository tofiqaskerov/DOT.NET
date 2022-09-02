using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPacketDal : IEntityRepository<Packet>
    {
        List<Packet> GetPackets();
        Packet GetByCategory(int id);
    }
}
