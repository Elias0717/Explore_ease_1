using Explore_ease.Models;

namespace Explore_ease.Repositorio.Interfaz
{
    public interface Iperson
    {
        public async Task<List<Person>> GetPerson();
        public async Task<bool> PosTPerson(Person person);

    }
}
