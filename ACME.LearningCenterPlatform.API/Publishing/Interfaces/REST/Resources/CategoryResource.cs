namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Represents a category resource. 
/// </summary>
/// <param name="Id">
/// The unique identifier for the category.
/// </param>
/// <param name="Name">
/// The name of the category.
/// </param>
public record CategoryResource(int Id, string Name);