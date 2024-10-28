using FINAP_Sample.BusinessObjects;
using System.Collections.Generic;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface ITeacherDataService
    {
        List<Teacher> Teachers();

        void SaveTeacher(Teacher teacher);

        void DeleteTeacher(int teacherID);
    }
}
