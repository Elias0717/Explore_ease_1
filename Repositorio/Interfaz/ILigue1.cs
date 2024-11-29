using Explore_ease.Models;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface ILigue1
    {
		Task<List<Ligue1>> GetLaLigue1();
		Task<bool> PosTLigue1(Ligue1 Ligue1);
		Task<bool> PutLaLiga(Ligue1 Ligue1);
		Task<bool> DeleteLigue1(Ligue1 Ligue1);
	}
}
