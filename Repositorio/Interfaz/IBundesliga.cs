using Explore_ease.Models;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface IBundesliga
    {
		Task<List<Bundesliga>> GetBundesliga();
		Task<bool> PosTBundesliga(Bundesliga Bundesliga);
		Task<bool> PutBundesliga(Bundesliga Bundesliga);
		Task<bool> DeleteLaLiga(Bundesliga Bundesliga);
	}
}
