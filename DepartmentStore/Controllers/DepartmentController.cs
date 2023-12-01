using DAL_DepartmentStore;
using DAL_DepartmentStore.Entity.Tables;
using DAL_DepartmentStore.Models.Interface;
using DAL_DepartmentStore.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DbClass dbContext;
        IDepartment department;
        public DepartmentController(DbClass repoContext)
        {
            dbContext = repoContext;    
            department = new DepartmentRepository(dbContext);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("allDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                List<Department> allDepartment = department.GetAllDepartment();

                if (allDepartment != null)
                {
                    return Ok(allDepartment);
                }

                return Ok("No data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("insertDepartment")]
        public async Task<IActionResult> InsertNewDepartment(string DepartmentName)
        {
            try
            {
                List<Department> insertedDepartment = department.InsertDepartment(DepartmentName);

                if (insertedDepartment != null)
                {
                    return Ok(insertedDepartment);
                }

                return Ok("fail to insert");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department Dept)
        {
            try
            {
                List<Department> updatedDepartment = department.UpdateDepartment(Dept);

                if (updatedDepartment != null)
                {
                    return Ok(updatedDepartment);
                }

                return Ok("Record not available");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            try
            {
                var DeleteDepartment = department.DeleteDepartment(Id);

                if (DeleteDepartment != null)
                {
                    return Ok(DeleteDepartment);
                }

                return Ok("Null");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
