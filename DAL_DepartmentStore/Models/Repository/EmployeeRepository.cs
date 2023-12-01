using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;
using DAL_DepartmentStore.Models.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DAL_DepartmentStore.Models.Repository
{
    public class EmployeeRepository : IEmployee
    {
        protected readonly DbClass DbContext;

        public EmployeeRepository(DbClass dbContext)
        {
            DbContext = dbContext;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = DbContext.GetAllEmployee.FromSqlRaw("exec GetAllEmployee").ToList();
            return employees;
        }

        public string InsertNewEmployee(DTOInsertEmployeeParameter employee)
        {
            var insert = DbContext.InsertNewEmployee.
                FromSqlRaw("exec InsertNewEmployee @Name,@Department,@DateOfJoining,@PhotoFileName",
                new SqlParameter("@Name", (object)employee.EmployeeName ?? DBNull.Value),
                new SqlParameter("@Department", (object)employee.Department ?? DBNull.Value),
                new SqlParameter("@DateOfJoining", (object)employee.DateOfJoining ?? DBNull.Value),
                new SqlParameter("@PhotoFileName", (object)employee.PhotoFileName ?? DBNull.Value)
            ).ToList();

            if (insert != null)
            {
                var result = insert.Select(info => info.Message).FirstOrDefault();
                return result;
            }
            return "insert Fail";
        }

        public string UpdateEmployee(Employee employee)
        {
            var update = DbContext.UpdateEmployeeById.
                FromSqlRaw("exec UpdateEmployeeById @Id, @Name,@Department,@DateOfJoining,@PhotoFileName",
                new SqlParameter("@Id",employee.EmployeeId),
                new SqlParameter("@Name", (object)employee.EmployeeName ?? DBNull.Value),
                new SqlParameter("@Department", (object)employee.Department ?? DBNull.Value),
                new SqlParameter("@DateOfJoining", (object)employee.DateOfJoining ?? DBNull.Value),
                new SqlParameter("@PhotoFileName", (object)employee.PhotoFileName ?? DBNull.Value)
                ).ToList();

            if(update != null)
            {
                var result = update.Select(info => info.Message).FirstOrDefault();
                return result;
            }
            return "Update Fail";
        }

        public string DeleteEmployee(int Id)
        {
            var deletedItem =DbContext.DeleteEmployeeById.FromSqlRaw("exec.DeleteEmployeeById @Id",
                    new SqlParameter("@Id", Id)).ToList();
            
            if (deletedItem != null)
            {
                var result = deletedItem.Select(info => info.Message).FirstOrDefault();
                return result;
            }
            return "Delete fail";
        }
    }
}
