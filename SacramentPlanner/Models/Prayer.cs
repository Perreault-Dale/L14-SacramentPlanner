using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public enum PrayerLocation
    {
        Invocation,
        Benediction
    }

    public class Prayer
    {
        public int id { get; set; }

        public int MeetingProgramID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Offered By")]
        public string speaker { get; set; }

        [Required]
        [Display(Name = "Location")]
        public PrayerLocation location { get; set; }
    }
}
