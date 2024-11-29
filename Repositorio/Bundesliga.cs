using Explore_ease.Models;
using Explore_ease.Repositorio.Interfaz;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;

namespace Explore_ease.Repositorio
{
	public class BundesligaRepository : IBundesliga
	{
		private readonly ExploreEaseContext context;
		public BundesligaRepository(ExploreEaseContext context)
		{
			this.context = context;
		}
		public async Task<List<Bundesliga>> GetBundesliga()
		{
			var data = await context.Bundesliga.ToListAsync();

			return data;
		}
		public async Task<bool> PosTBundesliga(Bundesliga Bundesliga)
		{
			await context.Bundesliga.AddAsync(Bundesliga);
			await context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> PutBundesliga(Bundesliga Bundesliga)
		{
			context.Bundesliga.Update(Bundesliga);
			await context.SaveAsync();
			return true;
		}
		public async Task<bool> DeleteLaLiga(Bundesliga Bundesliga)
		{
			context.Bundesliga.Remove(Bundesliga);
			await context.SaveAsync();
			return true;
		}
	}
}
