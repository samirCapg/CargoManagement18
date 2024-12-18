using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CargoManagementDataAccess.Entity.Models;
using CargoManagementApi.Repositories.CitiesRepository;
using CargoManagementApi.Repositories.ProductsRepository;
using System;

namespace CargoManagementApi.Controllers
{
    public class CargoTypesController : ApiController
    {
        private readonly ICargoTypeRepository _repository;

        public CargoTypesController(ICargoTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CargoTypes/GetAllCargoTypes
        [HttpGet]
        [Route("api/CargoTypes/GetAllCargoTypes")]
        public async Task<IHttpActionResult> GetAll()
        {
            var cargoTypes = await _repository.GetAll();
            return Ok(cargoTypes);
        }

        // GET: api/CargoTypes/GetCargoTypeById/1
        [HttpGet]
        [Route("api/CargoTypes/GetCargoTypeById/{id}")]
        public async Task<IHttpActionResult> GetCargoTypeById(int id)
        {
            var cargoType = await _repository.GetById(id);
            if (cargoType != null)
            {
                return Ok(cargoType);
            }
            return NotFound();
        }

        // POST: api/CargoTypes/CreateCargoType
        [HttpPost]
        [Route("api/CargoTypes/CreateCargoType")]
        public async Task<IHttpActionResult> Create([FromBody] CargoType cargoType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.Create(cargoType);
                //return CreatedAtRoute("GetCargoTypeById", new { id = cargoType.Id }, cargoType);
                return Ok(true);
            } catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // PUT: api/CargoTypes/UpdateCargoType/1
        [HttpPut]
        [Route("api/CargoTypes/UpdateCargoType/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] CargoType cargoType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Update(id, cargoType);
            if (result != null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return NotFound();
        }

        // DELETE: api/CargoTypes/DeleteCargoType/1
        [HttpDelete]
        [Route("api/CargoTypes/DeleteCargoType/{id}")]
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
