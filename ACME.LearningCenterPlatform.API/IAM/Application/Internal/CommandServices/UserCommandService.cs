using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Repositories;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork
    ): IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
       if(userRepository.ExistsByUsername(command.Username))
           throw new Exception($"Username {command.Username} already exists");
       
       var hashedPassword = hashingService.HashPassword(command.Password);
       var user= new User(command.Username, hashedPassword);
       try
       {
           await userRepository.AddAsync(user);
           await unitOfWork.CompleteAsync();
       }
       catch (Exception e)
       {
           throw new Exception($"An error ocurred while creating the user: {e.Message}");
       }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if(user==null) throw new Exception($"User {command.Username} not found");
        
        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid password");
        var token = tokenService.GenerateToken(user);
        return (user, token);
        



    }
}