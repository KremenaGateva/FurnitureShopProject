namespace WebStore.Tests.Mocks
{
    using AutoMapper;
    using WebStore.App.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetAutoMapper()
        {
            return AutoMapper.Mapper.Instance;
        }
    }
}
