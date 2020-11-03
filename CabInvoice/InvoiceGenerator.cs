using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        public int CalculateFare(int distanceInKM, int timeInMin)
        {
            int cost = (10 * distanceInKM) + timeInMin;
            int minimumFare = 5;
            return Math.Max(cost, minimumFare);
        }
    }
}
