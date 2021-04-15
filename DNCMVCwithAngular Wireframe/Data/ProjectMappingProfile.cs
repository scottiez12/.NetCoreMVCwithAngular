using AutoMapper;
using DNCMVCwithAngular_Wireframe.Data.Entities;
using DNCMVCwithAngular_Wireframe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                //so when it's looking for OrderId, map it from the source Id..
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
