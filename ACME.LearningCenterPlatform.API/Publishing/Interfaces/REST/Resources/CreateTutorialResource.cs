namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Represents the data required to create a new tutorial. 
/// </summary>
/// <param name="Title">
/// The title of the tutorial.
/// </param>
/// <param name="Summary">
/// The summary of the tutorial.
/// </param>
/// <param name="CategoryId">
/// The category identifier of the tutorial.
/// </param>
public record CreateTutorialResource(string Title, string Summary, int CategoryId);