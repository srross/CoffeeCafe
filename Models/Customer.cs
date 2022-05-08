using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeCafe.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} is required")]
        //[Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters.")]
        public string FirstName { get; set; }


        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }


        [DisplayName("BrewCrew Member")]
        public bool IsBrewCrew { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        //[Range(8, 50, ErrorMessage = "{0} must be between {1} and {2}.")]
        [StringLength(50, ErrorMessage = "{0} must be between 5 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("ConfirmPassword")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and PasswordConfirmation fields must match")]
        public string ConfirmPassword { get; set; }


        [DisplayName("Created Date")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime CreatedDate { get; set; }


        [DisplayName("Updated Date")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime UpdatedDate { get; set; }
    }
}
