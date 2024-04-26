using Labb3_API.data;

namespace Labb3_API.Services
{
    public interface IApp
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Interest>> GetPersonInterest(int id);
        Task<IEnumerable<Link>> GetPersonLinks(int id);
        Task AddInterestPerson(int personID, int interest);
        Task AddLinkPerson(int personID, int interestID, string url);
    }
}
