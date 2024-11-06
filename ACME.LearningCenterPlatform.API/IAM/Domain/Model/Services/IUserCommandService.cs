using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Model.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);

    Task<(User user, string token)> Handle(SignInCommand command);
}