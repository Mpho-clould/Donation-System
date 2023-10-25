using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_PART1.Models
{
    public class MoneysAllocate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("disaster")]
        public string Distaster_Name { get; set; }

        public float Amount { get; set; }

        public activeDisaster? disaster { get; set; }
    }
}
