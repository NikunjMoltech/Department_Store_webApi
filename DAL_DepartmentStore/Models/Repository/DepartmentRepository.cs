using DAL_DepartmentStore.Entity.Tables;
using DAL_DepartmentStore.Models.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL_DepartmentStore.Models.Repository
{
    public class DepartmentRepository : IDepartment
    {
        protected readonly DbClass DbContext;

        public DepartmentRepository(DbClass dbContext)
        {
            DbContext = dbContext;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = DbContext.Department.ToList();
            return departments;
        }

        public List<Department> InsertDepartment(string DepartmentName)
        {
            List<Department> insertedDept = DbContext.InsertNewDepartmentByName.FromSqlRaw("exec.InsertNewDepartmentByName @DepartmentName",
                 new SqlParameter("@DepartmentName", DepartmentName)).ToList();
            return insertedDept;
        }
        public List<Department> UpdateDepartment(Department Department)
        {
            List<Department> updateDepartment = DbContext.UpdateDepartmentNameByIdName.FromSqlRaw("exec.UpdateDepartmentNameByIdName @Id, @Name",
                new SqlParameter("@Id", Department.DepartmentId),
                new SqlParameter("@Name", Department.DepartmentName)).ToList();
            return updateDepartment;

        }

        public List<Department> DeleteDepartment(int Id)
        {
            List<Department> deletedDept = DbContext.DeleteDepartmentById.FromSqlRaw("exec.DeleteDepartmentById @Id",
                 new SqlParameter("@Id", Id)).ToList();
            return deletedDept;
        }

    }
}
