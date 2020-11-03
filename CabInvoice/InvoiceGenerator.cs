using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        private readonly int minimumFare = 5;
        private double calculatedFare = 0;
        public double CalculateFare(double distanceInKM, int timeInMin)
        {
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
    }
}
