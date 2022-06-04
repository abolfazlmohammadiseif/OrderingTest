using FluentValidation;
using Ordering.Application.Services.Orders.Dto;

namespace Ordering.Api.Validation
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderItems).NotEmpty();
        }
    }
}