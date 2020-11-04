using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        private static readonly int minimumFare = 5;
        public static double CalculateFare(double distanceInKM, int timeInMin)
        {
            double calculatedFare = 0;
            if (distanceInKM <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
            }
            if (timeInMin < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            calculatedFare = (10 * distanceInKM) + timeInMin;
            return Math.Max(calculatedFare, minimumFare);
        }
        public static InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            if (rides == null)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
            }
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance,ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}
