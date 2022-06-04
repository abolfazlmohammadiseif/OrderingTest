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
            CreateMap<Domain.Models.Order, OrderDto>().ReverseMap();

        }
    }
}
