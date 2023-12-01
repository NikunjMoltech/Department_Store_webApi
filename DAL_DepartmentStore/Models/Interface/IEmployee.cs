using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;

namespace DAL_DepartmentStore.Models.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployee();
        public string InsertNewEmployee(DTOInsertEmployeeParameter emp);
        public string UpdateEmployee(Employee Department);
        public string DeleteEmployee(int Id);
    }
}
