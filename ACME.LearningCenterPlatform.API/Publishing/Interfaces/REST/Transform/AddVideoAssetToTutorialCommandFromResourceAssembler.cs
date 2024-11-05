using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform AddVideoAssetToTutorialResource to AddVideoAssetToTutorialCommand 
/// </summary>
public static class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    /// <summary>
    /// Transform AddVideoAssetToTutorialResource to AddVideoAssetToTutorialCommand 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="AddVideoAssetToTutorialResource"/> resource to transform
    /// </param>
    /// <param name="TutorialId">
    /// The TutorialId to add the video asset to 
    /// </param>
    /// <returns>
    /// The resulting <see cref="AddVideoAssetToTutorialCommand"/> command with the values from the resource
    /// </returns>
    public static AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetToTutorialResource resource, int TutorialId)
    {
        return new AddVideoAssetToTutorialCommand(TutorialId: TutorialId, VideoUrl: resource.VideoUrl);
    }
}