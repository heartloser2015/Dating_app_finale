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
    public class SubscriptionsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        // GET: api/Subscriptions
        [HttpGet]
        public async Task<IActionResult> GetSubscriptions()
        {
            var subscriptions = await _unitOfWork.Subscriptions.GetAll();
            return Ok(subscriptions);
        }



        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        // PUT: api/Subscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }


            _unitOfWork.Subscriptions.Update(subscription);
            try
            {

                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await SubscriptionExists(id))
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

        // POST: api/Subscriptions

        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {

            await _unitOfWork.Subscriptions.Insert(subscription);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetSubscription", new { id = subscription.Id }, subscription);
        }


        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            await _unitOfWork.Subscriptions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> SubscriptionExists(int id)
        {

            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);
            return subscription != null;
        }
    }
}

