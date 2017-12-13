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

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-dd-MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime talkDate { get; set; }

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
