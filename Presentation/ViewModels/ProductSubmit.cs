using Interfaces.Product.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.ViewModels
{
    public class ProductSubmit
    {
        [Display(Name ="Data Source to commit in")]
        public List<SelectListItem> SourceTypes { get; set; }
        public string SelectedSourceType { get; set; }
        [Required, DataType(DataType.Text)]
        public string Tittle { get; set; }
        [Required, DataType(DataType.Currency)]
        public int Price { get; set; }

        // This attribute is send to the front-end to inform that the data commited and the form needs to be clear
        public bool commitSuccess { get; set; } 

        public ProductSubmit() {
            this.commitSuccess = false;
        }

        public NewProduct getProductToRegister() {
            NewProduct newProduct = new NewProduct();
            newProduct.Price = this.Price;
            newProduct.Title = this.Tittle;
            return newProduct;
        }
    }
}