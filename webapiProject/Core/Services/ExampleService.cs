﻿using AutoMapper;
using webapiProject.Core.Interfaces;
using webapiProject.Core.Models;
using webapiProject.DataAccess.Entities;

namespace webapiProject.Core.Services
{
    /// <summary>
    /// Documentation about class ExampleService
    /// </summary>
    public class ExampleService : IExampleService
    {
        private readonly IMapper _mapper;
        public ExampleService(IMapper mapper)
        {
            _mapper = mapper;
        }
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
            //Gets entity 
            ExampleEntity entity = new ExampleEntity
            {
                Id = id,
                DateExample = DateTime.Now.AddDays(id),
                IntExample = Random.Shared.Next(-20, 55),
                StringExample = "Example Sumary",
                StringExampleMax = String.Empty,
            };

            return _mapper.Map<ExampleModel>(entity);
        }

        public async Task<ExampleModel?> Create(ExampleCreateModel model)
        {
            //Gets entity 
            ExampleEntity entity = _mapper.Map<ExampleEntity>(model);
            entity.Id = 1;
            entity.DateExample = DateTime.Now.AddDays(1);

            return _mapper.Map<ExampleModel>(entity);
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