using webapiProject.Core.Interfaces;
using webapiProject.Core.Services;
using webapiProject.Core.Mapper;
using webapiProject.Core.Models;
using AutoMapper;

namespace webapiTestProject.Services
{
    public class UnitTest_Example
    {
        private IExampleService _service;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            _service = new ExampleService(mapper);
        }

        [TestCase(110, "summary", true)]
        [TestCase(120, "summary2", true)]
        [TestCase(-10, "summary2", false)]
        [TestCase(120, "", false)]
        [TestCase(120, null, false)]
        [TestCase(-120, null, false)]
        [NonParallelizable]
        [Test, Order(1)]
        public void Create_Ok(int intExample, string? stringExample, bool resultExpexted)
        {
            ExampleCreateModel model = new ExampleCreateModel() { IntExample = intExample, StringExample = stringExample };
            var result = _service.Create(model);
            ExampleModel? resultModel = result.Result;

            Assert.Multiple(() =>
            {
                Assert.That(resultModel != null, Is.EqualTo(resultExpexted));
                if (resultModel != null)
                {
                    //Valida información
                    Assert.That(resultModel.PropertyExample, Is.GreaterThan(0));
                }
            });
        }

        /*
                [TestCase(0, "summary")]
                [TestCase(-1, "")]
                [TestCase(10, null)]
                [NonParallelizable]
                [Test, Order(1)]
                public void Create_Exception(int intExample, string stringExample)
                {
                    ExampleCreateModel model = new ExampleCreateModel() { IntExample = intExample, StringExample = stringExample };
                    Assert.That(() => _service.Create(model), Throws.TypeOf<System.ComponentModel.DataAnnotations.ValidationException>());
                }
        */

        [TestCase(1, 10, 10)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 15, 15)]
        [TestCase(3, 1, 1)]
        [TestCase(4, 12, 12)]
        [Test, Order(2)]
        public void GetAll(int page, int pagesize, int resultExpexted)
        {
            var result = _service.GetAll(page, pagesize);
            Assert.That(result.Count(), Is.EqualTo(resultExpexted));
        }


        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(-3, false)]
        [Test, Order(2)]
        public void GetById(int id, bool resultExpexted)
        {
            ExampleModel? result = _service.GetById(id);
            Assert.That(result != null, Is.EqualTo(resultExpexted));
        }

        [TestCase(10, 10, 10, "sumary 1", true)]
        [TestCase(2, 2, 20, "summary 2", true)]
        [TestCase(1, 10, 5, "test 1", false)]
        [TestCase(2, 20, 15, "test 2", false)]
        [Test, Order(2)]
        public void Update_OK(int id, int idExample, int intExample, string? stringExample, bool resultExpexted)
        {
            ExampleUpdateModel model = new ExampleUpdateModel() { Id = idExample, IntExample = intExample, StringExample = stringExample };
            bool result = _service.Update(id, model).Result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(resultExpexted));
                //Validaciones adicionales
            });
        }

        [TestCase(-10, 10, 10, "sumary 1")]
        [TestCase(-2, 2, 20, "summary 2")]
        [TestCase(-1, 10, 5, "test 1")]
        [TestCase(-2, 20, 15, "test 2")]
        [TestCase(-10, -10, 10, "summary 1")]
        [Test, Order(2)]
        public void Update_Exception(int id, int idExample, int intExample, string? stringExample)
        {
            ExampleUpdateModel model = new ExampleUpdateModel() { Id = idExample, IntExample = intExample, StringExample = stringExample };
            Assert.That(() => _service.Update(id, model), Throws.TypeOf<NotImplementedException>());
        }

        [NonParallelizable]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(-1, false)]
        [TestCase(-2, false)]
        [TestCase(-10, false)]
        [TestCase(-20, false)]
        [Test, Order(3)]
        public void Delete(int id, bool resultExpexted)
        {
            bool result = _service.Delete(id).Result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(resultExpexted));
            });
        }
    }
}