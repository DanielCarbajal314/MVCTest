using Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Product.Request;
using Interfaces.Product.Responses;
using LocalDataBaseRepository.Context;
using LocalDataBaseRepository.Entities;
using System.Data.Entity;
using AutoMapper;
using LocalDataBaseRepository.Mappers;

namespace LocalDataBaseRepository.Services
{
    public class LocalDatabaseProductService : IProductService
    {

        public LocalDatabaseProductService() {
            MapperConfigurationSettings.InitializeMaps();
        }


        public async Task<List<GenericProduct>> GetAllProducts()
        {
            using (ShopDbContext shopDatabase = new ShopDbContext())
            {
                List<Product> products = shopDatabase.Products.ToList();
                return products.Select(product => Mapper.Map<GenericProduct>(product)).ToList();
            }
        }

        public async Task<GenericProduct> RegisterNewProduct(NewProduct newProduct)
        {
            using (ShopDbContext shopDatabase = new ShopDbContext())
            {
                Product productToRegister = Mapper.Map<Product>(newProduct);
                shopDatabase.Products.Add(productToRegister);
                await shopDatabase.SaveChangesAsync();
                return Mapper.Map<GenericProduct>(productToRegister);
            }
        }
    }
}
