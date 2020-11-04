namespace CabInvoice
{
    using System;

    //Custom exception class
    class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID,
            INVALID_RIDE_TYPE
        }
        private ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
