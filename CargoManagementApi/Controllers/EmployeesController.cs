using CargoManagementApi.Repositories.EmployeeRepository;
using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CargoManagementApi.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository _repository;
        private readonly CargoManagementDbContext _context;


        public EmployeesController(IEmployeeRepository repository, CargoManagementDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        // APIs for Employee

        // GET: api/Employee/GetAllEmployee
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            var employees = await _repository.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            return NotFound();
        }

        // GET: api/Employee/GetEmployeeById/{id}
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IHttpActionResult> GetEmployeeById(int id)
        {
            var employee = await _repository.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        // GET: api/Employee/SearchByName/{Name}
        [HttpGet]
        [Route("SearchByName/{Name}")]
        public async Task<IHttpActionResult> SearchByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                var employees = await _repository.GetAll();
                return Ok(employees);
            }

            var searchResults = await _repository.SearchByName(Name);
            if (searchResults != null && searchResults.Any())
            {
                return Ok(searchResults);
            }

            return NotFound();
        }

        // POST: api/Employee/CreateEmployee
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IHttpActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _repository.Create(employee);
            if (success)
            {
                return Ok(employee);
            }

            return BadRequest("Unable to create employee");
        }

        // PUT: api/Employee/UpdateEmployee/{id}
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<IHttpActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _repository.Update(id, employee);
            if (success)
            {
                return Ok(success); // Successfully updated
            }

            return NotFound();
        }

        // DELETE: api/Employee/DeleteEmployee/{id}
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            var employee = await _repository.Delete(id);
            if (employee != null)
            {
                return Ok(); // Successfully deleted
            }

            return NotFound();
        }

        //employee login api
        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> EmployeeLogin([FromBody] EmployeeLoginModel employeeLogin)
        {
            if (employeeLogin == null || string.IsNullOrWhiteSpace(employeeLogin.UserName) || string.IsNullOrWhiteSpace(employeeLogin.Password))
            {
                return BadRequest("Username or Password cannot be empty");
            }

            var currentEmployee = await _context.Employees
                .FirstOrDefaultAsync(x => x.UserName == employeeLogin.UserName && x.Password == employeeLogin.Password);

            if (currentEmployee == null)
            {
                return NotFound();
            }
            return Ok("Employee Login Successful");
        }

    }
}
