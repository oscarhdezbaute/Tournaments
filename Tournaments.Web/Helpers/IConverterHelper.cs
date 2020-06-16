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
    }
}
