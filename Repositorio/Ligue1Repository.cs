using Explore_ease.Models;
using Explore_ease.Repositorio.Interfaz;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;

namespace Explore_ease.Repositorio
{
	public class Ligue1Repository : ILigue1
	{
		private readonly ExploreEaseContext context;
		public Ligue1Repository(ExploreEaseContext context)
		{
			this.context = context;
		}
		public async Task<List<Ligue1>> GetLaLigue1()
		{
			var data = await context.Ligue1.ToListAsync();

			return data;
		}
		public async Task<bool> PosTLigue1(Ligue1 Ligue1)
		{
			await context.Ligue1.AddAsync(Ligue1);
			await context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> PutLaLiga(Ligue1 Ligue1)
		{
			context.Ligue1.Update(Ligue1);
			await context.SaveAsync();
			return true;
		}
		public async Task<bool> DeleteLigue1(Ligue1 Ligue1)
		{
			context.Ligue1.Remove(Ligue1);
			await context.SaveAsync();
			return true;
		}
	}
}