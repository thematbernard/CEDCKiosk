using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SRW_Backend_API.Data;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Repository.Repositories;
using SRW_Backend_API.Services.Interfaces;
using SRW_Backend_API.Services.Services;

namespace SRW_Backend_API
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
            // Get the host name of the local computer
            // var hostName = Environment.MachineName;

            // Original connection string with [placeholder]
            var connectionString = Configuration.GetConnectionString("Azure_Database");

            // Replace [placeholder] with the hostName
            // connectionString = connectionString.Replace("[placeholder]", hostName);

            // Database Connection
            services.AddDbContext<SRWVirtualHubDbContext>(options => options.UseSqlServer(connectionString));

            // Add services and repositories here
            // addcors service - ss
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("https://srwfrontendserver.azurewebsites.net/") // Replace with your frontend's URL
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });
            // end service - ss
            services.AddScoped<IAssistanceRepository, AssistanceRepository>();
            services.AddScoped<IAssistanceService, AssistanceService>();

            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceService, ResourceService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<IResourceTagRepository, ResourceTagRepository>();
            services.AddScoped<IResourceTagService, ResourceTagService>();

            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IFunctionService, FunctionService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();
            
            services.AddScoped<IUserRoomRepository, UserRoomRepository>();
            services.AddScoped<IUserRoomService, UserRoomService>();

            services.AddScoped<IOpportunityTypeRepository, OpportunityTypeRepository>();
            services.AddScoped<IOpportunityTypeService, OpportunityTypeService>();
            
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IOpportunityService, OpportunityService>();
            
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();

            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ITrainingService, TrainingService>();

            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IRentalService, RentalService>();
            
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<ISectorService, SectorService>();

            services.AddScoped<IDatasetTypeRepository, DatasetTypeRepository>();
            services.AddScoped<IDatasetTypeService, DatasetTypeService>();

            services.AddScoped<IDatasetRepository, DatasetRepository>();
            services.AddScoped<IDatasetService, DatasetService>();

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddAuthorizationCore();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Ensure the CORS policy is applied globally by calling UseCors with policy name in the Configure method - ss
            app.UseCors("MyAllowSpecificOrigins");
            //End method - ss
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}