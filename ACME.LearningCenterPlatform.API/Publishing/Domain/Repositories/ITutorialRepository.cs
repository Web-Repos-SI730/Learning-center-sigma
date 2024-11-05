using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;

/// <summary>
/// Represents the tutorial repository in the ACME Learning Center Platform. 
/// </summary>
public interface ITutorialRepository : IBaseRepository<Tutorial>
{
    /// <summary>
    /// Finds a tutorial by category id asynchronously. 
    /// </summary>
    /// <param name="categoryId">
    /// The id of the category to find tutorials by.
    /// </param>
    /// <returns>
    /// A collection of tutorials that belong to the category.
    /// </returns>
    Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(int categoryId);

    /// <summary>
    /// Verify if a tutorial with specified title exists. 
    /// </summary>
    /// <param name="title">
    /// The title of the tutorial to verify.
    /// </param>
    /// <returns>
    /// True if the tutorial exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByTitleAsync(string title);
}