using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the tutorial repository in the ACME Learning Center Platform. 
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext"/> to use.
/// </param>
public class TutorialRepository(AppDbContext context) : BaseRepository<Tutorial>(context), ITutorialRepository
{
    // inheritedDoc
    public async Task<IEnumerable<Tutorial>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .Where(tutorial => tutorial.CategoryId == categoryId)
            .ToListAsync();
    }

    // inheritedDoc
    public new async Task<Tutorial?> FindByIdAsync(int id)
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .FirstOrDefaultAsync(tutorial => tutorial.Id == id);
    }

    // inheritedDoc
    public new async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await Context.Set<Tutorial>()
            .Include(tutorial => tutorial.Category)
            .ToListAsync();
    }
    
    // inheritedDoc
    public async Task<bool> ExistsByTitleAsync(string title)
    {
        return await Context.Set<Tutorial>()
            .AnyAsync(tutorial => tutorial.Title == title);
    }
}