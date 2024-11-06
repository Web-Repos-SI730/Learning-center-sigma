namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
/// <summary>
/// Hashing service interface
/// </summary>
public interface IHashingService
{
    /// <summary>
    /// Hash Password
    /// </summary>
    /// <param name="password">
    /// Password to hash
    /// </param>
    /// <returns>
    /// Hashed password
    /// </returns>
    string HashPassword(string password);
    
    /// <summary>
    /// Verify passsword
    /// </summary>
    /// <param name="password">
    /// 
    /// </param>
    /// <param name="hashedPassword">
    /// A boolean indicating if the password is valid
    /// </param>
    /// <returns>
    /// True if the password is valid, false otherwise
    /// </returns>
    bool VerifyPassword(string password, string hashedPassword);
    
    
}