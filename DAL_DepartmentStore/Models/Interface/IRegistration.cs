
using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;

namespace DAL_DepartmentStore.Models.Interface
{
    public interface IRegistration
    {
        public List<Registration> RegisterUser(DTORegister registration);
        public List<DTOLogin> AuthoriseUser(DTOLogin data);
    }
}
