using System;
using System.Collections.Generic;
using System.Text;
using FINAP_Sample.BusinessObjects;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface IAllocateClassroomDataService
    {
        List<AllocateClassroom> GetAllocatedClassroomsByTeacher(int teacherID);
        void AllocateClassroomForTeacher(int teacherID, int classroomID);
        void DeallocateClassroomForTeacher(int allocateClassroomID);
    }
}
