using Interfaces.Product.Request;
using Interfaces.Product.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Product
{
    public interface IProductService
    {
        Task<List<GenericProduct>> GetAllProducts();
        Task<GenericProduct> RegisterNewProduct(NewProduct newProduct);
    }
}
