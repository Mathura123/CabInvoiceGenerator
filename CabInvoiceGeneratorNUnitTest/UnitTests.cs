using CabInvoice;
using NUnit.Framework;
using System;

namespace CabInvoiceGeneratorNUnitTest
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            double expected = 25;
            double result = InvoiceGenerator.CalculateFare(2, 5, RideType.NORMAL);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GivenInvalidDistance_ShouldThrow_CabInvoiceException()
        {
            try
            {
                double result = InvoiceGenerator.CalculateFare(-2, 5, RideType.NORMAL);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Distance");
            }
        }
        [Test]
        public void GivenInvalidTime_ShouldThrow_CabInvoiceException()
        {
            try
            {
                double result = InvoiceGenerator.CalculateFare(2, -5, RideType.NORMAL);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Time");
            }
        }
        [Test]
        public void GivenMultipleRides_ShouldReturn_InvoiceSummary()
        {
            double expected = 45.0;
            Ride[] ridesTestObj = { new Ride(2.0, 5, RideType.NORMAL), new Ride(0.1, 1, RideType.PREMIUM) };
            InvoiceSummary result = InvoiceGenerator.CalculateFare(ridesTestObj);
            Assert.AreEqual(expected, result.totalFare);
        }
        [Test]
        public void GivenNullRides_ShouldThrow_CabInvoiceException()
        {
            try
            {
                Ride[] ridesTestObj = null;
                InvoiceSummary result = InvoiceGenerator.CalculateFare(ridesTestObj);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Rides Are Null");
            }
        }
        [Test]
        public void GivenUserId_ThatIsNotAdded_RideRepository_ShouldThrow_CabInvoiceException()
        {
            try
            {
                RideRepository rideRepoTestObj = new RideRepository();
                InvoiceSummary result = rideRepoTestObj.GetInvoice("user1");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid UserID");
            }
        }
        [Test]
        public void GivenUserId_RideRepository_ShouldReturn_InvoiceSummary()
        {
            double expected = 206;
            Ride[] rides = { new Ride(0.1, 2, RideType.PREMIUM), new Ride(0.1, 10, RideType.NORMAL), new Ride(5, 50, RideType.PREMIUM) };
            RideRepository rideRepoTestObj = new RideRepository();
            rideRepoTestObj.AddRide("user1", rides);
            InvoiceSummary result = rideRepoTestObj.GetInvoice("user1");
            Assert.AreEqual(expected, result.totalFare);
        }
        [Test]
        public void GivenUserId_AndNullRides_RideRepository_ShouldThrow_CabInvoiceException()
        {
            try
            {
                Ride[] rides = null;
                RideRepository rideRepoTestObj = new RideRepository();
                rideRepoTestObj.AddRide("user1", rides);
                InvoiceSummary result = rideRepoTestObj.GetInvoice("user1");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Rides Are Null");
            }
        }
    }
}