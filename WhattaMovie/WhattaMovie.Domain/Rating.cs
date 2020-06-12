using System;
using System.Collections.Generic;
using System.Text;

namespace WhattaMovie.Domain
{
    public class Rating
    {
        public int ID { get; set; }
        public float? MovieRating { get; set; }
        public int OwnerID { get; set; }
        public virtual User Owner { get; set; }
        public int MovieID { get; set; }   
        public virtual Movie Movie { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
