using CargoManagementApi.Repositories;
using CargoManagementApi.Repositories.CitiesRepository;
using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CargoManagementApi.Controllers
{
    public class CargoesController : ApiController
    {
        private readonly ICargoRepository _repository;

        public CargoesController(ICargoRepository repository)
        {
            _repository = repository;
        }

        // Get all Cargo
        [HttpGet]
        [Route("api/Cargoes/GetAllCargo")]
        public async Task<IHttpActionResult> GetAllCargo()
        {
            var cargos = await _repository.GetAllCargo();
            return Ok(cargos);
        }

        // Get Cargo by ID
        [HttpGet]
        [Route("api/Cargoes/GetCargoId/{id}")]
        public async Task<IHttpActionResult> GetCargoById(int id)
        {
            var cargo = await _repository.GetCargoById(id);
            if (cargo != null)
            {
                return Ok(cargo);
            }
            return NotFound();
        }

        // Create a new Cargo
        [HttpPost]
        [Route("api/Cargoes/Create")]
        public async Task<IHttpActionResult> Create([FromBody] Cargo cargo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.Create(cargo);
                //return CreatedAtRoute("GetCargoById", new { id = cargo.CargoId }, cargo);
                return Ok();
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        // Update Cargo by ID
        [HttpPut]
        [Route("api/Cargoes/Update/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Update(id, cargo);
            if (result)
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            return NotFound();
        }

        // Delete Cargo by ID
        [HttpDelete]
        [Route("api/Cargoes/Delete/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
