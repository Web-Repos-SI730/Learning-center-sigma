namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

/// <summary>
/// Value object for street address 
/// </summary>
/// <param name="Street">
/// The street name
/// </param>
/// <param name="Number">
/// The street number
/// </param>
/// <param name="City">
/// The city name
/// </param>
/// <param name="PostalCode">
/// The postal code 
/// </param>
/// <param name="Country">
/// The country name
/// </param>
public record StreetAddress(string Street, string Number, string City, string PostalCode, string Country)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street) : this(street, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string number, string ciry) : this(street, number, ciry, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string number, string ciry, string postalCode) : this(street, number, ciry, postalCode, string.Empty)
    {
    }
    
    public string FullAddress => $"{Street} {Number}, {City}, {PostalCode}, {Country}";
}