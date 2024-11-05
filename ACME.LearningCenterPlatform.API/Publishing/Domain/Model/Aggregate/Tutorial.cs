using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;

/// <summary>
/// Tutorial aggregate root entity 
/// </summary>
/// <remarks>
/// This class is used to represent a tutorial in the application.
/// </remarks>
public partial class Tutorial
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public Category Category { get; internal set; }
    public int CategoryId { get; private set; }
    
    /// <summary>
    /// Default constructor for the tutorial entity 
    /// </summary>
    /// <param name="title">
    /// The title of the tutorial
    /// </param>
    /// <param name="summary">
    /// The summary of the tutorial
    /// </param>
    /// <param name="categoryId">
    /// The category id for the tutorial
    /// </param>
    public Tutorial(string title, string summary, int categoryId) : this()
    {
        Title = title;
        Summary = summary;
        CategoryId = categoryId;
    }
    
    public Tutorial(CreateTutorialCommand command) : this()
    {
        Title = command.Title;
        Summary = command.Summary;
        CategoryId = command.CategoryId;
    }
}