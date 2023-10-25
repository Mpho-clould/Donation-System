using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_PART1.Models
{
    public class GoodsDonation
    {
        [Key]
        public int Id { get; set; }
        public bool Anonymous { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public int Number_of_Iteams { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Category? Category { get; set; }
    }
}
