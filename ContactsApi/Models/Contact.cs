namespace ContactsApi.Models
{
    public abstract class Contact : BaseEntity, IHaveMainAddress
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public Address MainAddress { get; set; }
    }
}