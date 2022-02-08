using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dating_app_final.Server.Data;
using Dating_app_final.Shared.Domin;
using Dating_app_final.Server.IRepository;

namespace Dating_app_final.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        // GET: api/Locations
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _unitOfWork.Locations.GetAll();
            return Ok(locations);
        }



        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var location = await _unitOfWork.Locations.Get(q => q.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }


            _unitOfWork.Locations.Update(location);
            try
            {

                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {

            await _unitOfWork.Locations.Insert(location);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }


        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _unitOfWork.Locations.Get(q => q.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            await _unitOfWork.Locations.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> LocationExists(int id)
        {

            var location = await _unitOfWork.Locations.Get(q => q.Id == id);
            return location != null;
        }
    }
}

