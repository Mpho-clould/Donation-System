namespace POE_PART1.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string Purchase_Item { get;set; }
        public int Number_Of_Iteams { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    }
}
