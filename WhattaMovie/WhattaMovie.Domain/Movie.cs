using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhattaMovie.Domain
{
    public class Movie
    {
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public float? AverageRating { get { return this.Ratings?.Average(r => r.MovieRating); } }
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }      
        public virtual ICollection<Rating> Ratings { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
