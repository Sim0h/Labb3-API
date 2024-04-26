using Labb3_API.data;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class PersonRepo : IApp
    {
        private AppDbContext _dbContext;
        public PersonRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task AddInterestPerson(int personID, int interest)
        {
            var personInterestLink = new PersonInterest
            {
                PersonID = personID,
                InterestID = interest
            };
            _dbContext.PersonInterests.Add(personInterestLink);
            await _dbContext.SaveChangesAsync();

        }

        public async Task AddLinkPerson(int personID, int interestID, string url)
        {
            var result = new PersonInterest
            {
                PersonID = personID,
                InterestID = interestID,
                Links = new List<Link>() { new Link { Url = url } }
            };

            _dbContext.PersonInterests.Add(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetPersonInterest(int id)
        {
            var personInterest = await _dbContext.PersonInterests.Where(p => p.PersonID == id).Select(p => p.Interest).ToListAsync();

            return personInterest;


        }

        public async Task<IEnumerable<Link>> GetPersonLinks(int id)
        {
            return await _dbContext.PersonInterests.Where(p => p.PersonID == id).SelectMany(u => u.Links).ToListAsync();

            

        }
    }
}
