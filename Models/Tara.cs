namespace CR_Proiect.Models
{
    public class Tara
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Suprafata { get; set; }
        public string Capitala { get; set; }
        public string Regiune { get; set; }
        public int? BisericaID { get; set; }
        public Biserica? Biserica { get; set; }
    }
}
