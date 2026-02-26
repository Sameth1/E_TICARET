using AutoMapper;
using Core.Concrates.DTOs.CustomerDTOs;
using Core.Concrates.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Maps
{
    public class CustomerMap : Profile
    {
        public CustomerMap()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.CurrentCartId, opt => opt.MapFrom(src => src.Carts.FirstOrDefault().Id));
        }
    }
}
