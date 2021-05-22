using System;
using System.Linq;

namespace myPennyFarthing.Models
{
    public interface IMXRepository
    {
        //   C R E A T E
        public MX Create(MX mx);


        //   R E A D
        public IQueryable<MX> GetAllMXs(int id);
        public MX GetMXById(int id);


        //   U P D A T E
        public MX Update(MX mx);


        //   D E L E T E
        public bool Delete(MX mx);
    }
}
