using System;
using System.Linq;

namespace myPennyFarthing.Models
{
    public interface IRideRepository
    {
        //   C R E A T E
        public Ride Create(Ride r);


        //   R E A D
        public IQueryable<Ride> GetAllRides(int id);
        public Ride GetRideById(int id);


        //   U P D A T E
        public Ride Update(Ride r);


        //   D E L E T E
        public bool Delete(Ride r);
    }
}
