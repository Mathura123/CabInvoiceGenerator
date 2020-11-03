using NUnit.Framework;
using CabInvoice;

namespace CabInvoiceGeneratorNUnitTest
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            double expected = 25;
            InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
            double result = invoiceGenetratorTestObj.CalculateFare(-2, 5);
            Assert.AreEqual(expected,result);
        }
    }
}