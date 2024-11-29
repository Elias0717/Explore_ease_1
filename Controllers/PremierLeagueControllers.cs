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
	public class PremierLeagueController : ControllerBase
	{
		private readonly ExploreEaseContext _context;

		public PremierLeagueController(ExploreEaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PremierLeague>>> GetPremierLeague()
		{
			return await _context.PremierLeague.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PremierLeague>> GetPremierLeague(int id)
		{
			var premierLeague = await _context.PremierLeague.FindAsync(id);

			if (premierLeague == null)
			{
				return NotFound();
			}

			return premierLeague;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutPremierLeague(int id, PremierLeague premierLeague)
		{
			if (id != premierLeague.Id)
			{
				return BadRequest();
			}

			_context.Entry(premierLeague).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PremierLeagueExists(id))
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

		[HttpPost]
		public async Task<ActionResult<PremierLeague>> PostPremierLeague(PremierLeague premierLeague)
		{
			_context.PremierLeague.Add(premierLeague);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPremierLeague", new { id = premierLeague.Id }, premierLeague);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePremierLeague(int id)
		{
			var premierLeague = await _context.PremierLeague.FindAsync(id);
			if (premierLeague == null)
			{
				return NotFound();
			}

			_context.PremierLeague.Remove(premierLeague);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PremierLeagueExists(int id)
		{
			return _context.PremierLeague.Any(e => e.Id == id);
		}
	}
}

