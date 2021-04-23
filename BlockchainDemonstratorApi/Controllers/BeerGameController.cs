﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlockchainDemonstratorApi.Data;
using BlockchainDemonstratorApi.Models.Classes;
using BlockchainDemonstratorApi.Models.Enums;
using Newtonsoft.Json;

namespace BlockchainDemonstratorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerGameController : ControllerBase
    {
        private readonly BeerGameContext _context;

        public BeerGameController(BeerGameContext context)
        {
            _context = context;
        }

        [HttpPost("CreateGame")]
        public ActionResult CreateGame()
        {
            Game game = new Game(); //TODO: Make try catch
            _context.Games.Add(game);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("JoinGame")]
        public ActionResult JoinGame([FromBody] dynamic data)
        {
            if (data.gameId == null || data.role == null || data.name == null) return BadRequest();
            string gameId = (string) data.gameId;
            RoleType role = (RoleType) data.role;
            string name = (string) data.name;
            
            Game game = _context.Games.Find(gameId);
            if (game == null) return NotFound();

            bool joined = false;
            if (role == RoleType.Retailer)
            {
                game.Retailer = new Player(name);
                game.Retailer.Role = _context.Roles.FirstOrDefault(r => r.Id == "Retailer");
                joined = true;
            }
            else if (role == RoleType.Manufacturer)
            {
                game.Manufacturer = new Player(name);
                game.Manufacturer.Role = _context.Roles.FirstOrDefault(r => r.Id == "Manufacturer");
                joined = true;
            }
            else if (role == RoleType.Processor)
            {
                game.Processor = new Player(name);
                game.Processor.Role = _context.Roles.FirstOrDefault(r => r.Id == "Processor");
                joined = true;
            }
            else if (role == RoleType.Farmer)
            {
                game.Farmer = new Player(name);
                game.Farmer.Role = _context.Roles.FirstOrDefault(r => r.Id == "Farmer");
                joined = true;
            }

            if (joined)
            {
                _context.Games.Update(game);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        // GET: api/BeerGame
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            return await _context.Games
                .Include(g => g.Retailer).ThenInclude(p => p.Role)
                .Include(g => g.Manufacturer).ThenInclude(p => p.Role)
                .Include(g => g.Processor).ThenInclude(p => p.Role)
                .Include(g => g.Farmer).ThenInclude(p => p.Role)
                .ToListAsync();
        }

        // POST: api/BeerGame/GetGame
        [HttpPost("GetGame")]
        public ActionResult<Game> GetGame([FromBody] string gameId)
        {
            //string gameId = (string) data.gameId;
            var game =  _context.Games
                .Include(g => g.Retailer).ThenInclude(p => p.Role)
                .Include(g => g.Manufacturer).ThenInclude(p => p.Role)
                .Include(g => g.Processor).ThenInclude(p => p.Role)
                .Include(g => g.Farmer).ThenInclude(p => p.Role)
                .FirstOrDefault(game => game.Id == gameId);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // POST: api/BeerGame/SendOrders
        [HttpPost("SendOrders")]
        public ActionResult<Game> SendOrders([FromBody] dynamic data) //TODO: make singular later
        {
            if (data.gameId == null) return NotFound();
            string gameId = data.gameId;
            var game = _context.Games
                .Include(g => g.Retailer).ThenInclude(p => p.Role)
                .Include(g => g.Manufacturer).ThenInclude(p => p.Role)
                .Include(g => g.Processor).ThenInclude(p => p.Role)
                .Include(g => g.Farmer).ThenInclude(p => p.Role)
                .FirstOrDefault(game => game.Id == gameId);

            game.Retailer.CurrentOrder = new Order() {Volume = (data.retailerOrder != null) ? Int32.Parse((string)data.retailerOrder) : 0 };
            game.Manufacturer.CurrentOrder = new Order() {Volume = (data.manufacturerOrder != null) ? Int32.Parse((string)data.manufacturerOrder) : 0 };
            game.Processor.CurrentOrder = new Order() {Volume = (data.processorOrder != null) ? Int32.Parse((string)data.processorOrder) : 0 };
            game.Farmer.CurrentOrder = new Order() {Volume = (data.farmerOrder != null) ? Int32.Parse((string)data.farmerOrder) : 0 };

            game.Progress();
            _context.Games.Update(game);
            _context.SaveChanges();
            return game;
        }

        // PUT: api/BeerGame/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(string id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/BeerGame
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/BeerGame/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(string id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(string id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}