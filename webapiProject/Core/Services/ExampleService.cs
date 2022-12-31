using webapiProject.Core.Interfaces;
using webapiProject.Core.Models;

namespace webapiProject.Core.Services
{
    /// <summary>
    /// Documentation about class ExampleService
    /// </summary>
    public class ExampleService : IExampleService
    {
     
        public IEnumerable<ExampleModel> GetAll(int page, int pageSize)
        {
            return Enumerable.Range(1, pageSize).Select(index => new ExampleModel
            {
                Id = index,
                DateExample = DateTime.Now.AddDays(index),
                IntExample = Random.Shared.Next(-20, 55),
                StringExample = "Example Summary"
            }).ToArray();
        }

        public ExampleModel? GetById(int id)
        {
            return new ExampleModel
            {
                Id = id,
                DateExample = DateTime.Now.AddDays(id),
                IntExample = Random.Shared.Next(-20, 55),
                StringExample = "Example Summary"
            };
        }

        public async Task<ExampleModel?> Create(ExampleCreateModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, ExampleUpdateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
