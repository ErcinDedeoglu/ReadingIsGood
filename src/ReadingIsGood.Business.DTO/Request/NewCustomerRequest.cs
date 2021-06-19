using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Business.DTO.Request
{
    public class NewCustomerRequest
    {
        [Required(ErrorMessage = "Name field is required.")]
        [MinLength(2, ErrorMessage = "The customer's name can be at least 2 characters.")]
        [MaxLength(256, ErrorMessage = "The customer's name can be up to 256 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field is required.")]
        [MinLength(2, ErrorMessage = "The customer's last name can be at least 2 characters.")]
        [MaxLength(256, ErrorMessage = "The customer's last name can be up to 256 characters.")]
        public string LastName { get; set; }
    }
}