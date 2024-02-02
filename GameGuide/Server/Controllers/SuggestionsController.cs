using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameGuide.Server.Data;
using GameGuide.Shared.Domain;
using GameGuide.Server.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace GameGuide.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuggestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Suggestions
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetSuggestions()
        {
            var suggestions = await _unitOfWork.Suggestions.GetAll();
            return Ok(suggestions);
        }

        // GET: api/Suggestions/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuggestion(int id)
        {
            var suggestion = await _unitOfWork.Suggestions.Get(q  => q.Id == id);

            if (suggestion == null)
            {
                return NotFound();
            }

            return Ok(suggestion);
        }

        // PUT: api/Suggestions/5
        // To protect from oversuggestioning attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuggestion(int id, Suggestion suggestion)
        {
            if (id != suggestion.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Suggestions.Update(suggestion);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SuggestionExists(id))
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

        // POST: api/Suggestions
        // To protect from oversuggestioning attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Suggestion>> SuggestionSuggestion(Suggestion suggestion)
        {
            await _unitOfWork.Suggestions.Insert(suggestion);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSuggestion", new { id = suggestion.Id }, suggestion);
        }

        // DELETE: api/Suggestions/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuggestion(int id)
        {
            var suggestion = await _unitOfWork.Suggestions.Get(q => q.Id ==id);
            if (suggestion == null) 
            { 
                return NotFound(); 
            }
            await _unitOfWork.Suggestions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> SuggestionExists(int id)
        {
            var suggestion = await _unitOfWork.Suggestions.Get(q => q.Id ==id);
            return suggestion != null;
        }
    }
}
