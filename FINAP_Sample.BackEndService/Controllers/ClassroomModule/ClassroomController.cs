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
    public class ClassroomController : BaseController
    {
        [HttpGet]
        public APIResponce Classrooms()
        {
            try
            {
                ClassroomApplicationService objAS = new ClassroomApplicationService();
                var response = objAS.Classrooms();
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpPost]
        public APIResponce Classroom([FromBody] Classroom classroom)
        {
            try
            {
                ClassroomApplicationService objAS = new ClassroomApplicationService();
                objAS.SaveClassroom(classroom);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }


        [HttpDelete("{classroomID}")]
        public APIResponce Classroom(int classroomID)
        {
            try
            {
                ClassroomApplicationService objAS = new ClassroomApplicationService();
                objAS.DeleteClassroom(classroomID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
