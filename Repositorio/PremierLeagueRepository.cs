using Explore_ease.Models;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;
using Explore_ease.Repositorio.Interfaz;
namespace Explore_ease.Repositorio
{
	public class PremierLeagueRepository : IPremierLeague

	{
		private readonly ExploreEaseContext context;
		public PremierLeagueRepository(ExploreEaseContext context)
		{
			this.context = context;
		}
		public async Task<List<PremierLeague>> GetPremierLeague()
		{
			var data = await context.PremierLeague.ToListAsync();

			return data;
		}
		public async Task<bool> PosTPremierLeague(PremierLeague PremierLeague)
		{
			await context.PremierLeague.AddAsync(PremierLeague);
			await context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> PutPremierLeague(PremierLeague PremierLeague)
		{
			context.PremierLeague.Update(PremierLeague);
			await context.SaveAsync();
			return true;
		}
		public async Task<bool> DeletePremierLeague(PremierLeague PremierLeague)
		{
			context.PremierLeague.Remove(PremierLeague);
			await context.SaveAsync();
			return true;
		}
	}


}
