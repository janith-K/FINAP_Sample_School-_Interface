using FINAP_Sample.BusinessObjects;
using System.Collections.Generic;

namespace FINAP_Sample.DataAccessLayer.Interfaces
{
    public interface IStudentDataService
    {
        List<Student> Students();

        void SaveStudent(Student student);

        void DeleteStudent(int studentID);
        Student GetStudent(int studentID);
    }
}
