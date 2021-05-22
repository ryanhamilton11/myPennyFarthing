using System;
using System.Linq;

namespace myPennyFarthing.Models
{
    public interface IBikeRepository
    {
        //   C R E A T E
        public Bike Create(Bike b);


        //   R E A D
        public IQueryable<Bike> GetAllBikes();
        public Bike GetBikeById(int id);


        //   U P D A T E
        public Bike Update(Bike b);


        //   D E L E T E
        public bool Delete(int id);
    }
}
