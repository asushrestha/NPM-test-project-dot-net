using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>{
                    new User{FullName="Asmin Shrestha",Email="shrestha.asmin17@gmail.com",Contact="9860099303",UserName="shrestha.asmin17@gmail.com"},
                    new User{FullName="Nimsa Shrestha",Email="shrestha.asmin13@gmail.com",Contact="9823446552",UserName="shrestha.asmin13@gmail.com"},
                    new User{FullName="Teresa Shrestha",Email="shrestha.asmin11@gmail.com",Contact="9841221010",UserName="shrestha.asmin11@gmail.com"}
                };
                foreach(var user in users){
                    await userManager.CreateAsync(user,"Sl@p4msth");
                }
            }

            if (context.Nurses.Any()) return;

            var nurses = new List<Nurse>
            {
                new Nurse
                {
                    FullName = "Past Nurse 1",
                    CreatedAt = DateTime.UtcNow.AddMonths(-2),
                    Contact = "Nurse 2 months ago",
                    Email = "drinks",
                    IsRoundingManager = false
                },
                new Nurse
                {
                    FullName = "Past Nurse 2",
                    CreatedAt = DateTime.UtcNow.AddMonths(-1),
                    Contact = "Nurse 1 month ago",
                    Email = "culture",
                                        IsRoundingManager = false



                },
                new Nurse
                {
                    FullName = "Future Nurse 1",
                    CreatedAt = DateTime.UtcNow.AddMonths(1),
                    Contact = "Nurse 1 month in future",
                    Email = "culture",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 2",
                    CreatedAt = DateTime.UtcNow.AddMonths(2),
                    Contact = "Nurse 2 months in future",
                    Email = "music",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 3",
                    CreatedAt = DateTime.UtcNow.AddMonths(3),
                    Contact = "Nurse 3 months in future",
                    Email = "drinks",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 4",
                    CreatedAt = DateTime.UtcNow.AddMonths(4),
                    Contact = "Nurse 4 months in future",
                    Email = "drinks",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 5",
                    CreatedAt = DateTime.UtcNow.AddMonths(5),
                    Contact = "Nurse 5 months in future",
                    Email = "drinks",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 6",
                    CreatedAt = DateTime.UtcNow.AddMonths(6),
                    Contact = "Nurse 6 months in future",
                    Email = "music",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 7",
                    CreatedAt = DateTime.UtcNow.AddMonths(7),
                    Contact = "Nurse 2 months ago",
                    Email = "travel",
                                        IsRoundingManager = false

                },
                new Nurse
                {
                    FullName = "Future Nurse 8",
                    CreatedAt = DateTime.UtcNow.AddMonths(8),
                    Contact = "Nurse 8 months in future",
                    Email = "film",
                    IsRoundingManager = false
                }
            };

            await context.Nurses.AddRangeAsync(nurses);
            await context.SaveChangesAsync();
        }
    }
}