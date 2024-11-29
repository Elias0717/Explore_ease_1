using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Explore_ease.Models;
using ExploreEase.Context;

namespace Explore_ease.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BundesligaController : ControllerBase
	{
		private readonly ExploreEaseContext _context;

		public BundesligaController(ExploreEaseContext context)
		{
			_context = context;
		}

		// GET: api/Bundesliga
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Bundesliga>>> GetBundesliga()
		{
			return await _context.Bundesliga.ToListAsync();
		}

		// GET: api/Bundesliga/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Bundesliga>> GetBundesliga(int id)
		{
			var bundesliga = await _context.Bundesliga.FindAsync(id);

			if (bundesliga == null)
			{
				return NotFound();
			}

			return bundesliga;
		}

		// PUT: api/Bundesliga/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBundesliga(int id, Bundesliga bundesliga)
		{
			if (id != bundesliga.Id)
			{
				return BadRequest();
			}

			_context.Entry(bundesliga).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BundesligaExists(id))
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

		// POST: api/Bundesliga
		[HttpPost]
		public async Task<ActionResult<Bundesliga>> PostBundesliga(Bundesliga bundesliga)
		{
			_context.Bundesliga.Add(bundesliga);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBundesliga", new { id = bundesliga.Id }, bundesliga);
		}

		// DELETE: api/Bundesliga/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBundesliga(int id)
		{
			var bundesliga = await _context.Bundesliga.FindAsync(id);
			if (bundesliga == null)
			{
				return NotFound();
			}

			_context.Bundesliga.Remove(bundesliga);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool BundesligaExists(int id)
		{
			return _context.Bundesliga.Any(e => e.Id == id);
		}
	}
}