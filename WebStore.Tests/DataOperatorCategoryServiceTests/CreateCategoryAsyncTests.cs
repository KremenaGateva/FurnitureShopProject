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
    public class CreateCategoryAsyncTests
    {
        private WebStoreContext dbContext;
        private IMapper mapper;


        [TestMethod]
        public async Task CreateCategoryAsync_WithProperName_ShouldReturnCategory()
        {
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            var name = "TestCategory";

            var resultCategory = await service.CreateCategoryAsync(name);

            Assert.IsNotNull(resultCategory);
            Assert.IsInstanceOfType(resultCategory, typeof(Category));
            Assert.AreEqual(name, resultCategory.Name);
        }

        [TestMethod]
        public async Task CreateCategoryAsync_WithEmptyString_ShouldReturnNull()
        {
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            var name = "";

            var resultCategory = await service.CreateCategoryAsync(name);

            Assert.IsNull(resultCategory);
        }

        [TestMethod]
        public async Task CreateCategoryAsync_WithNull_ShouldReturnNull()
        {
            var service = new DataOperatorCategoriesService(this.dbContext, this.mapper);
            string name = null;

            var resultCategory = await service.CreateCategoryAsync(name);

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
