using Amazon.Repository.Context;
using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Repository.Data
{
    public class storeContextseed
    {
        public static async Task AddseedAsync(StoreContext context)
        {
            if (!context.productBrands.Any())
            {
                var branddata = File.ReadAllText("../Amazon.Repository/Data/dataseed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                if (brands is not null && brands.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        await context.Set<ProductBrand>().AddAsync(brand);

                    }
                    await context.SaveChangesAsync();
                }
            }
            if (!context.ProductTypes.Any())
            {
                var typedata = File.ReadAllText("../Amazon.Repository/Data/dataseed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typedata);

                if (types is not null && types.Count > 0)
                {
                    foreach (var Type in types)
                    {
                        await context.Set<ProductType>().AddAsync(Type);

                    }
                    await context.SaveChangesAsync();
                }
            }
            if (!context.products.Any())
            {
                var Productdata = File.ReadAllText("../Amazon.Repository/Data/dataseed/products.json");
                var products = JsonSerializer.Deserialize<List<Products>>(Productdata);
                if (products is not null && products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        await context.Set<Products>().AddAsync(product);

                    }
                    await context.SaveChangesAsync();
                }
            }
            
            if (!context.deliveryMethods.Any())
            {
                var DevivermethodData = File.ReadAllText("../Amazon.Repository/Data/dataseed/delivery.json");
                var deliveymethod = JsonSerializer.Deserialize<List<DeliveryMethod>>(DevivermethodData);
                if (deliveymethod is not null && deliveymethod.Count > 0)
                {
                    foreach (var delivery in deliveymethod)
                    {
                        await context.Set<DeliveryMethod>().AddAsync(delivery);

                    }
                    await context.SaveChangesAsync();
                }
            }



        }

    }
}
