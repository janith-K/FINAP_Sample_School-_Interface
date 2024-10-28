using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace FINAP_Sample.ApplicationServices
{
    public class TeacherApplicationService
    {
        public List<Teacher> Teachers()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                ITeacherDataService objDS = new TeacherDataService(dataService);
                return objDS.Teachers();
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

        public void SaveTeacher(Teacher teacher)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                ITeacherDataService objDS = new TeacherDataService(dataService);
                objDS.SaveTeacher(teacher);

                dataService.CommitTransaction();
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally { dataService.Dispose(); }
        }

        public void DeleteTeacher(int teacherID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                ITeacherDataService objDS = new TeacherDataService(dataService);
                objDS.DeleteTeacher(teacherID);

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
