using AutoMapper;
using Core.Concrates.DTOs.ProductionDTOs;
using Core.Concrates.Entities.ProductionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Maps
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<Product, ProductListItemDTO>()
     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * (1 + src.TaxRate / 100)))
     .ForMember(dest => dest.CoverImageURL, opt => opt.MapFrom(src => src.CoverImageURL))
     .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.Price * (1 - src.DiscountRate / 100) * (1 + src.TaxRate / 100)));


            CreateMap<Brand, BrandDTO>()
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<ProductAttribute, AttributeListItemDTO>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<ProductMedia, GalleryItemDTO>()
                .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.MediaType))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source));

            CreateMap<Product, ProductDetailDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * (1 + src.TaxRate / 100)))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.DiscountRate))
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.Price * (1 - src.DiscountRate / 100) * (1 + src.TaxRate / 100)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CoverImageURL, opt => opt.MapFrom(src => src.CoverImageURL))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Gallery, opt => opt.MapFrom(src => src.Gallery))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes));












        }

    }
}
