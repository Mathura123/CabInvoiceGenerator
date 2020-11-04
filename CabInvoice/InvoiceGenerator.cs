using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        private static int CHARGE_PER_KM;
        private static int CHARGE_PER_MIN;
        private static int MINIMUM_FARE;

        public static double CalculateFare(double distanceInKM, int timeInMin, RideType rideType)
        {
            SetCharges(rideType);
            double calculatedFare = 0;
            if (distanceInKM <= 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
            }
            if (timeInMin < 0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            calculatedFare = (CHARGE_PER_KM * distanceInKM) + (CHARGE_PER_MIN * timeInMin);
            return Math.Max(calculatedFare, MINIMUM_FARE);
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
                totalFare += CalculateFare(ride.distance, ride.time, ride.rideType);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        private static void SetCharges(RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL))
            {
                CHARGE_PER_KM = 10;
                CHARGE_PER_MIN = 1;
                MINIMUM_FARE = 5;
            }
            else if (rideType.Equals(RideType.PREMIUM))
            {
                CHARGE_PER_KM = 15;
                CHARGE_PER_MIN = 2;
                MINIMUM_FARE = 20;
            }
            else
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
        }
    }
}
