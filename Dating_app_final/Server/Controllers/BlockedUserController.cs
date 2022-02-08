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
    public class BlockedUsersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public BlockedUsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        // GET: api/BlockedUsers
        [HttpGet]
        public async Task<IActionResult> GetBlockedUsers()
        {
            var blockedusers = await _unitOfWork.BlockedUsers.GetAll();
            return Ok(blockedusers);
        }



        // GET: api/BlockedUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlockedUser(int id)
        {
            var blockeduser = await _unitOfWork.BlockedUsers.Get(q => q.Id == id);

            if (blockeduser == null)
            {
                return NotFound();
            }

            return Ok(blockeduser);
        }

        // PUT: api/BlockedUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlockedUser(int id, BlockedUser blockeduser)
        {
            if (id != blockeduser.Id)
            {
                return BadRequest();
            }


            _unitOfWork.BlockedUsers.Update(blockeduser);
            try
            {

                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await BlockedUserExists(id))
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

        // POST: api/BlockedUsers

        [HttpPost]
        public async Task<ActionResult<BlockedUser>> PostBlockedUser(BlockedUser blockeduser)
        {

            await _unitOfWork.BlockedUsers.Insert(blockeduser);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetBlockedUser", new { id = blockeduser.Id }, blockeduser);
        }


        // DELETE: api/BlockedUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockedUser(int id)
        {
            var blockeduser = await _unitOfWork.BlockedUsers.Get(q => q.Id == id);
            if (blockeduser == null)
            {
                return NotFound();
            }

            await _unitOfWork.BlockedUsers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> BlockedUserExists(int id)
        {

            var blockeduser = await _unitOfWork.BlockedUsers.Get(q => q.Id == id);
            return blockeduser != null;
        }
    }
}

