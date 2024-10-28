using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace FINAP_Sample.ApplicationServices
{
    public class SubjectApplicationService
    {
        public List<Subject> Subjects()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ISubjectDataService objDS = new SubjectDataService(dataService);
                return objDS.Subjects();
            }
            catch (Exception)
            {
                dataService.Dispose();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

        public void SaveSubject(Subject subject)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                ISubjectDataService objDS = new SubjectDataService(dataService);
                objDS.SaveSubject(subject);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally { dataService.Dispose(); }
        }

        public void DeleteSubject(int subjectID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                ISubjectDataService objDS = new SubjectDataService(dataService);
                objDS.DeleteSubject(subjectID);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally { dataService.Dispose(); }
        }
    }
}
