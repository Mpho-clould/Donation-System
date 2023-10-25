namespace POE_PART1.Models
{
    public class disaster
    {

        public int Id { get; set; }
        public bool Anonymous { get; set; }

        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Location { get; set; }
        public string Distaster_Name { get; set; }
        public string Aid_Types { get; set; }
    }
}
