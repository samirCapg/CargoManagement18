using CargoManagementApi.Repositories.CitiesRepository;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CargoManagementApi.Controllers
{
    [RoutePrefix("api/Cities")]
    public class CitiesController : ApiController
    {
        private readonly ICityRepository _repository;

        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Cities/GetAllCities
        [HttpGet]
        [Route("GetAllCities")]
        public async Task<IHttpActionResult> GetAll()
        {
            var cities = await _repository.GetAll();
            if (cities != null && cities.Any())
            {
                return Ok(cities);
            }
            return NotFound();
        }

        // GET: api/Cities/GetCityById/{id}
        [HttpGet]
        [Route("GetCityById/{id}", Name = "GetCityById")]
        public async Task<IHttpActionResult> GetCityById(int id)
        {
            var city = await _repository.GetById(id);
            if (city != null)
            {
                return Ok(city);
            }
            return NotFound();
        }

        // POST: api/Cities/CreateCity
        [HttpPost]
        [Route("CreateCity")]
        public async Task<IHttpActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var createdCity = await _repository.Create(city);
            //return CreatedAtRoute("GetCityById", new { id = createdCity.Id }, createdCity);
            return Ok(createdCity); 
        }

        // PUT: api/Cities/UpdateCity/{id}
        [HttpPut]
        [Route("UpdateCity/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var updatedCity = await _repository.Update(id, city);
            if (updatedCity != null)
            {
                return StatusCode(HttpStatusCode.NoContent); // 204 No Content
            }

            return NotFound();
        }

        // DELETE: api/Cities/DeleteCity/{id}
        [HttpDelete]
        [Route("DeleteCity/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var deletedCity = await _repository.Delete(id);
            if (deletedCity != null)
            {
                return Ok(deletedCity);
            }

            return NotFound();
        }
    }
}
