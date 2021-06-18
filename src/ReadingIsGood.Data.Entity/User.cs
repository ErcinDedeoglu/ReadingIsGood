using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Data.Entity
{
    public class User : Entity
    {
        [Required, MaxLength(256)]
        public string FirstName { get; set; }

        [Required, MaxLength(256)]
        public string LastName { get; set; }

        [Required, MaxLength(64)]
        public string Username { get; set; }

        [Required, MaxLength(64)]
        public string Password { get; set; }
    }
}