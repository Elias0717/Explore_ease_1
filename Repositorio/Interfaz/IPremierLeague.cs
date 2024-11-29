using Explore_ease.Models;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface IPremierLeague
	{
		Task<List<PremierLeague>> GetPremierLeague();
		Task<bool> PosTPremierLeague(PremierLeague PremierLeague);
		Task<bool> PutPremierLeague(PremierLeague PremierLeague);
		Task<bool> DeletePremierLeague(PremierLeague PremierLeague);

	}
}
