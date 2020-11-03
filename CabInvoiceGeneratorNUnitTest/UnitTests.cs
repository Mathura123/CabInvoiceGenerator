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
    }
}