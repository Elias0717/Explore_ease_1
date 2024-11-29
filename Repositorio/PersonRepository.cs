using Explore_ease.Models;
using Explore_ease.Context;
using Microsoft.EntityFrameworkCore;
using Explore_ease.Repositorio.Interfaz;
namespace Explore_ease.Repositorio
{
    public class PersonRepositor: Iperson

    {
        private readonly AppDbContext context;
        public PersonRepositor(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Person>> GetPerson()
        {
            var data = await context.Persons.ToListAsync();

            return data;
        }
        public async Task<bool> PosTPerson(Person person)
        {
            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutPerson(Person person)
        {
            context.Persons.Update(person);
            await context.SaveAsync();
            return true;
        }
        public async Task<bool> DeletePerson(Person person)
        {
            context.Persons.Remove(person);
            await context.SaveAsync();
            return true;
        }
    }

    
}
