using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApi.DataContext
{
    public class CollaborationEntityConfiguration : IEntityTypeConfiguration<Collaboration>
    {
        public void Configure(EntityTypeBuilder<Collaboration> builder)
        {
            builder.HasKey(pt => new { pt.CompanyId, pt.ContactId });
        }
    }


}