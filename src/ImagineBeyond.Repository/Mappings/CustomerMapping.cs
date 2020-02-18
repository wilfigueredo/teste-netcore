using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImagineBeyond.Repository.Mappings
{
    public class CustomerMapping : EntityTypeConfiguration<CustomerEntity>
    {
        public override void Map(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .HasColumnType("varchar(150)");

            builder.Property(e => e.LastName)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Email)
                .HasColumnType("varchar(100)");     
        }
    }
}
