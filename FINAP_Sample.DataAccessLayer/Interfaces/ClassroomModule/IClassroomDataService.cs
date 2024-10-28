using FINAP_Sample.BusinessObjects;
using System.Collections.Generic;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface IClassroomDataService
    {
        List<Classroom> Classrooms();

        void SaveClassroom(Classroom classroom);

        void DeleteClassroom(int classroomID);
    }
}
