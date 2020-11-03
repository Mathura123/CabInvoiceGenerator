using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
        }
        private ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
