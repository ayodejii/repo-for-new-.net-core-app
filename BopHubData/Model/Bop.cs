using System;
using System.ComponentModel.DataAnnotations;

namespace BopHubData.Model
{
    public class Bop
    {
        public int BopId { get; set; }
        [Required]
        [StringLength(40), MinLength(4)]
        public string BopName { get; set; }
        public Account Artiste { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string ReleaseVenue { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
