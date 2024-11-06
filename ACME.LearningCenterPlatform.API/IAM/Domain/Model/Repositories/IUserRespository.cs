using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Model.Repositories;

 

public interface IUserRepository:IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    
    bool ExistsByUsername(string username);
    
}