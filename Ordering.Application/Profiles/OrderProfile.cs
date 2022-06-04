using AutoMapper;
using Ordering.Application.Services.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Domain.Models.Order>();
            CreateMap<Domain.Models.Order, OrderViewModel>();
            CreateMap<OrderItemDto, Domain.Models.OrderItem>();
            CreateMap<Domain.Models.OrderItem, OrderItemViewModel>();


        }
    }
}
