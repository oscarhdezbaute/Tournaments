using Tournaments.Web.Data.Entities;
using Tournaments.Web.Models;

namespace Tournaments.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public SportEntity ToSportEntity(SportViewModel model, string path, bool isNew)
        {
            return new SportEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public SportViewModel ToSportViewModel(SportEntity sportEntity)
        {
            return new SportViewModel
            {
                Id = sportEntity.Id,
                LogoPath = sportEntity.LogoPath,
                Name = sportEntity.Name
            };
        }

        public TeamEntity ToTeamEntity(TeamViewModel model, string path, bool isNew)
        {
            return new TeamEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(TeamEntity teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                LogoPath = teamEntity.LogoPath,
                Name = teamEntity.Name
            };
        }
    }
}
