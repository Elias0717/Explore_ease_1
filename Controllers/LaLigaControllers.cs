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
	public class LaLigaController : ControllerBase
	{
		private readonly ExploreEaseContext _context;

		public LaLigaController(ExploreEaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Laliga>>> GetLaLiga()
		{
			return await _context.LaLiga.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Laliga>> GetLaLiga(int id)
		{
			var laLiga = await _context.LaLiga.FindAsync(id);

			if (laLiga == null)
			{
				return NotFound();
			}

			return laLiga;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutLaLiga(int id, Laliga laLiga)
		{
			if (id != laLiga.Id)
			{
				return BadRequest();
			}

			_context.Entry(laLiga).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LaLigaExists(id))
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
		public async Task<ActionResult<Laliga>> PostLaLiga(Laliga laLiga)
		{
			_context.LaLiga.Add(laLiga);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetLaLiga", new { id = laLiga.Id }, laLiga);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLaLiga(int id)
		{
			var laLiga = await _context.LaLiga.FindAsync(id);
			if (laLiga == null)
			{
				return NotFound();
			}

			_context.LaLiga.Remove(laLiga);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool LaLigaExists(int id)
		{
			return _context.LaLiga.Any(e => e.Id == id);
		}
	}
}
