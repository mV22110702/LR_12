using LR_12.Models;

namespace LR_12.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var companies = new List<Company>
            {
                new Company{Name="Apple",EstablishedDate=new DateTime(1976,4,1)},
                new Company{Name = "Microsoft", EstablishedDate=new DateTime(1975,4,4)},
                new Company{Name = "Audi", EstablishedDate=new DateTime(1909,7,16)},
                new Company{Name = "Samsung",EstablishedDate=new DateTime(1938,3,1)},
                new Company{Name = "Intel", EstablishedDate=new DateTime(1968,7,18)}
            };
            foreach (var company in companies)
            {
                context.Companies.Add(company);
            }
            var users = new List<User>
            {
                new User{FirstName="John",LastName="Reddington",Company=companies[0], Age=21},
                new User{FirstName = "Mike", LastName = "Clark",Company=companies[1],Age=20},
                new User{FirstName = "Steve", LastName = "Murray",Company=companies[2],Age=28}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

        }
    }
}
