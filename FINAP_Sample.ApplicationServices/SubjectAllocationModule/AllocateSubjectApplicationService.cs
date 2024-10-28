using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FINAP_Sample.ApplicationServices
{
    public class AllocateSubjectApplicationService
    {
        public List<AllocateSubject> GetAllocatedSubjectsByTeacher(int teacherID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IAllocateSubjectDataService objDS = new AllocateSubjectDataService(dataService);
                return objDS.GetAllocatedSubjectsByTeacher(teacherID);
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

        public void AllocateSubjectForTeacher(int teacherID, int subjectID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IAllocateSubjectDataService objDS = new AllocateSubjectDataService(dataService);
                objDS.AllocateSubjectForTeacher(teacherID, subjectID);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }

        }

        public void DeallocateSubjectForTeacher(int allocateSubjectID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IAllocateSubjectDataService objDS = new AllocateSubjectDataService(dataService);
                objDS.DeallocateSubjectForTeacher(allocateSubjectID);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally
            {
                dataService.Dispose();
            }
        }

    }
}
