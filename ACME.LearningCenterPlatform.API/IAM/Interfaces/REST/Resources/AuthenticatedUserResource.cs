namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
/// Represents the authenticated user resource
/// </summary>
/// <param name="Id">
/// The user identifier.
/// </param>
/// <param name="Username">
/// The user username.
/// </param>
/// <param name="Token">
/// The user token.
/// </param>
public record AuthenticatedUserResource(int Id, string Username, string Token);