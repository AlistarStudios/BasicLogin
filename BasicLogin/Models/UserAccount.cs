using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BasicLogin.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only letter allowed")]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only letter allowed")]
        [StringLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime BirthDate { get; set; }
    }
}
