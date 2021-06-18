using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Data.Entity
{
    public class Category : Entity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}