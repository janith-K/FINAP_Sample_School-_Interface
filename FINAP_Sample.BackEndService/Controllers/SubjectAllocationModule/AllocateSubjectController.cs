using FINAP_Sample.ApplicationServices;
using FINAP_Sample.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FINAP_Sample.BackEndService.Controllers
{
    [Route("[controller]/[action]")]
    public class AllocateSubjectController : BaseController
    {
        [HttpGet("{teacherID}")]
        public APIResponce GetAllocatedSubjectsByTeachers(int teacherID)
        {
            try
            {
                AllocateSubjectApplicationService objAS = new AllocateSubjectApplicationService();
                var response = objAS.GetAllocatedSubjectsByTeacher(teacherID);
                return this.GenerateSucessMessage(response);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpPost]
        public APIResponce AllocateSubjectForTeacher([FromBody] AllocateSubject allocation)
        {
            try
            {
                AllocateSubjectApplicationService objAS = new AllocateSubjectApplicationService();
                objAS.AllocateSubjectForTeacher(allocation.TeacherID, allocation.SubjectID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }

        [HttpDelete("{allocateSubjectID}")]
        public APIResponce DeallocateSubjectForTeacher(int allocateSubjectID)
        {
            try
            {
                AllocateSubjectApplicationService objAS = new AllocateSubjectApplicationService();
                objAS.DeallocateSubjectForTeacher(allocateSubjectID);
                return this.GenerateSucessMessage(true);
            }
            catch (Exception ex)
            {
                return GenerateExceptionMessage(null, ex);
            }
        }
    }
}
