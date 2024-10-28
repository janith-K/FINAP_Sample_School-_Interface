using System;
using System.Collections.Generic;
using System.Text;
using FINAP_Sample.BusinessObjects;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface IAllocateSubjectDataService
    {
        List<AllocateSubject> GetAllocatedSubjectsByTeacher(int teacherID);
        void AllocateSubjectForTeacher(int teacherID, int subjectID);
        void DeallocateSubjectForTeacher(int allocateSubjectID);
    }
}
