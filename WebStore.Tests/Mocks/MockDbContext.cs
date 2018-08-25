namespace WebStore.Tests.Mocks
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Data;

    public static class MockDbContext
    {
        public static WebStoreContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<WebStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new WebStoreContext(options);
        }
    }
}
