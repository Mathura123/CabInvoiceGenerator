using NUnit.Framework;
using CabInvoice;

namespace CabInvoiceGeneratorNUnitTest
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            int expected = 25;
            InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
            int result = invoiceGenetratorTestObj.CalculateFare(2, 5);
            Assert.AreEqual(expected,result);
        }
    }
}