using System;

namespace ReadingIsGood.Data.Entity
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Deleted { get; set; }
    }
}