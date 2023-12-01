
using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL_DepartmentStore
{
    public class DbClass : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Department> InsertNewDepartmentByName { get; set; }
        public DbSet<Department> UpdateDepartmentNameByIdName { get; set; }
        public DbSet<Department> DeleteDepartmentById { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee> GetAllEmployee { get; set; }
        public DbSet<DTOStringMessage> InsertNewEmployee { get; set; }
        public DbSet<DTOStringMessage> UpdateEmployeeById { get; set; }
        public DbSet<DTOStringMessage> DeleteEmployeeById { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Registration> RegiserUserByData { get; set; }
        public DbSet<DTOResponse> AuthenticateUserByData { get; set; }

        public DbClass() { }
        public DbClass(DbContextOptions<DbClass> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this here map dateOnly with db
            var converter = new ValueConverter<DateOnly, DateTime>(
            v => v.ToDateTime(new TimeOnly(0, 0)),
            v => DateOnly.FromDateTime(v.Date));

/*            modelBuilder.Entity<Employee>().HasNoKey();
*/
            modelBuilder
                .Entity<Employee>().HasNoKey()
                .Property(e => e.DateOfJoining)
                .HasConversion(converter);


            modelBuilder.Entity<Department>().HasNoKey();
            modelBuilder.Entity<DTOStringMessage>().HasNoKey();
            modelBuilder.Entity<Registration>().HasNoKey();




        }
    }
}
