namespace CabInvoice
{
    using System;

    //Class to Invoice SUmmary
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
