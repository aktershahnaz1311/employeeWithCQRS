using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistence.Configurations;

public  class ProductConfiguration : IEntityTypeConfiguration<Products>
{
    public void  Configure(EntityTypeBuilder<Products> builder)   
    {

        builder.HasKey(e => e.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.Products).HasForeignKey(x => x.CountryId);
       

        builder.HasData(new
        {
            Id=1,
            ProductName ="Laptop",
            Description = "Brand New Model",
            CountryId = 1,
            Age=25,
            Rating= 4.5,
           Price=50000.00,
           BarCode="bashar",
           SellPrice=52000.00,
            Created=DateTimeOffset.Now,
            CreatedBy="1",
            LastModified=DateTimeOffset.Now,
           Status =EntityStatus.Created
        });



    }



}
