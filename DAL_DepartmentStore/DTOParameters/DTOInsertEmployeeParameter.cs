
namespace DAL_DepartmentStore.DTOParameters
{
    public class DTOInsertEmployeeParameter
    {
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
        public DateOnly? DateOfJoining { get; set; }
        public string? PhotoFileName { get; set; }
    }
}
