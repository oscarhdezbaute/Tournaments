﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tournaments.Web.Data.Entities;

namespace Tournaments.Web.Models
{
    public class MatchViewModel : MatchEntity
    {
        public int GroupId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Local")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a team.")]
        public int LocalId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Visitor")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a team.")]
        public int VisitorId { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }

    }
}
