using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        public double totalFare;
        private double averageFare;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

    }
}
