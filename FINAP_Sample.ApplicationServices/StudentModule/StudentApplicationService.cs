using FINAP_Sample.BusinessObjects;
using FINAP_Sample.DataAccessLayer;
using FINAP_Sample.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace FINAP_Sample.ApplicationServices
{
    public class StudentApplicationService
    {
        public List<Student> Students()
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IStudentDataService objDS = new StudentDataService(dataService);
                return objDS.Students();
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

        public Student GetStudent(int studentID) 
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                IStudentDataService objDS = new StudentDataService(dataService);
                return objDS.GetStudent(studentID);
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

        public void SaveStudent(Student student)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IStudentDataService objDS = new StudentDataService(dataService);
                objDS.SaveStudent(student);

                dataService.CommitTransaction();                
            }
            catch (Exception)
            {
                dataService.RollbackTransaction();
                throw;
            }
            finally { dataService.Dispose(); }
        }

        public void DeleteStudent(int studentID)
        {
            IDataService dataService = DataServiceBuilder.CreateDataService();
            try
            {
                dataService.BeginTransaction();

                IStudentDataService objDS = new StudentDataService(dataService);
                objDS.DeleteStudent(studentID);

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
