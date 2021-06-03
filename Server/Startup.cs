using FluentValidation;
using FluentValidation.AspNetCore;
using IbanNet.DependencyInjection.ServiceProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Transactions.Client.Validator;
using Transactions.Server.Repository;
using Transactions.Server.Service;
using Transactions.Server.Service.Implementation;
using Transactions.Shared.Model;

namespace Transactions.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TransactionContext>(opt => opt.UseInMemoryDatabase("db"));
            services.AddScoped<TransactionContext>(); 
            services.AddIbanNet();
            services.AddTransient<IValidator<TransactionRequest>, TransactionRequestValidator>();
            services.AddTransient<IValidator<AccountRequest>, AccountRequestValidator>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddSingleton<IMapperService, MapperService>();

            services.AddFluentValidation();
            services.AddRazorPages();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString;
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
