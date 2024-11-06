namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;
/// <summary>
/// Represents the user resource.
/// </summary>
/// <param name="Id">
/// The user identifier.
/// </param>
/// <param name="Username">
/// The user username.
/// </param>
public record UserResource(int Id, string Username);