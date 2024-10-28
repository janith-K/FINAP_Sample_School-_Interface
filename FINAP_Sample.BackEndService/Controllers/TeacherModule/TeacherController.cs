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
    public class TeacherController : BaseController
    {
        [HttpGet]
        public APIResponce Teachers()
        {
            try
            {
                TeacherApplicationService objAS = new TeacherApplicationService();
                var response = objAS.Teachers();
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpPost]
        public APIResponce Teacher([FromBody] Teacher teacher)
        {
            try
            {
                TeacherApplicationService objAS = new TeacherApplicationService();
                objAS.SaveTeacher(teacher);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpDelete("{teacherID}")]
        public APIResponce Teacher(int teacherID)
        {
            try
            {
                TeacherApplicationService objAS = new TeacherApplicationService();
                objAS.DeleteTeacher(teacherID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
