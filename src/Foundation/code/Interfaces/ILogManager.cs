using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAAR.ECM.Foundation.ErrorHandling.Interfaces
{
    interface ILogManager
    {
        void Debug(string message, Exception exception);
        void Info(string message, Exception exception);
        void Warn(string message, Exception exception);
        void Error(string message, Exception exception);
       
    }
}
