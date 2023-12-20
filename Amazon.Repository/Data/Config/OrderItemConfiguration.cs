using Amozon.Core.Entites.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Repository.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.OwnsOne(orderItems => orderItems.Product, product => product.WithOwner());
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");   
        }
    }
}
