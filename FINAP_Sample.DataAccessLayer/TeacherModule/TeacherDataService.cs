using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace FINAP_Sample.DataAccessLayer
{
    public class TeacherDataService : ITeacherDataService
    {
        IDataService dataService;

        public TeacherDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<Teacher> Teachers()
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetExistingTeachers]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        teachers.Add(new Teacher
                        {
                            TeacherID = dataReader.GetInt32("TeacherID"),
                            FirstName = dataReader.GetString("FirstName"),
                            LastName = dataReader.GetString("LastName"),
                            ContactNo = dataReader.GetString("ContactNo"),
                            Email = dataReader.GetString("Email")
                        });
                    }
                    reader.Close();
                }

                return teachers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveTeacher(Teacher teacher)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[5];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput, teacher.TeacherID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@FirstName", System.Data.DbType.String, System.Data.ParameterDirection.Input, teacher.FirstName);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@LastName", System.Data.DbType.String, System.Data.ParameterDirection.Input, teacher.LastName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@ContactNo", System.Data.DbType.String, System.Data.ParameterDirection.Input, teacher.ContactNo);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@Email", System.Data.DbType.String, System.Data.ParameterDirection.Input, teacher.Email);


                dataService.ExecuteNonQuery("[dbo].[SaveTeacher]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTeacher(int teacherID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, teacherID);

                dataService.ExecuteNonQuery("[dbo].[DeleteTeacher]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
