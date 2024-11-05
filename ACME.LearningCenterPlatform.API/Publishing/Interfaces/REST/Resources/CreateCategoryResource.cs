namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Represents a resource to create a category. 
/// </summary>
/// <param name="Name">
/// The name of the category.
/// </param>
public record CreateCategoryResource(string Name);