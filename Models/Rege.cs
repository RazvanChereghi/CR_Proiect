namespace CR_Proiect.Models
{
    public class Rege
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nationalitate { get; set; }
        public int Varsta { get; set; }
        public ICollection<Biserica>? Biserica { get; set; }
    }
}
