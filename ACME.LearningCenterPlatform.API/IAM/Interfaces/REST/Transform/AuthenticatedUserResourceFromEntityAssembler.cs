using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Transform;
/// <summary>
/// Represents the authenticated user resource from entity .
/// </summary>
public static class AuthenticatedUserResourceFromEntityAssembler
{
    /// <summary>
    /// Converts the user entity to the authenticated user resource.
    /// </summary>
    /// <param name="user">
    /// The user entity object.
    /// </param>
    /// <param name="token">
    /// The user token.
    /// </param>
    /// <returns> The <see cref="UserResource"/></returns>
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}