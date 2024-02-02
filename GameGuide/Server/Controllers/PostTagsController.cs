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
    public class PostTagsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public PostTagsController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // GET: api/PostTags
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPostTags()
        {
            var postTags = await _unitOfWork.PostTags.GetAll(includes: q=>q.Include(x => x.Post).Include(x => x.Tag));
            return Ok(postTags);
        }

        // GET: api/PostTags/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostTag(int id)
        {
            var postTag = await _unitOfWork.PostTags.Get(q => q.Id == id);

            if (postTag == null)
            {
                return NotFound();
            }

            return Ok(postTag);
        }

        // PUT: api/PostTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostTag(int id, PostTag postTag)
        {
            if (id != postTag.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PostTags.Update(postTag);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PostTagExists(id))
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

        // POST: api/PostTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<PostTag>> PostPostTag(PostTag postTag)
        {
            await _unitOfWork.PostTags.Insert(postTag);
            await _unitOfWork.Save(HttpContext);



            return CreatedAtAction("GetPostTag", new { id = postTag.Id }, postTag);
        }

        // DELETE: api/PostTags/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostTag(int id)
        {
            var postTag = await _unitOfWork.PostTags.Get(q => q.Id ==id);
            if (postTag == null)
            {
                return NotFound();
            }

            await _unitOfWork.PostTags.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> PostTagExists(int id)
        {
            var postTag = await _unitOfWork.PostTags.Get(q => q.Id ==id);
            return postTag != null;
        }

    }
}
