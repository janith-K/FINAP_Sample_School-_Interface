using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace FINAP_Sample.DataAccessLayer
{
    public class ClassroomDataService : IClassroomDataService
    {
        IDataService dataService;

        public ClassroomDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<Classroom> Classrooms()
        {
            try
            {
                List<Classroom> classrooms = new List<Classroom>();
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetExistingClassrooms]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        classrooms.Add(new Classroom
                        {
                            ClassroomID = dataReader.GetInt32("ClassroomID"),
                            ClassroomName = dataReader.GetString("ClassroomName")
                            
                        });
                    }
                    reader.Close();
                }

                return classrooms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveClassroom(Classroom classroom)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@ClassroomID", System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput, classroom.ClassroomID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@ClassroomName", System.Data.DbType.String, System.Data.ParameterDirection.Input, classroom.ClassroomName);
     

                dataService.ExecuteNonQuery("[dbo].[Saveclassroom]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteClassroom(int classroomID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@classroomID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, classroomID);

                dataService.ExecuteNonQuery("[dbo].[Deleteclassroom]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
