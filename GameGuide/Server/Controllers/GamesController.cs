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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GameGuide.Server.IRepository;
using GameGuide.Shared.Domain;
using Microsoft.AspNetCore.Authorization;

namespace GameGuide.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Games
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {

            var games = await _unitOfWork.Games.GetAll(includes: q => q.Include(x => x.Categories));
            return Ok(games);
        }

        // GET: api/Games/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _unitOfWork.Games.Get(q => q.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Games.Update(game);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            await _unitOfWork.Games.Insert(game);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _unitOfWork.Games.Get(q => q.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            await _unitOfWork.Games.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> GameExists(int id)
        {
            var game = await _unitOfWork.Games.Get(q => q.Id == id);
            return game != null;
        }
    }
}
