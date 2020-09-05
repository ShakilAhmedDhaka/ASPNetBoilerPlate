using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class UCredential
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Role{ get; set; }

        public virtual UProfile Uprofile { get; set; }
    }
}
