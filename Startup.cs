
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<TaskDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<TaskRepository>();

    services.AddControllers()
        .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
}
