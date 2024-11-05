namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

/// <summary>
/// Value object for a person's name 
/// </summary>
/// <param name="FirstName">
/// The first name of the person
/// </param>
/// <param name="LastName">
/// The last name of the person
/// </param>
public record PersonName(string FirstName, string LastName)
{
    public PersonName() : this(string.Empty, string.Empty) { }
    
    public PersonName(string firstName) : this(firstName, string.Empty) { }
    
    public string FullName => $"{FirstName} {LastName}";
}