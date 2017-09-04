using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces.Product;
using LocalDataBaseRepository.Services;
using Interfaces.Product.Request;
using Interfaces.Product.Responses;
using System.Threading.Tasks;
using System.Collections.Generic;
using MemoryRepository.Services;

namespace ProductServiceUnitTest
{
    [TestClass]
    public class ProductServiceTest
    {
        public List<IProductService> _ProductServices = new List<IProductService>() {
                new MemoryProductService(),
                new LocalDatabaseProductService()
        };

        [TestMethod]
        public void CreateProduct()
        {
            foreach (IProductService service in _ProductServices) {
                GenericProduct registeredProduct = createTestProduct(service);
                Assert.AreEqual(true, registeredProduct.Number > 0);
            }
        }

        [TestMethod]
        public void ListProducts()
        {
            foreach (IProductService service in _ProductServices)
            {
                createTestProduct(service);
                List<GenericProduct> registeredProducts = getAllProducts(service);
                Assert.AreEqual(true, registeredProducts.Count > 0);
            }
        }

        private GenericProduct createTestProduct(IProductService _ProductService ) {
            NewProduct productToRegister = new NewProduct();
            productToRegister.Price = 10;
            productToRegister.Title = "Test Product";
            return _ProductService.RegisterNewProduct(productToRegister).Result;
        }

        private List<GenericProduct> getAllProducts(IProductService _ProductService) {
            _ProductService = new LocalDatabaseProductService();
            return _ProductService.GetAllProducts().Result;
        }
    }
}
