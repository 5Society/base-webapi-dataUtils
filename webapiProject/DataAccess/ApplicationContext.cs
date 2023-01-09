using JF.Utils.Data;
using Microsoft.EntityFrameworkCore;
using webapiProject.DataAccess.Entities;

namespace API_JF_Data_Utils_Example.DataAccess
{
    public class ApplicationContext : JFContext
    {
        public DbSet<ExampleEntity> ExampleEntities => Set<ExampleEntity>();

        public ApplicationContext(DbContextOptions<JFContext> options) : base(options) { }

    }
}
