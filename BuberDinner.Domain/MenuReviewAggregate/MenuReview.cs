using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    protected MenuReview(MenuReviewId id) : base(id)
    {
    }
    
#pragma warning disable CS8618
    private MenuReview() { }
#pragma warning restore CS8618
}