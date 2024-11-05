namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

/// <summary>
/// Email address value object 
/// </summary>
/// <param name="Address">
/// The email address
/// </param>
public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty) { }
}