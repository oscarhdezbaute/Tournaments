using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Tournaments.Web.Data.Entities;

namespace Tournaments.Web.Models
{
    public class TeamViewModel : TeamEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
