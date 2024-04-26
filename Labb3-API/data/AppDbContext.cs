using Microsoft.EntityFrameworkCore;

namespace Labb3_API.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 1, FirstName = "Noah", LastName="Testing", PhoneNum = "1234567" });
            modelBuilder.Entity<Person>().HasData(new Person{ PersonID = 2, FirstName = "Simon", LastName = "Zooming", PhoneNum = "1234567" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 3, FirstName = "Casper", LastName = "Flyson", PhoneNum = "1234567" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 4, FirstName = "Svante", LastName = "Svensson", PhoneNum = "1234567" });




            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 100,
                InterestName = "Gaming",
                InterestDescription = "Playing video games"

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 101,
                InterestName = "Exercise",
                InterestDescription = "Any type of exercise like running, sports or gym"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 102,
                InterestName = "Reading",
                InterestDescription = "Reading books"

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 103,
                InterestName = "Football",
                InterestDescription = "Following the different football leauges in Europe"

            });


            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 50, Url = "www.youtube.com", PersonInterestID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 51, Url = "www.transfermarkt.com", PersonInterestID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 52, Url = "www.books.com", PersonInterestID = 2 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 53, Url = "www.running.com", PersonInterestID = 2 });




            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestID = 1,
                PersonID = 1,
                InterestID = 100,
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestID = 2,
                PersonID = 2,
                InterestID = 102,
            });
        }
    }
}
