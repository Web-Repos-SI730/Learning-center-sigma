using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;


public partial class Tutorial : IPublishable
{
    public ICollection<Asset> Assets { get; }
    
    public EPublishingStatus Status { get; protected set; }

    
    public bool Readable => HasReadableAssets;
    
    public bool Viewable => HasViewableAssets;

    public bool HasReadableAssets => Assets.Any(asset => asset.Readable);
    
    public bool HasViewableAssets => Assets.Any(asset => asset.Viewable);


    /// <summary>
    /// Default constructor for the tutorial entity 
    /// </summary>
    public Tutorial()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Assets = new List<Asset>();
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Verify if an image asset already exists in the tutorial  
    /// </summary>
    /// <param name="imageUrl">
    /// The image url to verify
    /// </param>
    /// <returns>
    /// True if the image asset exists, false otherwise
    /// </returns>
    private bool ExistsImageByUrl(string imageUrl) =>
        Assets.Any(asset => asset.Type == EAssetType.Image &&
                            (string)asset.GetContent() == imageUrl);
    
    /// <summary>
    /// Verify if a video asset already exists in the tutorial 
    /// </summary>
    /// <param name="videoUrl">
    /// The video url to verify
    /// </param>
    /// <returns>
    /// True if the video asset exists, false otherwise
    /// </returns>
    private bool ExistsVideoByUrl(string videoUrl) =>
        Assets.Any(asset => asset.Type == EAssetType.Video &&
                            (string)asset.GetContent() == videoUrl);

    /// <summary>
    /// Verify if a readable content asset already exists in the tutorial 
    /// </summary>
    /// <param name="content">
    /// The content to verify
    /// </param>
    /// <returns>
    /// True if the readable content asset exists, false otherwise
    /// </returns>
    private bool ExistsReadableContent(string content) =>
        Assets.Any(asset => asset.Type == EAssetType.ReadableContentItem &&
                            (string)asset.GetContent() == content);
    
    /// <summary>
    /// Verify if all assets have the same status 
    /// </summary>
    /// <param name="status">
    /// The status to verify
    /// </param>
    /// <returns>
    /// True if all assets have the same status, false otherwise
    /// </returns>
    private bool HasAllAssetsWithStatus(EPublishingStatus status) =>
    Assets.All(asset => asset.Status == status);

    /// <summary>
    /// Add an image asset to the tutorial 
    /// </summary>
    /// <param name="imageUrl">
    /// The image url to add
    /// </param>
    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }
    
    /// <summary>
    /// Add a video asset to the tutorial 
    /// </summary>
    /// <param name="videoUrl">
    /// The video url to add
    /// </param>
    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }
    
    /// <summary>
    /// Add a readable content asset to the tutorial 
    /// </summary>
    /// <param name="content">
    /// The content to add
    /// </param>
    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }
    
    /// <summary>
    /// Remove an asset from the tutorial 
    /// </summary>
    /// <param name="identifier">
    /// The asset identifier to remove
    /// </param>
    public void RemoveAsset(AcmeAssetIdentifier identifier)
    {
        var asset = Assets.FirstOrDefault(a => a.AssetIdentifier == identifier);
        if (asset is null) return;
        Assets.Remove(asset);
    }

    /// <summary>
    /// Clear all assets from the tutorial 
    /// </summary>
    public void ClearAssets() => Assets.Clear();
    
    
    /// <summary>
    /// Send the tutorial to the <see cref="EPublishingStatus.ReadyToEdit"/> status 
    /// </summary>
    public void SendToEdit()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }
    
    /// <summary>
    /// Send the tutorial to the <see cref="EPublishingStatus.ReadyToApproval"/> status 
    /// </summary>
    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approve and lock the tutorial 
    /// </summary>
    /// <remarks>
    /// This method is used to approve and lock the tutorial. If all assets have the status <see cref="EPublishingStatus.ApprovedAndLocked"/>, the tutorial status will be set to <see cref="EPublishingStatus.ApprovedAndLocked"/>.
    /// </remarks>
    public void ApproveAndLock()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Reject the tutorial 
    /// </summary>
    /// <remarks>
    /// This method is used to reject the tutorial. The tutorial status will be set to <see cref="EPublishingStatus.Draft"/>.
    /// </remarks>
    public void Reject() => Status = EPublishingStatus.Draft;

    /// <summary>
    /// Return the tutorial to the <see cref="EPublishingStatus.ReadyToEdit"/> status 
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Build and return the current tutorial content 
    /// </summary>
    /// <remarks>
    /// This method is used to build and return the current tutorial content. It returns a list of <see cref="ContentItem"/> containing the tutorial assets.
    /// </remarks>
    /// <returns></returns>
    public List<ContentItem> GetContent()
    {
        var content = new List<ContentItem>();
        if (Assets.Count > 0)
            content.AddRange(Assets.Select(asset =>
                new ContentItem(asset.Type.ToString(), asset.GetContent() as string ?? String.Empty)));
        return content;
    }
    
}