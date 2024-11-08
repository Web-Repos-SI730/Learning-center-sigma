using System.Net.Mime;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Services;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST;

/// <summary>
///  Represent the authentication controller.
/// </summary>
/// <param name="userCommandService">
/// The <see cref="IUserCommandService"/> command service for users
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available authentication Endpoints")]

public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    
    [HttpPost("sign-in")]
    [SwaggerOperation(
        Summary = "Sign in the user",
        Description = "Sign in the user with the provided credentials",
        OperationId = "SignIn")]
    [SwaggerResponse(200, "The user is successfully signed in", typeof(AuthenticatedUserResource))]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var authenticatedUserResource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }

    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Sign up the user",
        Description = "Sign up the user with the provided credentials",
        OperationId = "SignUp")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was successfully signed up.")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new {message = "User is successfully signed up"});
        
    }

}