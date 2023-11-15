using LR_12.Models;

namespace LR_12.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            var users = new List<User>
            {
                new User{FirstName="John",LastName="Reddington",},
                new User{FirstName = "Mike", LastName = "Clark"},
                new User{FirstName = "Steve", LastName = "Murray"}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

        }
    }
}
