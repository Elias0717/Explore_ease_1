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
	public class SerieAController : ControllerBase
	{
		private readonly ExploreEaseContext _context;

		public SerieAController(ExploreEaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<SerieA>>> GetSerieA()
		{
			return await _context.SerieA.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SerieA>> GetSerieA(int id)
		{
			var serieA = await _context.SerieA.FindAsync(id);

			if (serieA == null)
			{
				return NotFound();
			}

			return serieA;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutSerieA(int id, SerieA serieA)
		{
			if (id != serieA.Id)
			{
				return BadRequest();
			}

			_context.Entry(serieA).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SerieAExists(id))
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
		public async Task<ActionResult<SerieA>> PostSerieA(SerieA serieA)
		{
			_context.SerieA.Add(serieA);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetSerieA", new { id = serieA.Id }, serieA);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSerieA(int id)
		{
			var serieA = await _context.SerieA.FindAsync(id);
			if (serieA == null)
			{
				return NotFound();
			}

			_context.SerieA.Remove(serieA);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool SerieAExists(int id)
		{
			return _context.SerieA.Any(e => e.Id == id);
		}
	}
}
