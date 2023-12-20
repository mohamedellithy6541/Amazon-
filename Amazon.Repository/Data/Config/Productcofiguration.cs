using Amozon.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Repository.Data.Configuration
{
    public class Productcofiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Description);
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductTypes).WithMany().HasForeignKey(p => p.ProductTypeId);

        }
    }
}
