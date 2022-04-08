//@CodeCopy
//MdStart

namespace QTDrugPrescription.Logic.Modules.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException()
        {
        }

        public LogicException(string? message) : base(message)
        {
        }

        public LogicException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

//MdEnd
