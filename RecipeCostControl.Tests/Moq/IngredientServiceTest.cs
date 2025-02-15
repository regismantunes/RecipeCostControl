using Moq;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Repositories.Interfaces;
using RecipeCostControl.Services;
using System.Net.Http.Headers;

namespace RecipeCostControl.Tests.Moq
{
    public class IngredientServiceTest
    {
        private readonly Service<Ingredient> _sut;
        private readonly Mock<IIngredientRepository> _repositoryMock;

        public IngredientServiceTest()
        {
            _repositoryMock = new Mock<IIngredientRepository>();
            _sut = new Service<Ingredient>(_repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_GoodScenario()
        {
            //Arrange
            var newEntity = new Ingredient()
            {
                Name = "Test",
                MeasurementUnitId = "kg",
                Cost = 5.99M
            };

            var insertedId = new Random().Next();
            _repositoryMock.Setup(x => x.InsertAsync(newEntity))
                .ReturnsAsync(() =>
                    new Ingredient()
                    {
                        Name = newEntity.Name,
                        MeasurementUnitId = newEntity.MeasurementUnitId,
                        Cost = newEntity.Cost,
                        Id = insertedId
                    });

            //Act
            var entityAdded = await _sut.InsertAsync(newEntity);

            //Assert
            Assert.NotNull(entityAdded);
            Assert.NotNull(entityAdded?.Id);
            Assert.Equal(entityAdded?.Id, insertedId);
            Assert.Equal(entityAdded?.Name, newEntity.Name);
            Assert.Equal(entityAdded?.MeasurementUnitId, newEntity.MeasurementUnitId);
            Assert.Equal(entityAdded?.Cost, newEntity.Cost);
        }

        [Fact]
        public async Task InsertAsync_ShouldGetError_WhenIdIsNotNull()
        {
            //Arrange
            var newEntity = new Ingredient()
            {
                Id = new Random().Next(),
                Name = "Test",
                MeasurementUnitId = "kg",
                Cost = 5.99M
            };

            _repositoryMock.Setup(x => x.InsertAsync(newEntity))
                .ThrowsAsync(new InvalidOperationException());

            //Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _sut.InsertAsync(newEntity));
        }

        [Fact]
        public async Task InsertAsync_ShouldGetError_WhenNameAlreadyExists()
        {
            //Arrange
            var newEntity1 = new Ingredient()
            {
                Name = "Test",
                MeasurementUnitId = "kg",
                Cost = 5.99M
            };

            var newEntity2 = new Ingredient()
            {
                Name = "Test",
                MeasurementUnitId = "kg",
                Cost = 5.99M
            };

            _repositoryMock.Setup(x => x.InsertAsync(newEntity1))
                .ReturnsAsync(() =>
                    new Ingredient()
                    {
                        Name = newEntity1.Name,
                        MeasurementUnitId = newEntity1.MeasurementUnitId,
                        Cost = newEntity1.Cost,
                        Id = new Random().Next()
                    });

            _repositoryMock.Setup(x => x.InsertAsync(newEntity2))
                .ThrowsAsync(new InvalidOperationException());

            //Act
            await _sut.InsertAsync(newEntity1);
            
            await Assert.ThrowsAsync<InvalidOperationException>(() => _sut.InsertAsync(newEntity2));
        }

        [Fact]
        public async Task FlatronsTestApi()
        {
            using var httpClient = new HttpClient();
            using var multipartFormContent = new MultipartFormDataContent();

            var fileStreamContent = new StreamContent(File.OpenRead("D:\\Source\\Repos\\rails_node_test_regismantunes\\data1.csv"));
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            multipartFormContent.Add(fileStreamContent, name: "file", fileName: "data.csv");

            // Send POST request
            var response = await httpClient.PostAsync("http://localhost:5169/api/products/addfromfile", multipartFormContent);

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
