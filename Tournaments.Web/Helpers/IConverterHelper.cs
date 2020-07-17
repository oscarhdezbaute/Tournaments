using System.Threading.Tasks;
using Tournaments.Web.Data.Entities;
using Tournaments.Web.Models;

namespace Tournaments.Web.Helpers
{
    public interface IConverterHelper
    {
        TeamEntity ToTeamEntity(TeamViewModel model, string path, bool isNew);

        TeamViewModel ToTeamViewModel(TeamEntity teamEntity);

        SportEntity ToSportEntity(SportViewModel model, string path, bool isNew);

        SportViewModel ToSportViewModel(SportEntity sportEntity);

        Task<TournamentEntity> ToTournamentEntity(TournamentViewModel model, string path, bool isNew);

        TournamentViewModel ToTournamentViewModel(TournamentEntity tournamentEntity);
        
        Task<GroupEntity> ToGroupEntityAsync(GroupViewModel model, bool isNew);

        GroupViewModel ToGroupViewModel(GroupEntity groupEntity);

        Task<GroupDetailEntity> ToGroupDetailEntityAsync(GroupDetailViewModel model, bool isNew);

        GroupDetailViewModel ToGroupDetailViewModel(GroupDetailEntity groupDetailEntity);

        Task<MatchEntity> ToMatchEntityAsync(MatchViewModel model, bool isNew);

        MatchViewModel ToMatchViewModel(MatchEntity matchEntity);


    }
}
