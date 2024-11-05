namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an identifier for an asset in the ACME Learning Center Platform. 
/// </summary>
/// <param name="Identifier">
/// The unique identifier for the asset.
/// </param>
public record AcmeAssetIdentifier(Guid Identifier)
{
    /// <summary>
    /// Default constructor for the asset identifier. 
    /// </summary>
    public AcmeAssetIdentifier() : this(Guid.NewGuid())
    {
    }
}