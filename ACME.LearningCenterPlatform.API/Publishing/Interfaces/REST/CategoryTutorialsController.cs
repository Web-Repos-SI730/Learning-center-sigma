using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

/// <summary>
/// Controller for managing tutorials by category. 
/// </summary>
/// <param name="tutorialQueryService"></param>
[ApiController]
[Route("api/v1/categories/{categoryId:int}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryTutorialsController(ITutorialQueryService tutorialQueryService) : ControllerBase
{
    /// <summary>
    /// Get all tutorials by category 
    /// </summary>
    /// <param name="categoryId">
    /// The category id to get tutorials for
    /// </param>
    /// <returns>
    /// The tutorials for the category
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all tutorials by category",
        Description = "Get all tutorials by category",
        OperationId = "GetTutorialsByCategoryId"
    )]
    [SwaggerResponse(200, "The tutorials were successfully retrieved", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetTutorialsByCategoryId(int categoryId)
    {
        var getAllTutorialsByCategoryIdQuery = new GetAllTutorialsByCategoryIdQuery(categoryId);
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsByCategoryIdQuery);
        var tutorialResources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(tutorialResources);
    }
    
}