using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SRY.TEST.BUSSINESS.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        protected BaseException()
        {
        }

        protected BaseException(string message) : base(message)
        {
        }

        protected BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public static class ExceptionExtensions
    {
        public static string GetAllMessages(this Exception exception)
        {
            var messages = exception.Message;
            if (exception.InnerException != null)
                messages += " " + exception.InnerException.GetAllMessages();
            return messages;
        }
    }
}
