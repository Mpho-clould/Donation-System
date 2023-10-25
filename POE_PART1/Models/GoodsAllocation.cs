using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_PART1.Models
{
    public class GoodsAllocation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("disaster")]
        public string Distaster_Name { get; set; }
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public int Number_of_Iteams { get; set; }
        public activeDisaster? disaster { get; set; } 
        public Category? Category { get; set; }

    }
}
