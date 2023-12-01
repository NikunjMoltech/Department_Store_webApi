using DAL_DepartmentStore;
using DAL_DepartmentStore.DTOParameters;
using DAL_DepartmentStore.Entity.Tables;
using DAL_DepartmentStore.Models.Interface;
using DAL_DepartmentStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DbClass dbContext;

        private readonly IWebHostEnvironment webHostEnvironment;

        IEmployee employee;

        public EmployeeController(DbClass repoContext, IWebHostEnvironment webHostEnvironment)
        {
            dbContext = repoContext;
            employee = new EmployeeRepository(dbContext);
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("allEmployee")]

        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                List<Employee> employees = employee.GetAllEmployee().ToList();

                if (employees != null)
                {
                    return Ok(employees);
                }

                return Ok("no data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertEmployee")]
        public async Task<IActionResult> InsertEmployee(DTOInsertEmployeeParameter Emp)
        {
            try
            {
                var insertedEmployees = employee.InsertNewEmployee(Emp);

                if (insertedEmployees != null)
                {
                    return Ok(insertedEmployees);
                }

                return Ok("no data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee Emp)
        {
            try
            {
                string updatedEmployees = employee.UpdateEmployee(Emp);

                if (updatedEmployees != null)
                {
                    return Ok(updatedEmployees);
                }

                return Ok("no data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                string deleteDepartment = employee.DeleteEmployee(Id);

                if (deleteDepartment != null)
                {
                    return Ok(deleteDepartment);
                }

                return Ok("Null");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("saveFile")]
        public async Task<IActionResult> SaveFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await WriteFile(file);
            return Ok(result);
        }

        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName = "";
            try
            {
/*
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks.ToString() + extension;*/

                fileName = file.FileName;   

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if(!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

                using (var stream = new FileStream(exactPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
               
            }
            return fileName;
        }
        [HttpGet]
        [Route("saveFile/Upload/Files/{fileName}")]
        public async Task<IActionResult> getFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
            var image = System.IO.File.OpenRead(path);
           return File(image, "image/jpg");
        }
    }
}
