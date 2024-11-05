using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform Category to CategoryResource 
/// </summary>
public static class CategoryResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Category to CategoryResource 
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Category"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CategoryResource"/> resource with the values from the entity
    /// </returns>
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}