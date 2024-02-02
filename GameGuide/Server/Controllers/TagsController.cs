using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameGuide.Shared.Domain;
using GameGuide.Server.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace GameGuide.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public TagsController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // GET: api/Tags
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _unitOfWork.Tags.GetAll(includes: q => q.Include(x => x.PostTags));
            return Ok(tags);
        }

        // GET: api/Tags/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _unitOfWork.Tags.Get(q => q.Id == id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Tags.Update(tag);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TagExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            await _unitOfWork.Tags.Insert(tag);
            await _unitOfWork.Save(HttpContext);



            return CreatedAtAction("GetTag", new { id = tag.Id }, tag);
        }

        // DELETE: api/Tags/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _unitOfWork.Tags.Get(q => q.Id ==id);
            if (tag == null)
            {
                return NotFound();
            }

            await _unitOfWork.Tags.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> TagExists(int id)
        {
            var tag = await _unitOfWork.Tags.Get(q => q.Id ==id);
            return tag != null;
        }

    }
}
