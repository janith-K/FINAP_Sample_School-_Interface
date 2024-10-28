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
    public class StudentController : BaseController
    {
        [HttpGet]
        public APIResponce Students()
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                var response = objAS.Students();
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpGet("{studentID}")]
        public APIResponce GetStudent(int studentID)
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                var response = objAS.GetStudent(studentID);
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpPost]
        public APIResponce Student([FromBody] Student student)
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                objAS.SaveStudent(student);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        
        [HttpDelete("{studentID}")]
        public APIResponce Student(int studentID)
        {
            try
            {
                StudentApplicationService objAS = new StudentApplicationService();
                objAS.DeleteStudent(studentID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
