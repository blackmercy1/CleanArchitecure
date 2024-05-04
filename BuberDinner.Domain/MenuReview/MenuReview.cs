using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    protected MenuReview(MenuReviewId id) : base(id)
    {
    }
}