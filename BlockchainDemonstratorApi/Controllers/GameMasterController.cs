﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlockchainDemonstratorApi.Data;
using BlockchainDemonstratorApi.Models.Classes;

namespace BlockchainDemonstratorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameMasterController : ControllerBase
    {
        private readonly BeerGameContext _context;

        public GameMasterController(BeerGameContext context)
        {
            _context = context;
        }

        // POST: api/GameMaster/GetGames
        [HttpPost("GetGames")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames([FromBody] string gameMasterId)
        {
            return await _context.Games.Where(g => g.GameMasterId == gameMasterId).ToListAsync();
        }


        // GET: api/GameMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMaster>>> GetGameMasters()
        {
            return await _context.GameMasters.ToListAsync();
        }

        // GET: api/GameMaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameMaster>> GetGameMaster(string id)
        {
            var gameMaster = await _context.GameMasters.FindAsync(id);

            if (gameMaster == null)
            {
                return NotFound();
            }

            return gameMaster;
        }

        // PUT: api/GameMaster/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameMaster(string id, GameMaster gameMaster)
        {
            if (id != gameMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameMasterExistsFunc(id))
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

        // POST: api/GameMaster
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameMaster>> PostGameMaster(GameMaster gameMaster)
        {
            _context.GameMasters.Add(gameMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameMasterExistsFunc(gameMaster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGameMaster", new { id = gameMaster.Id }, gameMaster);
        }

        // DELETE: api/GameMaster/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameMaster>> DeleteGameMaster(string id)
        {
            var gameMaster = await _context.GameMasters.FindAsync(id);
            if (gameMaster == null)
            {
                return NotFound();
            }

            _context.GameMasters.Remove(gameMaster);
            await _context.SaveChangesAsync();

            return gameMaster;
        }

        [HttpPost("GameMasterExists")]
        public ActionResult<bool> GameMasterExists([FromBody] string id)
        {
            return GameMasterExistsFunc(id);
        }

        private bool GameMasterExistsFunc(string id)
        {
            return _context.GameMasters.Any(e => e.Id == id);
        }
    }
}
