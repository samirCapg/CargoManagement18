using CargoManagementApi.Repositories.CustomerRepository;
using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CargoManagementApi.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _repository;
        private readonly CargoManagementDbContext _context;


        public CustomersController(ICustomerRepository repository, CargoManagementDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        // APIs for Customer

        // GET: api/Customer/GetAllCustomer
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            var customers = await _repository.GetAll();
            if (customers != null)
            {
                return Ok(customers);
            }
            return NotFound();
        }

        // GET: api/Customer/GetCustomerById/{id}
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IHttpActionResult> GetCustomerById(int id)
        {
            var customer = await _repository.GetById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        //GET: api/Customer/SearchByName
        [HttpGet]
        [Route("SearchByName/{Name}")]
        public async Task<IHttpActionResult> SearchByName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                var customers = await _repository.GetAll();
                return Ok(customers);
            }

            var searchResults = await _repository.SearchByName(Name);
            if (searchResults != null && searchResults.Any())
            {
                return Ok(searchResults);
            }

            return NotFound();
        }


        // POST: api/Customer/CreateCustomer
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IHttpActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _repository.Create(customer);
            if (success)
            {
                return Ok(customer);
            }

            return BadRequest("Unable to create customer");
        }

        // PUT: api/Customer/UpdateCustomer/{id}
        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<IHttpActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _repository.Update(id, customer);
            if (success)
            {
                return Ok(success); 
            }

            return NotFound();
        }

        // DELETE: api/Customer/DeleteCustomer/{id}
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            var customer = await _repository.Delete(id);
            if (customer != null)
            {
                return Ok();
            }

            return NotFound();
        }

        //customer login api
        [HttpPost]
        [Route("Login")]
        public async Task<IHttpActionResult> CustomerLogin([FromBody] CustomerLoginModel customerLogin)
        {
            if (customerLogin == null || string.IsNullOrWhiteSpace(customerLogin.UserName) || string.IsNullOrWhiteSpace(customerLogin.CustPassword))
            {
                return BadRequest("Username or Password cannot be empty");
            }

            var currentCustomer = await _context.Customers
                .FirstOrDefaultAsync(x => x.UserName == customerLogin.UserName && x.CustPassword == customerLogin.CustPassword);

            if (currentCustomer == null)
            {
                return NotFound();
            }
            return Ok("Customer Login Successful");
        }

    }
}
