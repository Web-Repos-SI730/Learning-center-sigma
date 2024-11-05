using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;

/// <summary>
/// Tutorial query service 
/// </summary>
/// <param name="tutorialRepository">
/// The <see cref="ITutorialRepository"/> repository
/// </param>
public class TutorialQueryService(ITutorialRepository tutorialRepository): ITutorialQueryService
{
    /// <inheritdoc />
    public async Task<Tutorial?> Handle(GetTutorialByIdQuery query)
    {
        return await tutorialRepository.FindByIdAsync(query.TutorialId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Tutorial>> Handle(GetAllTutorialsQuery query)
    {
        return await tutorialRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Tutorial>> Handle(GetAllTutorialsByCategoryIdQuery query)
    {
        return await tutorialRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}