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
    public class GetAllCategoriesAsyncTests
    {
        private WebStoreContext dbContext;
        private IMapper mapper;


        [TestMethod]
        public async Task GetAllCategoriesAsync_WithCategories_ShouldReturnAll()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First" });
            this.dbContext.Categories.Add(new Category() { Id = 2, Name = "Second" });
            this.dbContext.Categories.Add(new Category() { Id = 3, Name = "Third" });
            this.dbContext.SaveChanges();
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategoriesModels = await service.GetAllCategoriesAsync();

            Assert.IsNotNull(resultCategoriesModels);
            Assert.IsTrue(resultCategoriesModels.Count() == 3);
            Assert.IsInstanceOfType(resultCategoriesModels.First(), typeof(CategoryConciseViewModel));
        }

        [TestMethod]
        public async Task GetAllCategoriesAsync_WithOneCategory_ShouldReturnAll()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "First" });
            this.dbContext.SaveChanges();
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategoriesModels = await service.GetAllCategoriesAsync();

            Assert.IsNotNull(resultCategoriesModels);
            Assert.IsTrue(resultCategoriesModels.Count() == 1);
            Assert.IsInstanceOfType(resultCategoriesModels.First(), typeof(CategoryConciseViewModel));
        }

        [TestMethod]
        public async Task GetAllCategoriesAsync_WithNoCategories_ShouldReturnEmptyCollection()
        {
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategoriesModels = await service.GetAllCategoriesAsync();

            Assert.IsNotNull(resultCategoriesModels);
            Assert.IsTrue(resultCategoriesModels.Count() == 0);
        }
        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
        }

    }
}
