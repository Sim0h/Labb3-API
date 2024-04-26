using System.ComponentModel.DataAnnotations;

namespace Labb3_API.data
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }
        public string Url { get; set; }
        
        public int PersonInterestID { get; set; }
        public PersonInterest PersonInterest { get; set; }
    }
}
