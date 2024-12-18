using CargoManagementApi.Repositories.AdminRepository;
using CargoManagementApi.Repositories.EmployeeRepository;
using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace YourNamespace.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly CargoManagementDbContext _context;

        public AdminController(IAdminRepository repository, IEmployeeRepository employeeRepository, CargoManagementDbContext context)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _context = context;
        }


        //APIs for Admin

        // GET: api/Admin/GetAllAdmin
        [HttpGet]
        [Route("GetAllAdmin")]
        public async Task<IHttpActionResult> GetAllAdmins()
        {
            var admins = await _repository.GetAll();
            if (admins != null)
            {
                return Ok(admins);
            }
            return NotFound();
        }

        // GET: api/Admin/GetAdminById/{id}
        [HttpGet]
        [Route("GetAdminById/{id}")]
        public async Task<IHttpActionResult> GetAdminById(int id)
        {
            var admin = await _repository.GetById(id);
            if (admin != null)
            {
                return Ok(admin);
            }
            return NotFound();
        }

        // POST: api/Admin/CreateAdmin
        [HttpPost]
        [Route("CreateAdmin")]
        public async Task<IHttpActionResult> CreateAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _repository.Create(admin);
            if (success)
            {
                return Ok(admin);
            }

            return BadRequest("Unable to create admin");
        }

        // PUT: api/Admin/UpdateAdmin/{id}
        [HttpPut]
        [Route("UpdateAdmin/{id}")]
        public async Task<IHttpActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var adminUpdated = await _repository.Update(id, admin);
            if (adminUpdated)
            {
                return Ok(adminUpdated);
            }

            return NotFound();
        }

        // DELETE: api/Admin/DeleteAdmin/{id}
        [HttpDelete]
        [Route("DeleteAdmin/{id}")]
        public async Task<IHttpActionResult> DeleteAdmin(int id)
        {
            var admin = await _repository.Delete(id);
            if (admin != null)
            {
                return Ok(admin);
            }

            return NotFound();
        }


        //admin login api
        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> Login([FromBody] AdminLoginModel adminLogin)
        {
            if (adminLogin == null || string.IsNullOrWhiteSpace(adminLogin.UserName) || string.IsNullOrWhiteSpace(adminLogin.Password))
            {
                return BadRequest("Username or Password cannot be empty");
            }

            var currentAdmin = await _context.Admins
                .FirstOrDefaultAsync(x => x.UserName == adminLogin.UserName && x.Password == adminLogin.Password);

            if (currentAdmin == null)
            {
                return NotFound();
            }
            return Ok("Login Successful");
        }



        //Admin controlling employee APIs
        /*

        //APIs for Employee
        // GET: api/Employee/GetAllEmployee
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/Employee/GetEmployeeById/{id}
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IHttpActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        // POST: api/employee/CreateEmployees
        [HttpPost]
        [Route("CreateEmployee")] 
        public async Task<IHttpActionResult> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _employeeRepository.Create(employee);
            if (success)
            {
                //return CreatedAtRoute("GetAdminById", new { id = admin.Id }, admin);
                return Ok(employee);
            }

            return BadRequest("Unable to create employee");
        }

        // PUT: api/Admin/UpdateAdmin/{id}
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<IHttpActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _employeeRepository.Update(id, employee);
            if (success)
            {
                return StatusCode(HttpStatusCode.NoContent); //204
            }

            return NotFound();
        }

        // DELETE: api/Employee/DeleteEmployee/{id}
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.Delete(id);
            if (employee != null)
            {
                return Ok();
            }

            return NotFound();
        } 


        */
    }

}