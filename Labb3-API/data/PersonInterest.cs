﻿using System.ComponentModel.DataAnnotations;

namespace Labb3_API.data
{
    public class PersonInterest
    {
        [Key]
        public int PersonInterestID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int InterestID { get; set; }
        public Interest Interest { get; set; }
        public List<Link> Links { get; set; }
    }
}
