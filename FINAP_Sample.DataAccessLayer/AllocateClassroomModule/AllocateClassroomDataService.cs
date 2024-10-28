using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FINAP_Sample.DataAccessLayer
{
    public class AllocateClassroomDataService : IAllocateClassroomDataService
    {
        IDataService dataService;

        public AllocateClassroomDataService(IDataService _dataservice)
        {
            dataService = _dataservice;

        }

        public List<AllocateClassroom> GetAllocatedClassroomsByTeacher(int teacherID)
        {
            try
            {
                List<AllocateClassroom> allocatedClassrooms = new List<AllocateClassroom>();
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, teacherID);
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetAllocatedClassroomsByTeacher]", arrSqlParam);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        allocatedClassrooms.Add(new AllocateClassroom
                        {
                            AllocateClassroomID = dataReader.GetInt32("AllocateClassroomID"),
                            ClassroomID = dataReader.GetInt32("ClassroomID"),
                            ClassroomName = dataReader.GetString("ClassroomName")
                        });
                    }
                    reader.Close();
                }
                return allocatedClassrooms;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void AllocateClassroomForTeacher(int teacherID, int classroomID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, teacherID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@ClassroomID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, classroomID);

                dataService.ExecuteNonQuery("[dbo].[AllocateClassroomForTeacher]", arrSqlParam);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeallocateClassroomForTeacher(int allocateClassroomID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@AllocateClassroomID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, allocateClassroomID);

                dataService.ExecuteNonQuery("[dbo].[DeallocateClassroomForTeacher]", arrSqlParam);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
