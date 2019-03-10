namespace EMAAR.ECM.Foundation.ErrorHandling.Pipelines.MvcException
{
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Pipelines.MvcEvents.Exception;
    using Sitecore.Web;

    public class ExceptionProcessor
    {
        log4net.ILog logger = Sitecore.Diagnostics.LoggerFactory.GetLogger("ECMLog");
        public void Process(ExceptionArgs exceptionArgs)
        {
            if (exceptionArgs.ExceptionContext.ExceptionHandled)
            {
                return;
            }

            this.HandleException(exceptionArgs.ExceptionContext);
        }

        protected virtual void HandleException(ExceptionContext exceptionContext)
        {
           
           logger.Error(exceptionContext.Exception.Message, exceptionContext.Exception);

           if (Settings.RequestErrors.UseServerSideRedirect)
            {
                HttpContext.Current.Server.TransferRequest("~/error");
            }
            else
                WebUtil.Redirect("~/error", false);
   
            
        }
    }
}