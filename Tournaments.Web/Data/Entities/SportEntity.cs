using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournaments.Web.Data.Entities
{
    public class SportEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        public ICollection<TournamentEntity> Tournaments { get; set; }

    }
}
