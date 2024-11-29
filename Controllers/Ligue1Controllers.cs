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
	public class Ligue1Controller : ControllerBase
	{
		private readonly ExploreEaseContext _context;

		public Ligue1Controller(ExploreEaseContext context)
		{
			_context = context;
		}

		// GET: api/Ligue1
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Ligue1>>> GetLigue1()
		{
			return await _context.Ligue1.ToListAsync();
		}

		// GET: api/Ligue1/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Ligue1>> GetLigue1(int id)
		{
			var ligue1 = await _context.Ligue1.FindAsync(id);

			if (ligue1 == null)
			{
				return NotFound();
			}

			return ligue1;
		}

		// PUT: api/Ligue1/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLigue1(int id, Ligue1 ligue1)
		{
			if (id != ligue1.Id)
			{
				return BadRequest();
			}

			_context.Entry(ligue1).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!Ligue1Exists(id))
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

		// POST: api/Ligue1
		[HttpPost]
		public async Task<ActionResult<Ligue1>> PostLigue1(Ligue1 ligue1)
		{
			_context.Ligue1.Add(ligue1);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetLigue1", new { id = ligue1.Id }, ligue1);
		}

		// DELETE: api/Ligue1/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLigue1(int id)
		{
			var ligue1 = await _context.Ligue1.FindAsync(id);
			if (ligue1 == null)
			{
				return NotFound();
			}

			_context.Ligue1.Remove(ligue1);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool Ligue1Exists(int id)
		{
			return _context.Ligue1.Any(e => e.Id == id);
		}
	}
}