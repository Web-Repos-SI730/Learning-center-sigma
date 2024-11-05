using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a readable content asset in the ACME Learning Center Platform. 
/// </summary>
public class ReadableContentAsset : Asset
{
    public string ReadableContent { get; set; }
    public override bool Readable => true;
    public override bool Viewable => false;

    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }

    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }
}