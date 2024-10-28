using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace FINAP_Sample.ApplicationServices
{
    public class ClassroomApplicationService
    {
        public List<Classroom> Classrooms()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IClassroomDataService objDS = new ClassroomDataService(dataService);
                return objDS.Classrooms();
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

        public void SaveClassroom(Classroom classroom)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IClassroomDataService objDS = new ClassroomDataService(dataService);
                objDS.SaveClassroom(classroom);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally { dataService.Dispose(); }
        }

        public void DeleteClassroom(int classroomID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IClassroomDataService objDS = new ClassroomDataService(dataService);
                objDS.DeleteClassroom(classroomID);

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
