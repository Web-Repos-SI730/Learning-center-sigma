namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a category by id in the ACME Learning Center Platform. 
/// </summary>
/// <param name="CategoryId">
/// The id of the category to get
/// </param>
public record GetCategoryByIdQuery(int CategoryId);