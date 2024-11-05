using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;

/// <summary>
/// Category query service 
/// </summary>
/// <param name="categoryRepository">
/// The category repository
/// </param>
public class CategoryQueryService(ICategoryRepository categoryRepository): ICategoryQueryService
{
    /// <inheritdoc />
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.CategoryId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }
}