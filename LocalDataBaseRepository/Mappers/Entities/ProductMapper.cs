using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Product.Responses;
using LocalDataBaseRepository.Entities;
using Interfaces.Product.Request;

namespace LocalDataBaseRepository.Mappers.Entities
{
    public class ProductMapper
    {
        public static void Configure() {
            configureProductToGenericProduct();
            configureNewProductToProduct();
            configureNewProductToGenericProduct();
        }

        private static void configureProductToGenericProduct() {
            Mappers.MapperConfigurationSettings.MappingConfiguration.CreateMap<Product, GenericProduct>().
                    ForMember(genericProduct => genericProduct.Title, product => product.MapFrom(source => source.Name)).
                    ForMember(genericProduct => genericProduct.Number, product => product.MapFrom(source => source.Id)).
                    ForMember(genericProduct => genericProduct.Price, product => product.MapFrom(source => source.Price));
        }

        private static void configureNewProductToProduct()
        {
            Mappers.MapperConfigurationSettings.MappingConfiguration.CreateMap<NewProduct, Product>().
                    ForMember(genericProduct => genericProduct.Name, product => product.MapFrom(source => source.Title)).
                    ForMember(genericProduct => genericProduct.Price, product => product.MapFrom(source => source.Price));
        }

        private static void configureNewProductToGenericProduct()
        {
            Mappers.MapperConfigurationSettings.MappingConfiguration.CreateMap<NewProduct, GenericProduct>();
        }

    }
}
