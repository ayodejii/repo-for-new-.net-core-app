using System.ComponentModel.DataAnnotations;

namespace BopHubData.Model
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(40), MinLength(4)]
        public string Name { get; set; }
    }
}
