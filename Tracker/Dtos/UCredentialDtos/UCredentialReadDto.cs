using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Dtos.UCredentialDtos
{
    public class UCredentialReadDto
    {
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
