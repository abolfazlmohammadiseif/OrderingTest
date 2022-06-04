using FluentValidation;
using Ordering.Application.Services.Orders.Dto;

namespace Ordering.Api.Validation
{
    public class OrderItemValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.Units).GreaterThan(0);
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);
        }
    }
}