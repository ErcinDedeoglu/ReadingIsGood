using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Data.Entity
{
    public class Customer : Entity
    {
        [Required, MaxLength(256)]
        public string FirstName { get; set; }

        [Required, MaxLength(256)]
        public string LastName { get; set; }

        public virtual ICollection<Order> OrderDetails { get; set; }
    }
}