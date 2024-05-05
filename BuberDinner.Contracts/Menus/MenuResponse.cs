namespace BuberDinner.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionResponse> Sections,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime EndedDateTime); 