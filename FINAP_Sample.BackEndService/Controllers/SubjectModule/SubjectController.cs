using FINAP_Sample.ApplicationServices;
using FINAP_Sample.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FINAP_Sample.BackEndService.Controllers
{
    /// <summary>
    /// ===================================================================
    /// Author  :   Dinushka Rukshan
    /// Remarks :   This is a sample controller with actions for 
    ///             getting existing records, Save records & Delete records
    /// ===================================================================
    /// </summary>
    [Route("[controller]/[action]")]
    public class SubjectController : BaseController
    {
        [HttpGet]
        public APIResponce Subjects()
        {
            try
            {
                SubjectApplicationService objAS = new SubjectApplicationService();
                var response = objAS.Subjects();
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpPost]
        public APIResponce Subject([FromBody] Subject subject)
        {
            try
            {
                SubjectApplicationService objAS = new SubjectApplicationService();
                objAS.SaveSubject(subject);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpDelete("{subjectID}")]
        public APIResponce Subject(int subjectID)
        {
            try
            {
                SubjectApplicationService objAS = new SubjectApplicationService();
                objAS.DeleteSubject(subjectID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
