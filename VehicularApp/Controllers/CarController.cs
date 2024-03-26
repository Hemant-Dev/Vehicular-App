﻿using Microsoft.AspNetCore.Mvc;
using Vehicular.DTOs;
using Vehicular.IServices;
using Vehicular.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            this._carService = carService; 
        }
        // GET: api/<CarController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarDTO>>> GetAsync()
        {
            try
            {
                var carsList = await _carService.GetAllCarsAsync();
                if (carsList != null)
                {
                    return Ok(carsList);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarDTO>> GetByIdAsync(int id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                if (car != null)
                {
                    return Ok(car);
                }
                return NotFound(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<ActionResult<GetCarDTO>> PostAsync([FromBody] CreateCarDTO carDTO)
        {
            try
            {
                var result = await _carService.CreateCarAsync(carDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(carDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetCarDTO>> PutAsync(int id, [FromBody] UpdateCarDTO carDTO)
        {
            try
            {
                if (id != carDTO.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var oldCarDTO = await _carService.GetCarByIdAsync(id);
                if (oldCarDTO != null)
                {
                    var result = await _carService.UpdateCarAsync(id, carDTO);
                    return Ok(result);
                }
                return NotFound(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var carDTO = await _carService.GetCarByIdAsync(id);
                if (carDTO != null)
                {
                    var result = await _carService.DeleteCarAsync(id);
                    return Ok(result);
                }
                return NotFound(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CarController>/manufacturers
        [HttpGet("manufacturers")]
        public async Task<ActionResult<Manufacturer>> GetAllManufacturers()
        {   
            try
            {
                var manufacturersList = await _carService.GetAllManufacturersAsync();
                return Ok(manufacturersList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CarController>/colors
        [HttpGet("colors")]
        public async Task<ActionResult<Manufacturer>> GetAllColors()
        {
            try
            {
                var colorsList = await _carService.GetAllColorsAsync();
                return Ok(colorsList);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
