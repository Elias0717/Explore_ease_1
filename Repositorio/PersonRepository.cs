using Explore_ease.Models;
using ExploreEase.Context;
using Microsoft.EntityFrameworkCore;
using Explore_ease.Repositorio.Interfaz;
namespace Explore_ease.Repositorio
{
    public class PersonRepositor : Iperson

	{
        private readonly ExploreEaseContext context;
        public PersonRepositor(ExploreEaseContext context)
        {
            this.context = context;
        }
        public async Task<List<Person>> GetPerson()
        {
            var data = await context.Person.ToListAsync();

            return data;
        }
        public async Task<bool> PosTPerson(Person person)
        {
            await context.Person.AddAsync(person);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutPerson(Person person)
        {
            context.Person.Update(person);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePerson(Person person)
        {
            context.Person.Remove(person);
            await context.SaveAsync();
            return true;
        }
    }

    
}
