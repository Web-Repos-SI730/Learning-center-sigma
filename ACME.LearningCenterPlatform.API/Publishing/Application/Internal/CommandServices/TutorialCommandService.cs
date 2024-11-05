using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;

/// <summary>
/// Represents a tutorial command service for Tutorial entities 
/// </summary>
/// <param name="categoryRepository">
/// The repository for category entities
/// </param>
/// <param name="tutorialRepository">
/// The repository for tutorial entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class TutorialCommandService(
    ICategoryRepository categoryRepository,
    ITutorialRepository tutorialRepository, 
    IUnitOfWork unitOfWork) : ITutorialCommandService
{
    /// <inheritdoc />
    public async Task<Tutorial?> Handle(AddVideoAssetToTutorialCommand command)
    {
        var tutorial = await tutorialRepository.FindByIdAsync(command.TutorialId);
        if (tutorial is null) throw new Exception("Tutorial not found");
        tutorial.AddVideo(command.VideoUrl);
        await unitOfWork.CompleteAsync();
        return tutorial;
    }

    /// <inheritdoc />
    public async Task<Tutorial?> Handle(CreateTutorialCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if (category is null) throw new Exception("Category not found");
        if (await tutorialRepository.ExistsByTitleAsync(command.Title))
            throw new Exception("Tutorial with the same title already exists");
        var tutorial = new Tutorial(command);
        await tutorialRepository.AddAsync(tutorial);
        await unitOfWork.CompleteAsync();
        tutorial.Category = category;
        return tutorial;
    }
}