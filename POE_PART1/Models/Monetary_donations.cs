namespace POE_PART1.Models
{
    public class Monetary_donations
    {
        public int Id { get; set; }
        public bool Anonymous { get; set; }

        public string Name { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
       
        public Monetary_donations() { }
    }
}
