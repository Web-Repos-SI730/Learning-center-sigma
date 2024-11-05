using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application database context for the Learning Center Platform 
/// </summary>
/// <param name="options">
/// The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   /// <summary>
   /// On configuring the database context 
   /// </summary>
   /// <remarks>
   /// This method is used to configure the database context.
   /// It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   /// The options builder for the database context
   /// </param>
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }

   /// <summary>
   /// On creating the database model 
   /// </summary>
   /// <remarks>
   /// This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   /// The model builder for the database context
   /// </param>
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      // Publishing Context
      builder.Entity<Category>().HasKey(c => c.Id);
      builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);

      builder.Entity<Tutorial>().HasKey(t => t.Id);
      builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
      builder.Entity<Tutorial>().Property(t => t.Summary).IsRequired().HasMaxLength(240);

      builder.Entity<Asset>().HasDiscriminator(a => a.Type);
      builder.Entity<Asset>().HasKey(a => a.Id);
      builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
         .HasValue<Asset>("asset_base")
         .HasValue<ImageAsset>("asset_image")
         .HasValue<VideoAsset>("asset_video")
         .HasValue<ReadableContentAsset>("asset_readable_content");

      builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier, ai =>
      {
         ai.WithOwner().HasForeignKey("Id");
         ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
      });
      builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
      builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();

      builder.Entity<Tutorial>().HasMany(t => t.Assets);
      
      // Profiles Context
        
      builder.Entity<Profile>().HasKey(p => p.Id);
      builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Profile>().OwnsOne(p => p.Name,
         n =>
         {
            n.WithOwner().HasForeignKey("Id");
            n.Property(p => p.FirstName).HasColumnName("FirstName");
            n.Property(p => p.LastName).HasColumnName("LastName");
         });

      builder.Entity<Profile>().OwnsOne(p => p.Email,
         e =>
         {
            e.WithOwner().HasForeignKey("Id");
            e.Property(a => a.Address).HasColumnName("EmailAddress");
         });

      builder.Entity<Profile>().OwnsOne(p => p.Address,
         a =>
         {
            a.WithOwner().HasForeignKey("Id");
            a.Property(s => s.Street).HasColumnName("AddressStreet");
            a.Property(s => s.Number).HasColumnName("AddressNumber");
            a.Property(s => s.City).HasColumnName("AddressCity");
            a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
            a.Property(s => s.Country).HasColumnName("AddressCountry");
         });
      
      builder.UseSnakeCaseNamingConvention();
   }
}