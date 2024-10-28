using FINAP_Sample.BusinessObjects;
using System.Collections.Generic;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface ISubjectDataService
    {
        List<Subject> Subjects();

        void SaveSubject(Subject subject);

        void DeleteSubject(int subjectID);
    }
}
