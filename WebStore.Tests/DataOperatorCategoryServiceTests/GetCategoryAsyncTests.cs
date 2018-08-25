namespace WebStore.Tests.DataOperatorCategoryServiceTests
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.DataOperator;
    using WebStore.Tests.Mocks;

    [TestClass]
    public class GetCategoryAsyncTests
    {
        private WebStoreContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public async Task GetCategoryByNameAsync_WithProperName_ShouldReturnCategory()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "TestCategory" });
            this.dbContext.SaveChanges();
            var name = "TestCategory";
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategory = await service.GetCategoryByNameAsync(name);

            Assert.IsNotNull(resultCategory);
            Assert.IsInstanceOfType(resultCategory, typeof(Category));
            Assert.AreEqual(name, resultCategory.Name);

        }

        [TestMethod]
        public async Task GetCategoryByNameAsync_WithWrongName_ShouldReturnNull()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "TestCategory" });
            this.dbContext.SaveChanges();
            var name = "Test";
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategory = await service.GetCategoryByNameAsync(name);

            Assert.IsNull(resultCategory);
        }

        [TestMethod]
        public async Task GetCategoryByNameAsync_WithEmptyString_ShouldReturnNull()
        {
            this.dbContext.Categories.Add(new Category() { Id = 1, Name = "TestCategory" });
            this.dbContext.SaveChanges();
            var name = "";
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategory = await service.GetCategoryByNameAsync(name);

            Assert.IsNull(resultCategory);
        }

        [TestMethod]
        public async Task GetCategoryByNameAsync_OnEmptyCollection_ShouldReturnNull()
        {
            var name = "TestCategory";
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);

            var resultCategory = await service.GetCategoryByNameAsync(name);

            Assert.IsNull(resultCategory);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
        }
    }
}