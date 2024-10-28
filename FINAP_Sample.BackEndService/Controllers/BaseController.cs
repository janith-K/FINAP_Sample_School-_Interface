using FINAP_Sample.BusinessObjects;
using FINAP_Sample.LoggerService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace FINAP_Sample.BackEndService.Controllers
{
    /// <summary>
    /// =============================================================================
    /// Author  :   Dinushka Rukshan
    /// Remarks :   This is a basic base controller with methods for
    ///             generate success & exception API responces & write exception logs
    /// =============================================================================
    /// </summary>
    [EnableCors("AllowSpecificOrigin")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        public APIResponce GenerateSucessMessage(object result)
        {            
            APIResponce responce = new APIResponce(result, HttpStatusCode.OK, null);            
            return responce;
        }

        public APIResponce GenerateExceptionMessage(object result, Exception ex)
        {            
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;                        
            APIResponce responce = new APIResponce(result, httpStatusCode, ex.Message.ToString());

            ExceptionMessageLog(ex, LogService.LoggerLevel.Error);

            return responce;
        }

        private void ExceptionMessageLog(Exception exception, LogService.LoggerLevel messageLevel)
        {            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();            

            sb.Append("ErroMessage : " + exception.Message + "\r\n");
            sb.Append("Stack Trace : " + exception.StackTrace + "\r\n");            

            LogService.WriteLogMessage(sb.ToString(), messageLevel);
        }
    }
}