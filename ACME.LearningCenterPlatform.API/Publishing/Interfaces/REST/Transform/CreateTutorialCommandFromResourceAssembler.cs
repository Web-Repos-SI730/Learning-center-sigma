using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform CreateTutorialResource to CreateTutorialCommand 
/// </summary>
public static class CreateTutorialCommandFromResourceAssembler
{
    /// <summary>
    /// Transform CreateTutorialResource to CreateTutorialCommand 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateTutorialResource"/> resource to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CreateTutorialCommand"/> command with the values from the resource
    /// </returns>
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary, resource.CategoryId);
    }
}