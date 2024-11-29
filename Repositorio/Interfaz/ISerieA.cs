using Explore_ease.Models;
using System.Threading.Tasks;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface ISerieA
    {
		Task<List<SerieA>> GetSerieA();
		Task<bool> PosTSerieA(SerieA SerieA);
		Task<bool> PutSerieA(SerieA SerieA);
		Task<bool> DeleteSerieA(SerieA SerieA);
	}
}
