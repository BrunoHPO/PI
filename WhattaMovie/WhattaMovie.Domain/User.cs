using System;
using System.Collections;
using System.Collections.Generic;
using WhattaMovie.Domain;

namespace WhattaMovie
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public virtual ICollection<Movie> Movies {get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
