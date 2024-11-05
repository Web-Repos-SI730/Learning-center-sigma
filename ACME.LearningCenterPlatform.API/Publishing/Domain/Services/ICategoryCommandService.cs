using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

/// <summary>
/// Represents the category command service in the ACME Learning Center Platform. 
/// </summary>
public interface ICategoryCommandService
{
    /// <summary>
    /// Handles the create category command in the ACME Learning Center Platform. 
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateCategoryCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Category"/> entity.
    /// </returns>
    public Task<Category?> Handle(CreateCategoryCommand command);
}