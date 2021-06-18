using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Business.DTO.Request
{
    public class NewCustomerRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}