using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CargoManagementDataAccess.Entity.Models;
using CargoManagementApi.Repositories.ProductsRepository;
using CargoManagementApi.Repositories.CargoStatusesRepository;
using System;

namespace CargoManagementApi.Controllers
{
    public class CargoStatusController : ApiController
    {
        private readonly ICargoStatusRepository _repository;

        public CargoStatusController(ICargoStatusRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CargoStatus/GetAllStatus
        [HttpGet]
        [Route("api/CargoStatus/GetAllStatus")]
        public async Task<IHttpActionResult> GetAll()
        {
            var statuses = await _repository.GetAll();
            return Ok(statuses);
        }

        // GET: api/CargoStatus/GetstatusById/1
        [HttpGet]
        [Route("api/CargoStatus/GetstatusById/{id}")]
        public async Task<IHttpActionResult> GetCityById(int id)
        {
            var status = await _repository.GetById(id);
            if (status != null)
            {
                return Ok(status);
            }
            return NotFound();
        }

        // POST: api/CargoStatus/CreateStatus
        [HttpPost]
        [Route("api/CargoStatus/CreateStatus")]
        public async Task<IHttpActionResult> Create([FromBody] CargoStatus status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.Create(status);
                //return CreatedAtRoute("GetstatusById", new { id = status.StatusId }, status);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // PUT: api/CargoStatus/UpdateStatus/1
        [HttpPut]
        [Route("api/CargoStatus/UpdateStatus/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] CargoStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Update(id, status);
            if (result != null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return NotFound();
        }

        // DELETE: api/CargoStatus/DeleteStatus/1
        [HttpDelete]
        [Route("api/CargoStatus/DeleteStatus/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
