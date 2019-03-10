using EMAAR.ECM.Foundation.ErrorHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMAAR.ECM.Foundation.ErrorHandling.Helpers
{
    public class LogManager :ILogManager
    {
        log4net.ILog logger = Sitecore.Diagnostics.LoggerFactory.GetLogger("ECMLog");
        public void Debug(string message, Exception exception)
        {
            logger.Debug(message, exception);
        }

      
        public void Error(string message, Exception exception)
        {         
            logger.Error(message, exception);
        }
               
        public void Info(string message, Exception exception)
        {
            logger.Info(message, exception);
        }
        public void Warn(string message, Exception exception)
        {
            logger.Warn(message, exception);
        }
    }
}