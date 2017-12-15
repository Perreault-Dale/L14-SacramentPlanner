using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class MeetingProgram
    {
        public int id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM, yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime programDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Conducting")]
        public string Conduct { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Presiding")]
        public string Preside { get; set; }

        public bool Sacrament { get; set; }

        public ICollection<Hymn> Hymns { get; set; }
        public ICollection<Talk> Talks { get; set; }
        public ICollection<Prayer> Prayers { get; set; }
    }
}
