using JF.Utils.Data;
using JF.Utils.Data.Interfaces;
using webapiProject.DataAccess.Entities;
using webapiProject.DataAccess.Interfaces;

namespace webapiProject.DataAccess.Repositories;

public class ExampleRepository : JFRepositoryBase<ExampleEntity>, IExampleRepository
{
    public ExampleRepository(IUnitOfWork context) : base(context)
    {
    }
}
