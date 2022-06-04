using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Configuration.Ordering
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem", "Ordering");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ProductName).IsRequired(false);
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.Discount).IsRequired();
            builder.Property(x => x.Units).IsRequired();
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
        }
    }
}
