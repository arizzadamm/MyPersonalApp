namespace MyPersonalApp.Models
{
    public class Gaji
    {
        public Guid id { get; set; }
        public string Nominal { get; set; }
        public string Kurs { get; set; }
    }

    class Upah : Gaji
    {

    }
}