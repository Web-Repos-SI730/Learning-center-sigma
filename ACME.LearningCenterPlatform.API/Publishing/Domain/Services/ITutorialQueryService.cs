using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

/// <summary>
/// Represents the tutorial query service in the ACME Learning Center Platform. 
/// </summary>
public interface ITutorialQueryService
{
    /// <summary>
    /// Handles the get tutorial by id query in the ACME Learning Center Platform. 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetTutorialByIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Tutorial"/> entity.
    /// </returns>
    Task<Tutorial?> Handle(GetTutorialByIdQuery query);
    
    /// <summary>
    /// Handles the get all tutorials query in the ACME Learning Center Platform. 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllTutorialsQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all tutorials in the platform.
    /// </returns>
    Task<IEnumerable<Tutorial>> Handle(GetAllTutorialsQuery query);
    
    /// <summary>
    /// Handles the get all tutorials by category id query in the ACME Learning Center Platform. 
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllTutorialsByCategoryIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of tutorials that belong to the category.
    /// </returns>
    Task<IEnumerable<Tutorial>> Handle(GetAllTutorialsByCategoryIdQuery query);
}