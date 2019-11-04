namespace ContactsApi.Models
{
    public class Freelance : Contact, IHaveVAT
    {
        public string VAT { get; set; }
    }
}