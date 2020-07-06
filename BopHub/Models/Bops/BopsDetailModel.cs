using BopHub.Models.Validation;
using BopHubData.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BopHub.Models.Bops
{
    public class BopsDetailModel
    {
        public int BopId { get; set; }
        [Required]
        [StringLength(40), MinLength(4)]
        public string BopName { get; set; }
        [Required] public string Artiste { get; set; }
        [Required] [FutureDate] public string ReleaseDate { get; set; }
        [Required] public string ReleaseTime { get; set; }
        [Required]
        public string ReleaseVenue { get; set; }
        [Required]
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
