using Microsoft.AspNetCore.Mvc;
using webapiProject.Core.Interfaces;
using webapiProject.Core.Models;

namespace webapiProject.Controllers;

/// <summary>
/// Documentation about controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IExampleService _exampleService;
    private readonly ILogger<ExampleController> _logger;
    
    /// <summary>
    /// Documentation about controller's constructor
    /// </summary>
    /// <param name="exampleService"></param>
    /// <param name="logger"></param>
    public ExampleController(IExampleService exampleService, ILogger<ExampleController> logger)
    {
        _exampleService = exampleService;
        _logger = logger;
    }

    /// <summary>
    /// Example of documentation of the function. 
    /// Gets list of the model example
    /// </summary>
    /// <param name="page">Page number starting in 1</param>
    /// <param name="pageSize">Record's number to return</param>
    /// <returns>Model list</returns>
    /// <response code="200">Returns 200 and the list</response>
    /// <response code="400">Returns 400 if the query is invalid</response>
    [HttpGet()]
    public ActionResult<ExampleModel> Get(int page, int pageSize)
    {
        var results = _exampleService.GetAll(page, pageSize);
        return Ok(results);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Returns 200 and the list</response>
    /// <response code="400">Returns 404 if the id don't exists</response>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        ExampleModel? entity = _exampleService.GetById(id);

        if (entity is null)
            return NotFound($"Entity with Id = {id} not found.");

        return Ok(entity);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="200">Returns 201 and the record created</response>
    /// <response code="400">Returns 400 if the transaction is invalid </response>
    [HttpPost]
    public async Task<ActionResult<ExampleModel>> Post([FromBody] ExampleCreateModel model)
    {

        if (model is null)
            return BadRequest(ModelState);

        ExampleModel? result = await _exampleService.Create(model);

        if (result is null)
            return BadRequest("Your changes have not been saved.");

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="204">Returns 204 if the record was updated</response>
    /// <response code="400">Returns 400 if the transaction is invalid </response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ExampleUpdateModel model)
    {
        if (model is null)
            return BadRequest(ModelState);

        if (id != model.Id)
            return BadRequest("Identifier is not valid or Identifiers don't match.");

        bool result = await _exampleService.Update(id, model);

        if (!result)
            return BadRequest("Your changes have not been saved.");

        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Returns 204 if the record was deleted</response>
    /// <response code="404">Returns 400 if the transaction is invalid </response>
    /// <response code="400">Returns 404 if the id don't exists</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        bool result = await _exampleService.Delete(id);

        if (!result) return NotFound($"Entity with Id = {id} not found");

        return NoContent();
    }
}
