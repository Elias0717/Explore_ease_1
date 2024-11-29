using Explore_ease.Models;
using Explore_ease.Repositorio.Interfaz;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;

namespace Explore_ease.Repositorio
{
	public class SerieARepository : ISerieA
	{
		private readonly ExploreEaseContext context;
		public SerieARepository(ExploreEaseContext context)
		{
			this.context = context;
		}
		public async Task<List<SerieA>> GetSerieA()
		{
			var data = await context.SerieA.ToListAsync();

			return data;
		}
		public async Task<bool> PosTSerieA(SerieA SerieA)
		{
			await context.SerieA.AddAsync(SerieA);
			await context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> PutSerieA(SerieA SerieA)
		{
			context.SerieA.Update(SerieA);
			await context.SaveAsync();
			return true;
		}
		public async Task<bool> DeleteSerieA(SerieA SerieA)
		{
			context.SerieA.Remove(SerieA);
			await context.SaveAsync();
			return true;
		}
	}
}

