using System.Collections.Generic;

namespace Tournaments.Common.Models
{
    public class SportResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string LogoPath { get; set; }

        public ICollection<TournamentResponse> Tournaments { get; set; }
    }
}
