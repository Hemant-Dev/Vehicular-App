﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAllManufacturers()
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
        public async Task<ActionResult<IEnumerable<Color>>> GetAllColors()
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

        // GET api/<CarController>/engines
        [HttpGet("engines")]
        public async Task<ActionResult<IEnumerable<Engine>>> GetAllEngines()
        {
            try
            {
                var engineList = await _carService.GetAllEnginesAsync();
                return Ok(engineList);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        // GET api/<CarController>/brakes
        [HttpGet("brakes")]
        public async Task<ActionResult<IEnumerable<Brake>>> GetALlBrakes()
        {
            try
            {
                var brakesList = await _carService.GetAllBrakesAsync();
                return Ok(brakesList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CarController>/filter?searchName=''
        [HttpGet("filter")]
        //public async Task<ActionResult<IEnumerable<GetCarDTO>>> GetFilteredCars(string filter)
        //{

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(filter))
        //        {
        //            var filteredDTOList = await _carService.GetFilteredCarDTOList(filter);
        //            return Ok(filteredDTOList);
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public async Task<ActionResult<Paginated>> GetFilteredCars(int page, int pageSize, string filter)
        {

            try
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    var filteredDTOListAndTotalPages = await _carService.GetPaginatedFilteredCarDTOList(page, pageSize, filter);
                    var result = new Paginated()
                    {
                        CarDTOs = filteredDTOListAndTotalPages.Item1,
                        TotalPages = filteredDTOListAndTotalPages.Item2
                    };
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<CarController>/advancefilter
        [HttpPost("advancefilter")]
        public async Task<ActionResult<IEnumerable<GetCarDTO>>> GetAdvanceFilteredCars([FromBody] GetCarDTO carDTO)
        {
            try
            {
                if (carDTO != null)
                {
                    var advanceFilteredCarDTOList = await _carService.GetAdvanceFilteredCarDTOList(carDTO);
                    return Ok(advanceFilteredCarDTOList);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CarController>/paginated?page=&pageSize=
        //[HttpGet("paginated")]
        //public async Task<ActionResult<(IEnumerable<GetCarDTO>, int)>> GetAllPaginatedData(int page, int pageSize)
        //{
        //    if(page > 0)
        //    {
        //        var paginatedCarDTOListAndTotalPages = await _carService.GetPaginatedCarDTOList(page, pageSize);
        //        return Ok((paginatedCarDTOListAndTotalPages));
        //    }
        //    else
        //    {
        //        return NotFound("Page No cannot be negative!!");
        //    }

        //}
        [HttpGet("paginated")]
        public async Task<ActionResult<Paginated>> GetAllPaginatedData(int page, int pageSize)
        {
            if (page > 0)
            {
                var paginatedCarDTOListAndTotalPages = await _carService.GetPaginatedCarDTOList(page, pageSize);
                var result = new Paginated()
                {
                    CarDTOs = paginatedCarDTOListAndTotalPages.Item1,
                    TotalPages = paginatedCarDTOListAndTotalPages.Item2
                };
                return Ok(result);
            }
            else
            {
                return NotFound("Page No cannot be negative!!");
            }

        }

        // POST api/<CarController>/advancefilter
        [HttpPost("advanceFilterPaginated")]
        public async Task<ActionResult<Paginated>> GetPaginatedAdvanceFilteredCarAsync(int page, int pageSize,[FromBody] GetCarDTO carDTO)
        {
            if(page > 0)
            {
                var paginatedAdvanceCarDTOListAndTotalPages = await _carService.GetPaginatedAdvanceFilteredCarDTOList(page, pageSize, carDTO);
                var result = new Paginated()
                {
                    CarDTOs = paginatedAdvanceCarDTOListAndTotalPages.Item1,
                    TotalPages = paginatedAdvanceCarDTOListAndTotalPages.Item2
                };
                return Ok(result);
            }
            return NotFound("Page No cannot be negative!!");
        }
    }
}
