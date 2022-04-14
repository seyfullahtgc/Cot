using Cot.Business.ServiceConcrete;
using Cot.Core.Abstract;
using Cot.Core.Services;
using Cot.Core.UnitOfWork;
using Cot.DataAccess;
using Cot.DataAccess.Concrete;
using Cot.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<CotDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
    {
        o.MigrationsAssembly("Cot.DataAccess");
    });
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
