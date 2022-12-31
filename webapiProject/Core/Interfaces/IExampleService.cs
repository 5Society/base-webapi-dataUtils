using webapiProject.Core.Models;
using webapiProject.DataAccess.Entities;

namespace webapiProject.Core.Interfaces;

/// <summary>
/// Documentation about interface IExampleService
/// </summary>
public interface IExampleService
{
    /// <summary>
    /// Get all records
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    IEnumerable<ExampleModel> GetAll(int page, int pageSize);

    /// <summary>
    /// Get record by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ExampleModel? GetById(int id);

    /// <summary>
    /// Create record
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<ExampleModel?> Create(ExampleCreateModel model);

    /// <summary>
    /// Update record
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> Update(int id, ExampleUpdateModel model);

    /// <summary>
    /// Delete Record
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(int id);
}
