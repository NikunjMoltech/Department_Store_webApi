using DAL_DepartmentStore.Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DepartmentStore.Models.Interface
{
    public interface IDepartment
    {
        public List<Department> GetAllDepartment();
        public List<Department> InsertDepartment(string DepartmentName);
        public List<Department> UpdateDepartment(Department Department);
        public List<Department> DeleteDepartment(int Id);
    }
}
