using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Configuration.Ordering
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "Ordering");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired(false);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.PaymentMethodId).IsRequired(false);
            builder.Property(x => x.OrderStatusId).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.HasMany(x => x.OrderItems).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);
        }
    }
}
