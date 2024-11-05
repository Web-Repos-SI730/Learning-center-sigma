using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;

/// <summary>
/// Represents a category command service for Category entities 
/// </summary>
/// <param name="categoryRepository">
/// The repository for category entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class CategoryCommandService(
    ICategoryRepository categoryRepository, 
    IUnitOfWork unitOfWork) : ICategoryCommandService
{
    /// <inheritdoc />
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}