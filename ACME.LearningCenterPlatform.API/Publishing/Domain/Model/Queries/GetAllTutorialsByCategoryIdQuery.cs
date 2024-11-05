namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
/// Represents a query to get all tutorials by category id in the ACME Learning Center Platform. 
/// </summary>
/// <param name="CategoryId">
/// The id of the category to get tutorials for
/// </param>
public record GetAllTutorialsByCategoryIdQuery(int CategoryId);