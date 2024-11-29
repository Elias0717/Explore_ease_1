using Explore_ease.Models;
using System.Threading.Tasks;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface ILaLiga
    {
		Task<List<Laliga>> GetLaLiga();
		Task<bool> PosTLaLiga(Laliga laliga);
		Task<bool> PutLaLiga(Laliga laliga);
		Task<bool> DeleteLaLiga(Laliga laliga);
	}
}
