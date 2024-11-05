using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Unit of work for the application.
/// </summary>
/// <remarks>
/// This class is used to save changes to the database context.
/// It implements the IUnitOfWork interface.
/// </remarks>
/// <param name="context">
/// The database context for the application
/// </param>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}