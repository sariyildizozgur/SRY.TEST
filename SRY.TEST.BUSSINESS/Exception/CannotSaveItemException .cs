using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRY.TEST.BUSSINESS.Exceptions
{
    class CannotSaveItemException:BaseException
    {
        #region Fields

        public const string DefaultMessage = "Belirtilen öğe saklanamıyor : ";

        #endregion

        #region Constructors

        public CannotSaveItemException()
            : base(DefaultMessage)
        {
        }

        public CannotSaveItemException(string message)
            : base(DefaultMessage + "\n" + message)
        {
        }

        public CannotSaveItemException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
        }

        public CannotSaveItemException(string message, Exception innerException)
            : base(DefaultMessage + "\n" + message, innerException)
        {
        }

        #endregion
    }
}
