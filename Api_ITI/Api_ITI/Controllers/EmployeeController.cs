using Api_ITI.DTOs;
using Api_ITI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_ITI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly apiDbContext _context;

        public EmployeeController(apiDbContext context)
        {
            _context = context;
        }

        // 1- Get All
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees
                .Include(e => e.Project) 
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    PhoneNumber = e.PhoneNumber,
                    Salary = e.Salary,
                    Position = e.Position,
                    Department = e.Department,
                    ProjectName = e.Project.Name  
                })
                .ToListAsync();

            return Ok(employees);
        }

        // 2- Get By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var e = await _context.Employees
                .Include(e => e.Project)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (e == null)
                return NotFound();

            var dto = new EmployeeDTO
            {
                Id = e.Id,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                Salary = e.Salary,
                Position = e.Position,
                Department = e.Department,
                ProjectName = e.Project.Name
            };

            return Ok(dto);
        }

        // 3- Get By Name
        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var employees = await _context.Employees
                .Include(e => e.Project)
                .Where(e => e.FullName.Contains(name))
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    PhoneNumber = e.PhoneNumber,
                    Salary = e.Salary,
                    Position = e.Position,
                    Department = e.Department,
                    ProjectName = e.Project.Name
                })
                .ToListAsync();

            return Ok(employees);
        }

    
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeCreateDTO dto)
        {
           
            var projectExists = await _context.Projects.AnyAsync(p => p.Id == dto.ProjectId);
            if (!projectExists)
                return BadRequest("Project not found");

           
            var employee = new Employee
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Salary = dto.Salary,
                Position = dto.Position,
                Department = dto.Department,
                ProjectId = dto.ProjectId
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // 5- Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeCreateDTO dto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            var projectExists = await _context.Projects.AnyAsync(p => p.Id == dto.ProjectId);
            if (!projectExists)
                return BadRequest("Project not found");

            employee.FullName = dto.FullName;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Salary = dto.Salary;
            employee.Position = dto.Position;
            employee.Department = dto.Department;
            employee.ProjectId = dto.ProjectId;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // 6- Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}