using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class RideRepository
    {
        private Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public InvoiceSummary GetInvoice(string userId)
        {
            if (userRides.ContainsKey(userId))
                return InvoiceGenerator.CalculateFare(userRides[userId].ToArray());
            else
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rides == null)
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
            if (rideList)
            {
                userRides[userId].Clear();
                userRides[userId].AddRange(rides);
            }
            else
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }
    }
}
