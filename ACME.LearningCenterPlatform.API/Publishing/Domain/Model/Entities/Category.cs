using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a category in the ACME Learning Center Platform. 
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Default constructor for the category entity 
    /// </summary>
    public Category()
    {
        Name = string.Empty;
    }
    
    /// <summary>
    /// Constructor for the category entity 
    /// </summary>
    /// <param name="name">
    /// The name of the category
    /// </param>
    public Category(string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }
}