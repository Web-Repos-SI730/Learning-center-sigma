using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Tutorial Endpoints")]
public class TutorialsController(ITutorialQueryService tutorialQueryService, ITutorialCommandService tutorialCommandService) : ControllerBase
{
    /// <summary>
    /// Get tutorial by id 
    /// </summary>
    /// <param name="tutorialId">
    /// The tutorial id to get
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> tutorial if found, otherwise returns <see cref="NotFoundResult"/>
    /// </returns>
    [HttpGet("{tutorialId:int}")]
    [SwaggerOperation(
        Summary = "Get a tutorial by id",
        Description = "Get a tutorial by id",
        OperationId = "GetTutorialById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial was successfully retrieved", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The tutorial was not found")]
    public async Task<IActionResult> GetTutorialById(int tutorialId)
    {
        var getTutorialByIdQuery = new GetTutorialByIdQuery(tutorialId);
        var tutorial = await tutorialQueryService.Handle(getTutorialByIdQuery);
        if (tutorial is null) return NotFound();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return Ok(tutorialResource);
    }
    
    /// <summary>
    /// Create a tutorial 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateTutorialResource"/> to create the tutorial from
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> tutorial if created, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a tutorial",
        Description = "Create a tutorial",
        OperationId = "CreateTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The tutorial was successfully created", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The tutorial was not created")]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource resource)
    {
        var createTutorialCommand = CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(resource);
        var tutorial = await tutorialCommandService.Handle(createTutorialCommand);
        if (tutorial is null) return BadRequest();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = tutorial.Id }, tutorialResource);
    }

    /// <summary>
    /// Get all tutorials 
    /// </summary>
    /// <returns>
    /// The list of <see cref="TutorialResource"/> tutorials
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all tutorials",
        Description = "Get all tutorials",
        OperationId = "GetAllTutorials"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorials were successfully retrieved", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetAllTutorials()
    {
        var getAllTutorialsQuery = new GetAllTutorialsQuery();
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsQuery);
        var tutorialResources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(tutorialResources);
    }
    
    /// <summary>
    /// Add a video to a tutorial 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="AddVideoAssetToTutorialResource"/> to add the video to the tutorial from
    /// </param>
    /// <param name="tutorialId">
    /// The tutorial id to add the video to
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> tutorial if the video was added, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost("{tutorialId:int}/videos")]
    [SwaggerOperation(
        Summary = "Add a video to a tutorial",
        Description = "Add a video to a tutorial",
        OperationId = "AddVideoToTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The video was successfully added to the tutorial", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The video was not added to the tutorial")]
    public async Task<IActionResult> AddVideoToTutorial([FromBody] AddVideoAssetToTutorialResource resource,
        [FromRoute] int tutorialId)
    {
        var addVideoAssetToTutorialCommand = AddVideoAssetToTutorialCommandFromResourceAssembler.ToCommandFromResource(resource, tutorialId);
        var tutorial = await tutorialCommandService.Handle(addVideoAssetToTutorialCommand);
        if (tutorial is null) return BadRequest();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = tutorial.Id }, tutorialResource);
    }
    
}