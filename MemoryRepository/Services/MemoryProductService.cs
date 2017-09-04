using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Product.Request;
using Interfaces.Product.Responses;
using Interfaces.Product;
using AutoMapper;

namespace MemoryRepository.Services
{
    public class MemoryProductService : IProductService
    {
        private static SynchronizedCollection<GenericProduct> products=new SynchronizedCollection<GenericProduct>();

        public MemoryProductService() {
        }

        public Task<List<GenericProduct>> GetAllProducts()
        {
            return Task.FromResult(MemoryProductService.products.ToList());
        }

        public Task<GenericProduct> RegisterNewProduct(NewProduct newProduct)
        {
            GenericProduct product = Mapper.Map<GenericProduct>(newProduct);
            MemoryProductService.products.Add(product);
            product.Number=products.IndexOf(product)+1;
            return Task.FromResult(product);
        }
    }
}
