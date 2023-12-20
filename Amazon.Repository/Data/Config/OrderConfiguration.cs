using Amozon.Core.Entites.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Repository.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShappingAddress, ShippingAddresss => ShippingAddresss.WithOwner());
            builder.Property(o => o.status).HasConversion(
             ostatus=>ostatus.ToString(),
             ostatus=> (OrderStatus)Enum.Parse(typeof(OrderStatus), ostatus)
                );
            builder.Property(o=>o.SubTotal).HasColumnType("decimal(18,2)");


        }
    }
}
