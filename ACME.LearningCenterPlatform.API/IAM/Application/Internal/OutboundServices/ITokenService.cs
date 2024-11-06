using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;

/// <summary>
/// Token service interface
/// </summary>
public interface ITokenService
{
    
    /// <summary>
    /// Generate token
    /// </summary>
    /// <param name="user">
    /// The <see cref="User"/> object to generate token for
    /// </param>
    /// <returns>
    /// A string representing the generated token
    /// </returns>
    string GenerateToken(User user);
    
    
    /// <summary>
    /// Validate token
    /// </summary>
    /// <param name="token">
    /// Token to validate
    /// </param>
    /// <returns>
    /// An integer representing the user id if the token is valid, null otherwise
    /// </returns>
    Task<int?> ValidateToken(string token);
}