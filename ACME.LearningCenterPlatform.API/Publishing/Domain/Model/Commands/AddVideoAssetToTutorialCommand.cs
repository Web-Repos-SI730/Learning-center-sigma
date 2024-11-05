namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

/// <summary>
/// Command to add a video asset to a tutorial. 
/// </summary>
/// <param name="VideoUrl">
/// The URL of the video asset to add to the tutorial.
/// </param>
/// <param name="TutorialId">
/// The ID of the tutorial to add the video asset to.
/// </param>
public record AddVideoAssetToTutorialCommand(string VideoUrl, int TutorialId);