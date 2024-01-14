namespace CR_Proiect.Models
{
    public class Biserica
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Religie { get; set; }
        public int? RegeID { get; set; }
        public Rege? Rege { get; set; }
        public int? ReginaID { get; set; }
        public Regina? Regina { get; set; }
        public ICollection<Tara>? Tara { get; set; }
    }
}
