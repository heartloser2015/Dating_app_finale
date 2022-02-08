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
    public class NotifiesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public NotifiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        // GET: api/Notifies
        [HttpGet]
        public async Task<IActionResult> GetNotifies()
        {
            var notifies = await _unitOfWork.Notifies.GetAll();
            return Ok(notifies);
        }



        // GET: api/Notifies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotify(int id)
        {
            var notify = await _unitOfWork.Notifies.Get(q => q.Id == id);

            if (notify == null)
            {
                return NotFound();
            }

            return Ok(notify);
        }

        // PUT: api/Notifies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotify(int id, Notify notify)
        {
            if (id != notify.Id)
            {
                return BadRequest();
            }


            _unitOfWork.Notifies.Update(notify);
            try
            {

                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await NotifyExists(id))
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

        // POST: api/Notifies

        [HttpPost]
        public async Task<ActionResult<Notify>> PostNotify(Notify notify)
        {

            await _unitOfWork.Notifies.Insert(notify);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetNotify", new { id = notify.Id }, notify);
        }


        // DELETE: api/Notifies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotify(int id)
        {
            var notify = await _unitOfWork.Notifies.Get(q => q.Id == id);
            if (notify == null)
            {
                return NotFound();
            }

            await _unitOfWork.Notifies.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> NotifyExists(int id)
        {

            var notify = await _unitOfWork.Notifies.Get(q => q.Id == id);
            return notify != null;
        }
    }
}

