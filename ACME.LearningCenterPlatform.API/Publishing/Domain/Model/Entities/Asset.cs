using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an asset in the ACME Learning Center Platform. 
/// </summary>
/// <param name="type">
/// The type of the asset.
/// </param>
public partial class Asset(EAssetType type) : IPublishable
{
    public int Id { get; }
    
    public AcmeAssetIdentifier AssetIdentifier { get; private set; } = new();
    public EPublishingStatus Status { get; private set; } = EPublishingStatus.Draft;
    public EAssetType Type { get; private set; } = type;
    public virtual bool Readable => false;
    public virtual bool Viewable => false;

    /// <summary>
    /// Send the asset to the editing phase. It sets the <see cref="EPublishingStatus.ReadyToEdit"/> status. 
    /// </summary>
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Send the asset to the approval phase. It sets the <see cref="EPublishingStatus.ReadyToApproval"/> status. 
    /// </summary>
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approve the asset and lock it. It sets the <see cref="EPublishingStatus.ApprovedAndLocked"/> status. 
    /// </summary>
    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Reject the asset. It sets the <see cref="EPublishingStatus.Draft"/> status. 
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Return the asset to the editing phase. It sets the <see cref="EPublishingStatus.ReadyToEdit"/> status. 
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Get the content of the asset. 
    /// </summary>
    /// <returns>
    /// The content of the asset.
    /// </returns>
    public virtual object GetContent()
    {
        return string.Empty;
    }
}