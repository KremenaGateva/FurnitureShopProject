namespace WebStore.App
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WebStore.App.Common;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.DataOperator.Interfaces;
    using WebStore.Services.DataOperator;
    using AutoMapper;
    using WebStore.Services.Anonymous.Interfaces;
    using WebStore.Services.Anonymous;
    using WebStore.Services.User.Interfaces;
    using WebStore.Services.User;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Services.Admin;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<WebStoreContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WebStoreContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequireDigit = true,
                    RequiredUniqueChars = 1,
                    RequireLowercase = true,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                //options.SignIn.RequireConfirmedEmail = true;
            });
            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IDataOperatorProductsService, DataOperatorProductsService>();
            services.AddScoped<IDataOperatorCategoriesService, DataOperatorCategoriesService>();
            services.AddScoped<IAnonymousProductsService, AnonymousProductsService>();
            services.AddScoped<IAnonymousCategoriesService, AnonymousCategoriesService>();
            services.AddScoped<IUserShoppingCartService, UserShoppingCartService>();
            services.AddScoped<IUserOrdersService, UserOrdersService>();
            services.AddScoped<IAdminUsersService, AdminUsersService>();
            services.AddScoped<IAdminOrdersService, AdminOrdersService>();
        }
    }
}
