using Explore_ease.Models;
using Explore_ease.Repositorio.Interfaz;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;

namespace Explore_ease.Repositorio
{
    public class LaLigaRepository : ILaLiga
	{
		private readonly ExploreEaseContext context;
		public LaLigaRepository(ExploreEaseContext context)
		{
			this.context = context;
		}
		public async Task<List<Laliga>> GetLaLiga()
		{
			var data = await context.LaLiga.ToListAsync();

			return data;
		}
		public async Task<bool> PosTLaLiga(Laliga laliga)
		{
			await context.LaLiga.AddAsync(laliga);
			await context.SaveChangesAsync();
			return true;
		}
		public async Task<bool> PutLaLiga(Laliga laliga)
		{
			context.LaLiga.Update(laliga);
			await context.SaveAsync();
			return true;
		}
		public async Task<bool> DeleteLaLiga(Laliga laliga)
		{
			context.LaLiga.Remove(laliga);
			await context.SaveAsync();
			return true;
		}
	}
}
