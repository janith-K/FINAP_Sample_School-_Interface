using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace FINAP_Sample.DataAccessLayer
{
    public class SubjectDataService : ISubjectDataService
    {
        IDataService dataService;

        public SubjectDataService(IDataService _dataService)
        {
            dataService = _dataService;
        }

        public List<Subject> Subjects()
        {
            try
            {
                List<Subject> subjects = new List<Subject>();
                DbDataReader reader = dataService.ExecuteReader("[dbo].[GetExistingSubjects]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        subjects.Add(new Subject
                        {
                            SubjectID = dataReader.GetInt32("SubjectID"),
                            SubjectName = dataReader.GetString("SubjectName"),
                        });
                    }
                    reader.Close();
                }

                return subjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveSubject(Subject subject)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@SubjectID", System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput, subject.SubjectID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@SubjectName", System.Data.DbType.String, System.Data.ParameterDirection.Input, subject.SubjectName);
                
                dataService.ExecuteNonQuery("[dbo].[SaveSubject]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSubject(int subjectID)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[1];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@SubjectID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, subjectID);

                dataService.ExecuteNonQuery("[dbo].[DeleteSubject]", arrSqlParam);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
