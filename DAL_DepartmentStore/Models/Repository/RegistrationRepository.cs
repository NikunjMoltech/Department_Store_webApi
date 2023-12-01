using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;
using DAL_DepartmentStore.Models.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DepartmentStore.Models.Repository
{
    public class RegistrationRepository : IRegistration
    {
        private readonly DbClass context;
        public RegistrationRepository(DbClass dbContext) 
        {
            context = dbContext;
        }

        public List<DTOLogin> AuthoriseUser(DTOLogin data)
        {
            List<DTOResponse> authentication = context.AuthenticateUserByData
                .FromSqlRaw("exec AuthenticateUserByData @Email, @Password",
                new SqlParameter("@Email", data.Email),
                new SqlParameter("@Password", data.Password)).ToList();

            throw new NotImplementedException();
        }

        public List<Registration> RegisterUser(DTORegister registration)
        {
            List<Registration> registered = context.RegiserUserByData
                .FromSqlRaw("exec RegiserUserByData @Email, @Password, @Name",
                new SqlParameter("@Email", registration.Email),
                new SqlParameter("@Password", registration.Password),
                new SqlParameter("@Name", registration.Name)).ToList();

            if(registered != null) 
            {
                return registered;
            }

            throw new Exception("Operation fail");
        }
    }
}
