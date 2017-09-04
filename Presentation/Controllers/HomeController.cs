using Interfaces.Product;
using Interfaces.Product.Request;
using Interfaces.Product.Responses;
using LocalDataBaseRepository.Services;
using MemoryRepository.Services;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {

        private IProductService[] _productServices;

        public HomeController()
        {
            this._productServices = new IProductService[2];
            _productServices[0] = new MemoryProductService();
            _productServices[1] = new LocalDatabaseProductService();
        }

        public ActionResult Index(string dataSource)
        {
            ProductSubmit productSubmit = this.getProductViewModel();
            return View(productSubmit);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ProductSubmit productSubmit)
        {
            ProductSubmit emptyModel = this.getProductViewModel();
            if (ModelState.IsValid)
            {
                string serviceName = productSubmit.SelectedSourceType;
                IProductService service = this.getServiceByName(serviceName);
                NewProduct product = productSubmit.getProductToRegister();
                await service.RegisterNewProduct(product);
                emptyModel.SelectedSourceType = serviceName;
                emptyModel.commitSuccess = true;
                return View(emptyModel);
            }
            productSubmit.SourceTypes = emptyModel.SourceTypes;
            return View(productSubmit);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductTable(string type)
        {
            IProductService service = this.getServiceByName(type);
            List<GenericProduct> products = service.GetAllProducts().Result;
            return PartialView(products);
        }

        private IProductService getServiceByName(string className)
        {
            IProductService service = this._productServices.FirstOrDefault(x => x.GetType().Name.Equals(className));
            if (service == null) {
                throw new InvalidOperationException("Not supported product source");
            }
            return service;
        }

        private List<SelectListItem> getDataSources()
        {
            return this._productServices.Select(service => service.GetType().Name).Select(name=>new SelectListItem
            {
                Text = name,
                Value = name
            }).ToList();
        }

        private ProductSubmit getProductViewModel()
        {
            ProductSubmit productSubmit = new ProductSubmit();
            productSubmit.SourceTypes = this.getDataSources();
            productSubmit.SelectedSourceType = productSubmit.SourceTypes.First().Text;
            return productSubmit;
        }

    }
}