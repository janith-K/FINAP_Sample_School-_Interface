using FINAP_Sample.ApplicationServices;
using FINAP_Sample.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FINAP_Sample.BackEndService.Controllers
{
    [Route("[controller]/[action]")]
    public class AllocateClassroomController : BaseController
    {
        [HttpGet("{teacherID}")]
        public APIResponce GetAllocatedClassroomsByTeachers(int teacherID)
        {
            try
            {
                AllocateClassroomApplicationService objAS = new AllocateClassroomApplicationService();
                var response = objAS.GetAllocatedClassroomsByTeacher(teacherID);
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpPost]
        public APIResponce AllocateClassroomForTeacher([FromBody] AllocateClassroom allocation)
        {
            try
            {
                AllocateClassroomApplicationService objAS = new AllocateClassroomApplicationService();
                objAS.AllocateClassroomForTeacher(allocation.TeacherID, allocation.ClassroomID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpDelete("{allocateClassroomID}")]
        public APIResponce DeallocateClassroomForTeacher(int allocateClassroomID)
        {
            try
            {
                AllocateClassroomApplicationService objAS = new AllocateClassroomApplicationService();
                objAS.DeallocateClassroomForTeacher(allocateClassroomID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
