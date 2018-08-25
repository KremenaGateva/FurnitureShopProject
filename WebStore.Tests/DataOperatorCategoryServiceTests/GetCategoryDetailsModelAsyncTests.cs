namespace WebStore.Tests.DataOperatorCategoryServiceTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebStore.Common.DataOperator.ViewModels;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.DataOperator;
    using WebStore.Tests.Mocks;

    [TestClass]
    public class GetCategoryDetailsModelAsyncTests
    {
        private WebStoreContext dbContext;
        private IMapper mapper;


        [TestMethod]
        public async Task GetCategoryDetailsModelAsync_WithProperId_ShouldReturnCategoryDetailsModel()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First" });
            this.dbContext.Categories.Add(new Category() { Id = 2, Name = "Second" });
            this.dbContext.Categories.Add(new Category() { Id = 3, Name = "Third" });
            this.dbContext.SaveChanges();
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            var id = 1;

            var resultCategoryModel = await service.GetCategoryDetailsModelAsync(id);

            Assert.IsNotNull(resultCategoryModel);
            Assert.IsTrue(resultCategoryModel.Name == "First");
            Assert.IsInstanceOfType(resultCategoryModel, typeof(CategoryDetailsViewModel));
        }

        [TestMethod]
        public async Task GetCategoryDetailsModelAsync_WithInvalidId_ShouldReturnNull()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First" });
            this.dbContext.Categories.Add(new Category() { Id = 2, Name = "Second" });
            this.dbContext.Categories.Add(new Category() { Id = 3, Name = "Third" });
            this.dbContext.SaveChanges();
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            var id = 5;

            var resultCategoryModel = await service.GetCategoryDetailsModelAsync(id);

            Assert.IsNull(resultCategoryModel);
        }

        [TestMethod]
        public async Task GetCategoryDetailsModelAsync_WithNegativeId_ShouldReturnNull()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First" });
            this.dbContext.Categories.Add(new Category() { Id = 2, Name = "Second" });
            this.dbContext.Categories.Add(new Category() { Id = 3, Name = "Third" });
            this.dbContext.SaveChanges();
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            var id = -1;

            var resultCategoryModel = await service.GetCategoryDetailsModelAsync(id);

            Assert.IsNull(resultCategoryModel);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
        }
    }
}
