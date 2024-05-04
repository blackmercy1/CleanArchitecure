using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    protected MenuReview(MenuReviewId id) : base(id)
    {
    }
}