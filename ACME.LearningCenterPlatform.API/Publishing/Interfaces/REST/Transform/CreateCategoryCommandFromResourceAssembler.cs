using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform CreateCategoryResource to CreateCategoryCommand 
/// </summary>
public static class CreateCategoryCommandFromResourceAssembler
{
    /// <summary>
    /// Transform CreateCategoryResource to CreateCategoryCommand 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateCategoryResource"/> resource to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CreateCategoryCommand"/> command with the values from the resource
    /// </returns>
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}