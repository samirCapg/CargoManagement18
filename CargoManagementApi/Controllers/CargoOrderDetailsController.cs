using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CargoManagementDataAccess.Entity.Models;
using CargoManagementApi.Repositories.CargoOrderDetailsRepository;
using System;

namespace CargoManagementApi.Controllers
{
    public class CargoOrderDetailsController : ApiController
    {
        private readonly ICargoOrderDetailRepository _repository;

        public CargoOrderDetailsController(ICargoOrderDetailRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CargoOrderDetails/GetAllCargoOrderDetails
        [HttpGet]
        [Route("api/CargoOrderDetails/GetAllCargoOrderDetails")]
        public async Task<IHttpActionResult> GetAll()
        {
            var cargoOrderDetails = await _repository.GetAll();
            return Ok(cargoOrderDetails);
        }

        // GET: api/CargoOrderDetails/GetCargoOrderDetailById/1
        [HttpGet]
        [Route("api/CargoOrderDetails/GetCargoOrderDetailById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var cargoOrderDetail = await _repository.GetById(id);
            if (cargoOrderDetail != null)
            {
                return Ok(cargoOrderDetail);
            }
            return NotFound();
        }

        // POST: api/CargoOrderDetails/Create
        [HttpPost]
        [Route("api/CargoOrderDetails/Create")]
        public async Task<IHttpActionResult> Create([FromBody] CargoOrderDetail cargoOrderDetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.Create(cargoOrderDetail);
                //return CreatedAtRoute("GetCargoOrderDetailById", new { id = cargoOrderDetail.OrderId }, cargoOrderDetail);
                return Ok(true);    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        // PUT: api/CargoOrderDetails/UpdateCargoOrderDetail/1
        [HttpPut]
        [Route("api/CargoOrderDetails/UpdateCargoOrderDetail/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] CargoOrderDetail cargoOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Update(id, cargoOrderDetail);
            if (result != null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return NotFound();
        }

        // DELETE: api/CargoOrderDetails/DeleteCargoOrderDetail/1
        [HttpDelete]
        [Route("api/CargoOrderDetails/DeleteCargoOrderDetail/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
