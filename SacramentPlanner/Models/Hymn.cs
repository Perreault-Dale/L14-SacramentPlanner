using System;
using System.ComponentModel.DataAnnotations;

namespace SacramentPlanner.Models
{
    public enum HymnLocation
    {
        Opening,
        Sacrament,
        Intermediate,
        Closing
    }

    public class Hymn
    {
        public int id { get; set; }

        public int MeetingProgramID { get; set; }

        [Required]
        [Display(Name = "Number")]
        [Range(1, 341)]
        public int? hymnNumber { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Location")]
        public HymnLocation location { get; set; }
    }
}
