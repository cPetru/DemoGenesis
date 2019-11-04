using System;

namespace ContactsApi.Models
{
    //Composite PK
    public class Collaboration
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }


        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }


        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

    }
}