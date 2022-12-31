
using AutoMapper;
using webapiProject.Core.Models;
using webapiProject.DataAccess.Entities;

namespace webapiProject.Core.Mapper;

/// <summary>
/// Create automapper profile
/// </summary>
public class AutomapperProfile : Profile
{
    /// <summary>
    /// Create map from entity to model and reverse.
    /// </summary>
    public AutomapperProfile()
    {
      
        CreateMap<ExampleEntity, ExampleModel>().ReverseMap();
        CreateMap<ExampleEntity, ExampleCreateModel>().ReverseMap();
        CreateMap<ExampleEntity, ExampleUpdateModel>().ReverseMap();

    }
}