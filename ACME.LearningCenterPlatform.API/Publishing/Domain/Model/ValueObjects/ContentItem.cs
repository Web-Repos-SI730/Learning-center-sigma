namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a content item in the ACME Learning Center Platform. 
/// </summary>
/// <param name="Type">
/// The type of the content item.
/// </param>
/// <param name="Content">
/// The content of the content item.
/// </param>
public record ContentItem(string Type, string Content);