using System.ComponentModel.DataAnnotations;

namespace Labb3_API.data
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string PhoneNum { get; set; }

        public ICollection<PersonInterest> PersonInterest { get; set; }
        
    }
}
