using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentPlanner.Models
{
    public class Talk
    {
        public const int NUM_SPEAKERS = 3;

        public int id { get; set; }

        public int MeetingProgramID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Speaker")]
        public string speaker { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Topic")]
        public string topic { get; set; }

        [Display(Name = "Assigned Reading")]
        public string Reading { get; set; }

        [Required]
        [Display(Name = "Speaker Order")]
        [Range(0, NUM_SPEAKERS)]
        public int order { get; set; }
    }
}
