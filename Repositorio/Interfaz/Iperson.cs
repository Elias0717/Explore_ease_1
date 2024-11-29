using Explore_ease.Models;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface Iperson
    {
        Task<List<Person>> GetPerson();
        Task<bool> PosTPerson(Person person);
        Task<bool> PutPerson(Person person);
        Task<bool> DeletePerson(Person person);

	}
}
