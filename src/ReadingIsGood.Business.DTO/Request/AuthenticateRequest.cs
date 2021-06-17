using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Business.DTO.Request
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}