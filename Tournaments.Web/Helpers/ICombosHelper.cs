using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tournaments.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboSports();
        IEnumerable<SelectListItem> GetComboTeams();
        IEnumerable<SelectListItem> GetComboTeams(int id);
    }
}
