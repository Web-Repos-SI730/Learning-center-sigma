using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform Tutorial to TutorialResource 
/// </summary>
public static class TutorialResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Tutorial to TutorialResource 
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Tutorial"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="TutorialResource"/> resource with the values from the entity
    /// </returns>
    public static TutorialResource ToResourceFromEntity(Tutorial entity)
    {
        return new TutorialResource(entity.Id, entity.Title, entity.Summary, CategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category));
    }
}