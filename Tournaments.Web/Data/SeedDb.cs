using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournaments.Common.Enums;
using Tournaments.Web.Data.Entities;
using Tournaments.Web.Helpers;

namespace Tournaments.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("84070314209", "Oscar", "Hernández", "elpuya84@gmail.com", "230 939 2747", "Ave 54", UserType.Admin);
            await CheckUserAsync("87110214209", "Victor Manuel", "González", "leyanis.albo@gmail.com", "230 349 2747", "Fort Laurdale", UserType.User);
            await CheckTeamsAsync();
            await CheckSportsAsync();
            await CheckPreditionsAsync();
        }

        private async Task<UserEntity> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    Team = _context.Teams.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckTeamsAsync()
        {
            if (!_context.Teams.Any())
            {
                AddTeam("Argentina");
                AddTeam("Bolivia");
                AddTeam("Brasil");
                AddTeam("Canada");
                AddTeam("Chile");
                AddTeam("Colombia");
                AddTeam("Costa Rica");
                AddTeam("Ecuador");
                AddTeam("Honduras");
                AddTeam("Mexico");
                AddTeam("Panama");
                AddTeam("Paraguay");
                AddTeam("Peru");
                AddTeam("Uruguay");
                AddTeam("USA");
                AddTeam("Venezuela");
                
                AddTeam("FCBarcelona");
                AddTeam("Napoles");
                AddTeam("BayerMunich");
                AddTeam("Chelsea");
                AddTeam("PSG");
                AddTeam("borrusia");
                AddTeam("RealMadrid");
                AddTeam("ManchesterCity");
                AddTeam("Liverpool");
                AddTeam("AtleticoMadrid");

                await _context.SaveChangesAsync();
            }
        }

        private void AddTeam(string name)
        {
            _context.Teams.Add(new TeamEntity { Name = name, LogoPath = $"~/images/Teams/{name}.png" });
        }

        private async Task CheckSportsAsync()
        {
            if (!_context.Sports.Any())
            {
                _context.Sports.Add(new SportEntity
                {
                    Name = "Baseball",
                    LogoPath = $"~/images/Sports/Baseball.png",
                });

                _context.Sports.Add(new SportEntity
                {
                    Name = "Basketball",
                    LogoPath = $"~/images/Sports/Basketball.png",
                });

                DateTime startDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                DateTime endDate = DateTime.Today.AddMonths(3).ToUniversalTime();

                _context.Sports.Add(new SportEntity
                {
                    Name = "Soccer",
                    LogoPath = $"~/images/Sports/Soccer.png",
                    Tournaments = new List<TournamentEntity>
                    {
                        new TournamentEntity
                        {
                            StartDate = startDate,
                            EndDate = endDate,
                            IsActive = true,
                            LogoPath = $"~/images/Tournaments/Champions.jpg",
                            Name = "Champions League 2020",
                            Groups = new List<GroupEntity>
                            {
                            new GroupEntity
                            {
                                 Name = "A",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "BayerMunich") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea") },                                    
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "BayerMunich"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "BayerMunich")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "B",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "FCBarcelona") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Napoles") },
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Napoles"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "FCBarcelona")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "FCBarcelona"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Napoles")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "C",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "RealMadrid") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "ManchesterCity") },
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "RealMadrid"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "ManchesterCity")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "ManchesterCity"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "RealMadrid")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "D",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "AtleticoMadrid") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Liverpool") },
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "AtleticoMadrid"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Liverpool")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Liverpool"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "AtleticoMadrid")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "E",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "borrusia") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "PSG") },
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "borrusia"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "PSG")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "PSG"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "borrusia")
                                     }
                                 }
                            },
                            }
                        }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPreditionsAsync()
        {
            if (!_context.Predictions.Any())
            {
                foreach (var user in _context.Users)
                {
                    if (user.UserType == UserType.User)
                    {
                        AddPrediction(user);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        private void AddPrediction(UserEntity user)
        {
            var random = new Random();
            foreach (var match in _context.Matches)
            {
                _context.Predictions.Add(new PredictionEntity
                {
                    GoalsLocal = random.Next(0, 5),
                    GoalsVisitor = random.Next(0, 5),
                    Match = match,
                    User = user
                });
            }
        }

    }

}
