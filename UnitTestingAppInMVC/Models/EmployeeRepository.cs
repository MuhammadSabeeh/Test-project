using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UnitTestingAppInMVC.Models
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {  
  
        EmployeeManagement context = new EmployeeManagement();

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeByID(int id)
        {
            return context.Employees.Find(id);
        }

        public void InsertEmployee(Employee emp)
        {
            context.Employees.Add(emp);
        }

        public void DeleteEmployee(int emp_ID)
        {
            Employee emp = context.Employees.Find(emp_ID);
            context.Employees.Remove(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            context.Entry(emp).State = EntityState.Modified;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}