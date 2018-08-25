namespace WebStore.Services
{
    using AutoMapper;
    using WebStore.Data;

    public abstract class BaseService
    {
        protected BaseService(WebStoreContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        protected WebStoreContext Context { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
