using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FINAP_Sample.DataAccessLayer
{
    public class AllocateSubjectDataService: IAllocateSubjectDataService
    {
        IDataService dataService;

        public AllocateSubjectDataService(IDataService _dataservice)
        {
            dataService = _dataservice;

        }

        public List<AllocateSubject> GetAllocatedSubjectsByTeacher(int teacherID)
        {
            try
            {
                List<AllocateSubject> allocatedSubjects = new List<AllocateSubject>();
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, teacherID);
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetAllocatedSubjectsByTeacher]", arrSqlParam);

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        allocatedSubjects.Add(new AllocateSubject
                        {
                            AllocateSubjectID = dataReader.GetInt32("AllocateSubjectID"),
                            SubjectID = dataReader.GetInt32("SubjectID"),
                            SubjectName = dataReader.GetString("SubjectName")
                        });
                    }
                    reader.Close();
                }
                return allocatedSubjects;
            }
            catch(Exception) 
            {
                throw;
            }

        }

        public void AllocateSubjectForTeacher(int teacherID, int subjectID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@TeacherID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, teacherID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@SubjectID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, subjectID);

                dataService.ExecuteNonQuery("[dbo].[AllocateSubjectForTeacher]", arrSqlParam);

            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeallocateSubjectForTeacher(int allocateSubjectID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@AllocateSubjectID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, allocateSubjectID);

                dataService.ExecuteNonQuery("[dbo].[DeallocateSubjectForTeacher]", arrSqlParam);

            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
        
}
