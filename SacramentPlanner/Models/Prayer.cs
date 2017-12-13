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

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-dd-MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime prayerDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Offered By")]
        public string speaker { get; set; }

        [Required]
        [Display(Name = "Location")]
        public PrayerLocation location { get; set; }
    }
}
