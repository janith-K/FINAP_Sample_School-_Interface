using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace FINAP_Sample.DataAccessLayer
{
    public class StudentDataService: IStudentDataService
    {
        IDataService dataService;

        public StudentDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<Student> Students()
        {
            try
            {
                List<Student> students = new List<Student>();
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetExistingStudents]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        students.Add(new Student
                        {
                            StudentID = dataReader.GetInt32("StudentID"),
                            FirstName = dataReader.GetString("FirstName"),                            
                            LastName = dataReader.GetString("LastName"),
                            ContactPerson = dataReader.GetString("ContactPerson"),
                            ContactNo = dataReader.GetString("ContactNo")
                        });
                    }
                    reader.Close();
                }

                return students;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Student GetStudent(int studentID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@StudentID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, studentID);

                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetStudentByID]", arrSqlParam);

                if (reader.HasRows && reader.Read())
                {
                    DataReader dataReader = new DataReader(reader);
                    var student = new Student
                    {
                        StudentID = dataReader.GetInt32("StudentID"),
                        FirstName = dataReader.GetString("FirstName"),
                        LastName = dataReader.GetString("LastName"),
                        ContactPerson = dataReader.GetString("ContactPerson"),
                        ContactNo = dataReader.GetString("ContactNo"),
                        //Email = dataReader.GetString("Email"),
                        //DOB = dataReader.GetString("DOB"),
                        //ClassroomID = dataReader.GetInt32("ClassroomID"),
                        //ClassroomName = dataReader.GetString("ClassroomName"),
                        //SubjectTeachers = new List<SubjectTeacher>()
                    };

                    //do
                    //{
                    //    student.SubjectTeachers.Add(new SubjectTeacher
                    //    {
                    //        SubjectID = dataReader.GetInt32("SubjectID"),
                    //        SubjectName = dataReader.GetString("SubjectName"),
                    //        TeacherID = dataReader.GetInt32("TeacherID"),
                    //        TeacherFirstName = dataReader.GetString("TeacherFirstName"),
                    //        TeacherLastName = dataReader.GetString("TeacherLastName")
                    //    });
                    //} while (reader.Read());

                    return student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveStudent(Student student)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[5];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@StudentID", System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput, student.StudentID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@FirstName", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.FirstName);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@LastName", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.LastName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@ContactPerson", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.ContactPerson);                
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@ContactNo", System.Data.DbType.String, System.Data.ParameterDirection.Input, student.ContactNo);                

                dataService.ExecuteNonQuery("[dbo].[SaveStudent]", arrSqlParam);                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteStudent(int studentID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@StudentID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, studentID);                

                dataService.ExecuteNonQuery("[dbo].[DeleteStudent]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
