using System.ComponentModel.DataAnnotations;

namespace TeckRoad.Presentation.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{3}$", ErrorMessage = "Like 1234")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Must be 11 numbers with a valid company initial(010)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string? RegisterationInvalid { get; set; }
    }
}