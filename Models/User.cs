using System.ComponentModel.DataAnnotations;

namespace LABAPI.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(0, 150)]
        public int Age { get; set; }
    }
}
