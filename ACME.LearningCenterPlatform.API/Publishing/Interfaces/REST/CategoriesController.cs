using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

/// <summary>
/// Controller for managing categories. 
/// </summary>
/// <param name="categoryCommandService">
/// The <see cref="ICategoryCommandService"/> command service for categories
/// </param>
/// <param name="categoryQueryService">
/// The <see cref="ICategoryQueryService"/> query service for categories
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Category Endpoints")]
public class CategoriesController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService) : ControllerBase
{

    /// <summary>
    /// Get a category by its unique identifier. 
    /// </summary>
    /// <param name="categoryId">
    /// The unique identifier of the category to get
    /// </param>
    /// <returns>
    /// The <see cref="CategoryResource"/> category if found, otherwise returns <see cref="NotFoundResult"/>
    /// </returns>
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Get Category by Id",
        Description = "Get a category by its unique identifier",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The category was found", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The category was not found")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category is null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }

    /// <summary>
    /// Create a new category. 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateCategoryResource"/> to create the category from
    /// </param>
    /// <returns>
    /// The <see cref="CategoryResource"/> category if created, otherwise returns <see cref="BadRequestResult"/>
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Category",
        Description = "Create a new category",
        OperationId = "CreateCategory")]
    [SwaggerResponse(StatusCodes.Status201Created, "The category was created", typeof(CategoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The category was not created")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.Id }, categoryResource);
    }
    
    /// <summary>
    /// Get all categories. 
    /// </summary>
    /// <returns>
    /// The list of <see cref="CategoryResource"/> categories
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Categories",
        Description = "Get all categories",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The categories were found", typeof(IEnumerable<CategoryResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await categoryQueryService.Handle(new GetAllCategoriesQuery());
        var categoryResources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }
}