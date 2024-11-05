using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the category repository in the ACME Learning Center Platform. 
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext"/> to use.
/// </param>
public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository;
