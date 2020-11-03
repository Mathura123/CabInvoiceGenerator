using NUnit.Framework;
using CabInvoice;
using System;

namespace CabInvoiceGeneratorNUnitTest
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            double expected = 25;
            InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
            double result = invoiceGenetratorTestObj.CalculateFare(2, 5);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void GivenInvalidDistance_ShouldThrow_CabInvoiceException()
        {
            try
            {
                InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
                double result = invoiceGenetratorTestObj.CalculateFare(-2, 5);
            }
            catch(Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Distance");
            }
        }
        [Test]
        public void GivenInvalidTime_ShouldThrow_CabInvoiceException()
        {
            try
            {
                InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
                double result = invoiceGenetratorTestObj.CalculateFare(2, -5);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Time");
            }
        }
        [Test]
        public void GivenMultipleRides_ShouldReturn_TotalFare()
        {
            double expected = 30.0;
            Ride[] ridesTestObj = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
            InvoiceSummary result = invoiceGenetratorTestObj.CalculateFare(ridesTestObj);
            Assert.AreEqual(expected, result.totalFare);
        }
        [Test]
        public void GivenNullRides_ShouldThrow_CabInvoiceException()
        {
            try
            {
                Ride[] ridesTestObj = null;
                InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
                InvoiceSummary result = invoiceGenetratorTestObj.CalculateFare(ridesTestObj);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Rides Are Null");
            }
        }
    }
}