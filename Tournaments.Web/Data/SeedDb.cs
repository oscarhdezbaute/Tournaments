using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournaments.Web.Data.Entities;

namespace Tournaments.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTeamsAsync();
            await CheckSportsAsync();
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
                await _context.SaveChangesAsync();
            }
        }

        private void AddTeam(string name)
        {
            _context.Teams.Add(new TeamEntity { Name = name, LogoPath = $"~/images/Teams/{name}.jpg" });
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
                            LogoPath = $"~/images/Tournaments/Copa America 2020.png",
                            Name = "Copa America 2020",
                            Groups = new List<GroupEntity>
                            {
                            new GroupEntity
                            {
                                 Name = "A",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Colombia") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Panama") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Canada") }
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Panama"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(4).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(4).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Canada")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(9).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Canada"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Colombia")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(9).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Panama")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "B",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Argentina") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Mexico") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Chile") }
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(1).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(1).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Mexico"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(5).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(5).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Chile")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(10).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Chile"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Argentina")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(10).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "C",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Brasil") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "USA") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Peru") }
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(2).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(2).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "USA"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(6).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(6).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Peru")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(11).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Peru"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Brasil")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(11).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "USA")
                                     }
                                 }
                            },
                            new GroupEntity
                            {
                                 Name = "D",
                                 GroupDetails = new List<GroupDetailEntity>
                                 {
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica") },
                                     new GroupDetailEntity { Team = _context.Teams.FirstOrDefault(t => t.Name == "Honduras") }
                                 },
                                 Matches = new List<MatchEntity>
                                 {
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(3).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(3).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(7).AddHours(14),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(7).AddHours(17),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(12).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Honduras"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Uruguay")
                                     },
                                     new MatchEntity
                                     {
                                         Date = startDate.AddDays(12).AddHours(16),
                                         Local = _context.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                         Visitor = _context.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                     }
                                 }
                            }
                            }
                        }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }


}
