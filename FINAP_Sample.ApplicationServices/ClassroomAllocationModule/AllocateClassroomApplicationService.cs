using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FINAP_Sample.ApplicationServices
{
    public class AllocateClassroomApplicationService
    {
        public List<AllocateClassroom> GetAllocatedClassroomsByTeacher(int teacherID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IAllocateClassroomDataService objDS = new AllocateClassroomDataService(dataService);
                return objDS.GetAllocatedClassroomsByTeacher(teacherID);
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

        public void AllocateClassroomForTeacher(int teacherID, int classroomID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IAllocateClassroomDataService objDS = new AllocateClassroomDataService(dataService);
                objDS.AllocateClassroomForTeacher(teacherID, classroomID);

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

        public void DeallocateClassroomForTeacher(int allocateClassroomID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IAllocateClassroomDataService objDS = new AllocateClassroomDataService(dataService);
                objDS.DeallocateClassroomForTeacher(allocateClassroomID);

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
