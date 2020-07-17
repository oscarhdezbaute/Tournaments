using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tournaments.Web.Data.Entities;

namespace Tournaments.Web.Models
{
    public class TournamentViewModel : TournamentEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Sport")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a sport.")]
        public int SportId { get; set; }

        public IEnumerable<SelectListItem> Sports { get; set; }
    }
}
