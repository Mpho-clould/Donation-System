using System.ComponentModel.DataAnnotations;

namespace POE_PART1.Models
{
    public class activeDisaster
    {
        [Key]
        public string Distaster_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Location { get; set; }
        public string Aid_Types { get; set; }
    }
}

